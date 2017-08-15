using Autofac;
using Autofac.Integration.WebApi;
using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Smafac.Framework.WebApi
{
    public class WebApiRegister
    {
        public static IContainer ObjectContainer
        {
            get;
            private set;
        }

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                    name: "ActionApi",
                    routeTemplate: "{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

            config.MessageHandlers.Add(new UserContextMessageHandler());
        }

        public static void DependencyRegistrar(HttpConfiguration config, IEnumerable<Assembly> assemblies,Assembly webApiAssembly)
        {
            var builder = new ContainerBuilder();
            assemblies.ToList().ForEach(assembly =>
            {
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            });
            builder.RegisterAssemblyTypes(typeof(IAutofacScan).Assembly).AsImplementedInterfaces();

            builder.RegisterApiControllers(webApiAssembly);
            var container = builder.Build();
            ObjectContainer = container;
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            var autoMapper = container.Resolve<IAutoMapperProxy>();
            autoMapper.CreateMapper();
        }
    }
}