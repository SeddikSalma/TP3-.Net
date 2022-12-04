using System.Web.Mvc;
using System.Web.Routing;

namespace firstApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                        name: "Perons",
                        url: "person/{action}/{id}",
                        defaults: new { controller = "DataBase", action = "Persons", id = UrlParameter.Optional }
                    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
