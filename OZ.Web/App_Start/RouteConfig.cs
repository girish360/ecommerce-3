using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OZ.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "product",
                url: "Product/{page}",
                defaults: new { controller="Product",action="Index",page=1 },
                namespaces: new[] { "OZ.WebController.Default" }
                );

            routes.MapRoute(
            name: "productCategory",
            url: "Product/ShowByCategory/{category}/{page}",
            defaults: new { controller = "Product", action = "ShowByCategory", page = 1 },
            namespaces: new[] { "OZ.WebController.Default" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OZ.WebController.Default" }
            );
        }
    }
}
