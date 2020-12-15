using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Workers.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: null,
               url: "Працівники",
               defaults: new { controller = "Workers", action = "InfoWithPaging", pageKey = "..", pageNumber = 0 });

            routes.MapRoute(
               name: null,
               url: "Працівники_{pageKey}",
               defaults: new { controller = "Workers", action = "InfoWithPaging",pageNumber = 0 },
               constraints:new {pageKey=@"[A-ЯЄ]"}
               );
            routes.MapRoute(
               name: null,
               url: "Працівники_{pageNumber}",
               defaults: new { controller = "Workers", action = "InfoWithPaging", pageKey = ".." },
               constraints: new { pageNumber = @"\d+" }
               );
            routes.MapRoute(
              name: null,
              url: "Працівники_{pageKey}_{pageNumber}",
              defaults: new { controller = "Workers", action = "InfoWithPaging",},
              constraints: new { pageNumber = @"\d+",pageKey=@"[A-ЯЄ]"}
              );
            routes.MapRoute(
              name: null,
              url: "Посади",
              defaults: new { controller = "Posts", action = "InfoWithPaging", pageKey = "..", pageNumber = 0 });

            routes.MapRoute(
              name: null,
              url: "Посади_{pageKey}",
              defaults: new { controller = "Posts", action = "InfoWithPaging", pageNumber = 0 },
              constraints: new { pageKey = @"[A-ЯЄ]" }
              );
            routes.MapRoute(
               name: null,
               url: "Посади_{pageNumber}",
               defaults: new { controller = "Posts", action = "InfoWithPaging", pageKey = ".." },
               constraints: new { pageNumber = @"\d+" }
               );
            routes.MapRoute(
              name: null,
              url: "Посади_{pageKey}_{pageNumber}",
              defaults: new { controller = "Posts", action = "InfoWithPaging", },
              constraints: new { pageNumber = @"\d+", pageKey = @"[A-ЯЄ]" }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "WorkersController", action = "ObjectsInfo", id = UrlParameter.Optional }
            );
        }
    }
}
