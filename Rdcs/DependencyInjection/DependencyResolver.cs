using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Linq;
using Rdcs.Context;
using Rdcs.Attributes;
using System.Collections.Generic;
using Rdcs.BaseEntities;
using Rdcs.Constants;

namespace Rdcs.DependencyInjection
{
    public class DependencyResolver
    {
        public static void Configure(IServiceCollection services, Type rdcsContextType)
        {
            List<ServiceDescriptor> rdcsTypes = services
                .Where(x => typeof(RdcsController).IsAssignableFrom(x.ServiceType))
                .ToList();

            rdcsTypes.ForEach(x => {
                services.AddScoped(x.ServiceType, ctx => GetInstance(x.ServiceType, rdcsContextType));
            });
        }

        public static dynamic GetInstance(Type serviceType, Type rdcsContextType)
        {
            RdcsContext ctx = (RdcsContext)Activator.CreateInstance(rdcsContextType);
            return GetInstance(serviceType, ctx);
        }

        public static dynamic GetInstance(Type serviceType, RdcsContext ctx)
        {
            DependencyContainer DepContainer = new DependencyContainer(ctx);
            dynamic obj = DepContainer.GetInstanceOf(serviceType);
            FieldInfo[] fields = serviceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                if (!field.GetCustomAttributes(typeof(AutowiredAttribute), false).Any()) continue;

                Type toInject = field.FieldType;
                field.SetValue(obj, DepContainer.GetInstanceOf(toInject));
            }
            for (int i = 0; i < DepContainer.Objects.Count; i++)
            {
                ResolveSubProperties(DepContainer.Objects[i], DepContainer);
            }
            DepContainer.Objects.ForEach(x => ResolveContext(x, DepContainer));
            return obj;
        }

        private static void ResolveSubProperties(object obj, DependencyContainer DepContainer)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                if (!field.GetCustomAttributes(typeof(AutowiredAttribute), false).Any()) continue;

                Type toInject = field.FieldType;
                field.SetValue(obj, DepContainer.GetInstanceOf(toInject));
            }
        }

        private static void ResolveContext(object obj, DependencyContainer DepContainer)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo context = fields.Where(x => x.Name.Equals(Constant.CONTEXT_PROPERTY_NAME)).FirstOrDefault();
            if (context != null)
            {
                context.SetValue(obj, DepContainer.Context);
            }

        }
    }
}
