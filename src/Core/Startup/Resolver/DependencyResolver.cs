using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Rdcs.Models;
using Rdcs.Repositories;
using Rdcs.Services;
using Rdcs.Controllers;
using Rdcs.Core.Context;
using Rdcs.Core.Attributes;
using Rdcs.Core.Base;
using System;
using System.Reflection;
using System.Linq;

namespace Rdcs.Core.Resolver
{
    public class DependencyResolver
    {
        public static void Configure(IServiceCollection services)
        {            
            int initSize = services.Count;
            for(int i = 0; i < initSize; i++)
            {
                Type serviceType = services[i].ServiceType;                   
                if(serviceType.ToString().IndexOf("Rdcs.Controllers") == 0){
                    services.AddScoped(serviceType, ctx => GetInstance(services[i])); 
                }
            }
        }

        private static dynamic GetInstance(ServiceDescriptor sd) 
        {
            Type serviceType = sd.ServiceType;
            DependencyContainer DepContainer = new DependencyContainer(new ApplicationContext());
            dynamic obj = DepContainer.GetInstanceOf(serviceType);
            FieldInfo[] fields = serviceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                if (!field.GetCustomAttributes(typeof(AutowiredAttribute), false).Any()) continue;

                Type toInject = field.FieldType;
                field.SetValue(obj, DepContainer.GetInstanceOf(toInject));
            }
            for(int i = 0; i < DepContainer.Objects.Count; i++)
            {
                ResolveSubProperties(DepContainer.Objects[i], DepContainer);
            }
            DepContainer.Objects.ForEach(x => ResolveContexts(x, DepContainer));
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

        private static void ResolveContexts(object obj, DependencyContainer DepContainer)
        {            
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);            
            FieldInfo context = fields.Where(x => x.Name.Equals("Context")).FirstOrDefault();
            if(context != null)
            {
                context.SetValue(obj, DepContainer.Context);    
            }
     
        }

        
    }
}