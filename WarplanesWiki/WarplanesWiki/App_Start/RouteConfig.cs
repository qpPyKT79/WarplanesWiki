using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WarplanesWiki
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "", new
            {
                controller = "Warplane",
                action = "List",
                country = (string)null,
                page = 1
            }
                );

            routes.MapRoute(null, "Page{page}",
                new { controller = "Warplane", action = "List", country = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{country}",
                new { controller = "Warplane", action = "List", page = 1 }
            );

            routes.MapRoute(null, "{country}/Page{page}",
                new { controller = "Warplane", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
/*
routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
routes.MapRoute(null, "", new {
            controller = "Warplane",
            action = "List",
            country = (string)null,
            page = 1
        }
    );

routes.MapRoute(null, "Page{page}",
    new { controller = "Warplane", action = "List", country = (string)null },
    new { page = @"\d+" }
);

routes.MapRoute(null, "{country}",
    new { controller = "Warplane", action = "List", page = 1 }
);

routes.MapRoute(null, "{country}/Page{page}",
    new { controller = "Warplane", action = "List" },
    new { page = @"\d+" }
);

routes.MapRoute(null, "{controller}/{action}");
*/
