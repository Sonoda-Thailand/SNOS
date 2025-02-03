using SNOS_Report.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SNOS_Report
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static void BuildConnectionString()
        {
            //DEV
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SNOSEntities"];
            //SND_SNOSEntities.ConnectionString = String.Format(settings.ToString(), "euro_admin", "Sonoda@it");
            //PRD
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SNOSEntities"];
            SND_SNOSEntities.ConnectionString = String.Format(settings.ToString(), "SNOS", "SNOS@coilline");
        }
        protected void Application_Start()
        {
            BuildConnectionString();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
