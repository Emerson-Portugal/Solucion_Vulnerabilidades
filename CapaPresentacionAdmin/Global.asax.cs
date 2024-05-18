using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CapaPresentacionAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true; // Esto deshabilita la cabecera X-AspNetMvc-Version
        }

        protected void Application_PreSendRequestHeaders()
        {
            // Remover la cabecera X-Powered-By antes de enviar la respuesta al cliente
            Response.Headers.Remove("X-Powered-By");
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // En el inicio de la solicitud, remover la cabecera Server
            var app = sender as HttpApplication;
            if (app != null && app.Context != null)
            {
                app.Context.Response.Headers.Remove("Server");
            }
        }


    }
}
