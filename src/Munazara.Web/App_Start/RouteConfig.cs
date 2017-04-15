using System.Web.Mvc;
using System.Web.Routing;

namespace Munazara.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Category",
                "c/{slug}",
                new { controller = "Category", action = "Detail", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Topic",
                "t/{slug}-{id}",
                new { controller = "Topic", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}