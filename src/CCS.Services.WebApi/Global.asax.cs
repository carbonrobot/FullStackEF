using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CCS.Services.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.RegisterLogger();
            UnityConfig.RegisterComponents(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
