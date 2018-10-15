using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Rdcs.Constants;

namespace Rdcs.Authorization
{
    public class AuthorizationConfigurer
    {
        public static SigningConfigurations signingConfigurations { get; private set; }
        public static TokenConfigurations tokenConfigurations { get; private set; }

        public static void Configure(IServiceCollection services, IConfiguration configuration, 
            Type authorizationCheckServiceType, Type rdcsContextType)
        {
            signingConfigurations = new SigningConfigurations();
            tokenConfigurations = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(configuration.GetSection(Constant.CONFIG_TOKEN_PROPERTIES))
                    .Configure(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddSingleton<IAuthorizationPolicyProvider>(ctx => 
                new RdcsAuthorizationPolicyProvider(authorizationCheckServiceType, rdcsContextType));

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy(Constant.PERMISSION_POLICY_NAME, new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //        .RequireAuthenticatedUser()
            //        .RequireAssertion(ctx => IsAuthorized(ctx))
            //        .Build());                
            //});
        }

        //public static bool IsAuthorized(AuthorizationHandlerContext ctx)
        //{
        //    return true;
        //}

        public static AuthorizationToken GenerateToken(long userId)
        {
            string guid = Guid.NewGuid().ToString("N");
            string userIdentification = userId.ToString();
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userIdentification, Constant.GENERIC_IDENTITY_TYPE),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, guid),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userIdentification)
                    }
                );

            DateTime created = DateTime.Now;
            DateTime expiration = created +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = created,
                Expires = expiration
            });
            var token = handler.WriteToken(securityToken);

            return new AuthorizationToken(created, expiration, token);
        }

        public static long GetUserId(ClaimsPrincipal user)
        {
            if (!string.IsNullOrEmpty(user.Identity.Name))
            {
                return long.Parse(user.Identity.Name);
            }
            return 0;
        }
    }
}
