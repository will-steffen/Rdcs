using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Rdcs.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Rdcs.Context;
using Rdcs.Authorization;
using Microsoft.Extensions.Configuration;

namespace Rdcs.Startup
{
    public static class RdcsServiceCollectionExtensions
    {
        /// <summary>
        /// Inicia o Rdcs. 
        /// Configura Injeção de Dependência.
        /// Configura Permissionamento.
        /// </summary>
        public static void AddRdcs<RdcsContextType, RdcsAuthorizationCheckServiceType>(
            this IServiceCollection services, IConfiguration configuration)
            where RdcsContextType : RdcsContext
            where RdcsAuthorizationCheckServiceType : RdcsAuthorizationCheckService
        {
            //services.AddMvc(opt => opt.Conventions.Add(new AuthorizationFilterConfigurer()))
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            DependencyResolver.Configure(services, typeof(RdcsContextType));
            AuthorizationConfigurer.Configure(services, configuration, 
                typeof(RdcsAuthorizationCheckServiceType), typeof(RdcsContextType));
        }


    }
}
