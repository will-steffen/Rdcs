using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Rdcs.Context;

namespace Rdcs.DependencyInjection
{
    public class DependencyContainer
    {
        public List<object> Objects { get; set; }
        public RdcsContext Context;

        public DependencyContainer(RdcsContext ctx)
        {
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
            if (instance != null) return instance;
            instance = Activator.CreateInstance(type);
            if (instance != null) Hold(instance);
            return instance;
        }
    }
}
