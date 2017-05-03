using System.Web.Mvc;
using System.Web.Routing;

namespace OppositeEnds
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
        "Floralfront",
           "Index/{searchCategory}",
            new { controller = "Florals", action = "Index", searchCategory= UrlParameter.Optional }
 );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
