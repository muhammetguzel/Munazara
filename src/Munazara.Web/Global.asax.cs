
using Autofac;
using Autofac.Integration.Mvc;
using Munazara.Application.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Munazara.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
            var builder =  IOCHelper.GetContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();
           
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
