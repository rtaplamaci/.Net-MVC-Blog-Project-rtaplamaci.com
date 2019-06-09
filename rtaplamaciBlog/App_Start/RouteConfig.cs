using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rtaplamaciBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Anasayfa", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "BlogDetay",
               url: "{controller}/{baslik}/{action}/{id}",
               defaults: new { controller = "Blog", action = "Detay", id = UrlParameter.Optional }
           );
        }
    }
}
