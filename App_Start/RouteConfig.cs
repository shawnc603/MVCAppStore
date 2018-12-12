using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sample_MVCApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DisplayProductDetails",
                url: "ProductDetails/DisplayProductDetails/{id}",
                defaults: new { controller = "ProductDetails", action = "DisplayProductDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "Cart/Checkout/{id}",
                defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "User",
               url: "User/{action}/{id}",
               defaults: new { controller = "User", action = "UserAdd", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "UserAdd",
               url: "User/Add/{id}",
               defaults: new { controller = "User", action = "UserAdd", id = UrlParameter.Optional }
           );
        }
    }
}