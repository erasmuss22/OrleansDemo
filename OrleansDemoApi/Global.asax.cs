using Microsoft.WindowsAzure.ServiceRuntime;
using Orleans;
using Orleans.Runtime.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OrleansDemoApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // check if running in azure
            if (RoleEnvironment.IsAvailable)
            {
                AzureClient.Initialize(Server.MapPath("AzureClientConfiguration.xml"));     
            }
            else
            {
                GrainClient.Initialize(Server.MapPath("ClientConfiguration.xml"));
            }
        }
    }
}
