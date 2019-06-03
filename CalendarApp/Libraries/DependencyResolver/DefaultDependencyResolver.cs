using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarApp.Libraries.DependencyResolvers
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider ServiceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ServiceProvider.GetServices(serviceType);
        }
    }
}