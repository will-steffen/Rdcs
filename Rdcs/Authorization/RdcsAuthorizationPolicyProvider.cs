using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Rdcs.BaseEntities;
using Rdcs.Constants;
using Rdcs.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rdcs.Authorization
{
    public class RdcsAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private static string policyNameDelimiter = ":";
        private Type authorizationCheckServiceType;
        private Type rdcsContextType;

        public RdcsAuthorizationPolicyProvider(Type authorizationCheckServiceType, Type rdcsContextType)
        {
            this.authorizationCheckServiceType = authorizationCheckServiceType;
            this.rdcsContextType = rdcsContextType;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(Constant.PERMISSION_POLICY_NAME, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                //policy.AddRequirements(new MinimumAgeRequirement(age));
                policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
                policy.RequireAssertion(ctx => IsAuthorized(ctx, GetPermission(policyName)));
                return Task.FromResult(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);
        }

        public bool IsAuthorized(AuthorizationHandlerContext ctx, RdcsPermission requiredPermission)
        {
            long userId = AuthorizationConfigurer.GetUserId(ctx.User);
            if (userId > 0)
            {
                RdcsAuthorizationCheckService serviceCheck =
                    DependencyResolver.GetInstance(authorizationCheckServiceType, rdcsContextType);
                return serviceCheck.HasPermission(userId, requiredPermission);
            }
            return false;
        }

        public static string GetPolicyName(RdcsPermission permission)
        {
            return Constant.PERMISSION_POLICY_NAME + policyNameDelimiter + 
                permission.Type + policyNameDelimiter + (int)permission.Level;
        }

        public static RdcsPermission GetPermission(string policyName)
        {
            string[] policy = policyName.Split(policyNameDelimiter);
            int type = int.Parse(policy[1]);
            PermissionLevel level = (PermissionLevel)int.Parse(policy[2]);
            RdcsPermission permission = new RdcsPermission { Type = type, Level = level };
            return permission;
        }
    }
}
