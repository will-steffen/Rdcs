using Microsoft.Extensions.DependencyInjection;
using Rdcs.BaseEntities;
using Rdcs.Context;
using Rdcs.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rdcs.Test
{
    public class RdcsDependencyFixture<TContext> where TContext : RdcsContext
    {
        public ServiceProvider ServiceProvider { get; private set; }
        private RdcsContext rdcsContext;

        public RdcsDependencyFixture()
        {
            resetContext();
        }

        public void resetContext()
        {
            rdcsContext = (RdcsContext)Activator.CreateInstance(typeof(TContext));
        }

        public TDependency Resolve<TDependency>()
            where TDependency : RdcsCommonBase
        {  
            return DependencyResolver.GetInstance(typeof(TDependency), rdcsContext);
        }
        
    }
}
