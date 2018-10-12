using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Rdcs.Core.Context;

namespace Rdcs.Core.Resolver
{
    public class DependencyContainer
    {
        public List<object> Objects { get; set; }
        public ApplicationContext Context;

        public DependencyContainer(ApplicationContext ctx) {
            Objects = new List<object>();
            Context = ctx;
        }
        
        private void Hold(object obj)
        {
            Objects.Add(obj);
        }

        public object GetSaved(Type type)
        {
            return Objects.Where(o => o.GetType().Equals(type)).FirstOrDefault();
        }

        public dynamic GetInstanceOf(Type type)
        {
            dynamic instance = GetSaved(type);
            if(instance != null) return instance;
            instance = Activator.CreateInstance(type);
            if (instance != null) Hold(instance);
            return instance;
        }
    }
}
