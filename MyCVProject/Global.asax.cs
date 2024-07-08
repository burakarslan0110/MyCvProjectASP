using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyCVProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //HATALARDA ANA SAYFAYA YÖNLENDİRME
        //protected void Application_Error()
        //{
        //    Exception exception = Server.GetLastError();
        //    //    Hatanın detaylarını loglama(isteğe bağlı)
        //    //Logger.LogError(exception);

        //    //    Hatanın işlendiğini belirt
        //    Server.ClearError();

        //    //    Ana sayfaya yönlendir
        //    Response.Redirect("~/Default/Index");
        //    //}
        //}


    }
}
