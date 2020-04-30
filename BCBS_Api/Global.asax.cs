using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BCBS_Api.Common;

namespace BCBS_Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Here is the once-per-application setup information
               log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        Util.LogInfo("BeginRequest", "method option found");
        //        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST,OPTIONS");
        //        //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        //        HttpContext.Current.Response.End();
        //    }
        //}
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
        }
    }

}