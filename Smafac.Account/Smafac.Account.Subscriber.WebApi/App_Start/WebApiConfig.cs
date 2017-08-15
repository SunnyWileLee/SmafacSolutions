using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Smafac.Account.Subscriber.Applications;
using Smafac.Framework.WebApi;
using System.Reflection;

namespace Smafac.Account.Subscriber.WebApi
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
