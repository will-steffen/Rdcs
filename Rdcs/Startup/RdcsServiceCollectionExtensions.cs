using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Rdcs.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Rdcs.Context;

namespace Rdcs.Startup
{
    public static class RdcsServiceCollectionExtensions
    {
        /// <summary>
        /// Inicia o Rdcs. Configura Injeção de Dependência.
        /// </summary>
        public static void AddRdcs<RdcsContextType>(this IServiceCollection services)
            where RdcsContextType : RdcsContext
        {
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            DependencyResolver.Configure(services, typeof(RdcsContextType));
        }
    }
}
