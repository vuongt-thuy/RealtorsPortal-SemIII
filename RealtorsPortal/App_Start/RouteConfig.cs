using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealtorsPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "User_Login",
                url: "Login",
                defaults: new { action = "Login", controller = "Account"},
                namespaces: new[] { "RealtorsPortal.Controllers" }
            );

            routes.MapRoute(
                name: "User_Register",
                url: "Register",
                defaults: new { action = "Register", controller = "Account"},
                namespaces: new[] { "RealtorsPortal.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RealtorsPortal.Controllers" }
            );
        }
    }
}
