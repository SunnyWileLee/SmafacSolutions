using Smafac.Crm.Customer.Applications;
using Smafac.Framework.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Smafac.Crm.Customer.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            WebApiRegister.Register(config);
            var assembly = typeof(IAutofacScan).Assembly;
            WebApiRegister.DependencyRegistrar(config, new List<Assembly> { assembly }, Assembly.GetExecutingAssembly());
        }
    }
}
