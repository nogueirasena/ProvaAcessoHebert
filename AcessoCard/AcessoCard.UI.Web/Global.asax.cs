using AcessoCard.CrossCutting;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper.Configuration;
using AcessoCard.Application.AutoMapper;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;

namespace AcessoCard.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
             var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();  //WebRequestLifestyle();

            BootStrapper.RegisterServices(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            AutoMapperConfig.RegisterMappings();
            
        }
    }
}
