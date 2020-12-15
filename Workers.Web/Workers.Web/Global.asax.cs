using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using WorkersInfo.Data;

namespace Workers.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            StaticDataContext.Directory = HostingEnvironment.MapPath("~/files");

            if (File.Exists(StaticDataContext.FilePath))
            {
                StaticDataContext.Load();
            }
            else
            {
                StaticDataContext.CreateTestingData();
            }
            //StaticDataContext.CreateTestingData();
        }
    }
}
