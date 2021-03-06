﻿using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Smafac.Account.Subscriber.Applications;
using Smafac.Crm.Customer.Applications;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Hrs.Attendance.Applications;
using Smafac.Hrs.Employee.Applications;
using Smafac.Hrs.Salary.Applications;
using Smafac.Infrustructure.Common;
using Smafac.Pms.Purchase.Applications;
using Smafac.Presentation;
using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.Order.Applications;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Stock.Applications;
using System;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Smafac.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


        // 有关配置身份验证的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var mvcAssembly = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(mvcAssembly);
            builder.RegisterAssemblyTypes(mvcAssembly)
            .AsImplementedInterfaces();

            Register<IAutofacScanFrameworkCore>(builder);
            Register<IAutofacScanDeliveryNote>(builder);
            Register<IAutofacScanOrder>(builder);
            Register<IAutofacScanGoods>(builder);
            Register<IAutofacScanCustomer>(builder);
            Register<IAutofacScanSubscriber>(builder);
            Register<IAutofacScanCommon>(builder);
            Register<IAutofacScanCustomerFinance>(builder);
            Register<IAutofacScanFrameworkDriver>(builder);
            Register<IAutofacScanPurchase>(builder);
            Register<IAutofacScanStock>(builder);
            Register<IAutofacScanEmployee>(builder);
            Register<IAutofacScanSalary>(builder);
            Register<IAutofacScanAttendance>(builder);
            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            container.Resolve<IAutoMapperProxy>().CreateMapper();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Subscriber/SignInView"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30)
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }

        private void Register<T>(ContainerBuilder builder) where T : class
        {
            builder.RegisterAssemblyTypes(typeof(T).Assembly)
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(T).Assembly)
                   .AsSelf();
        }
    }
}
