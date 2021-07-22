using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WinCC_REST_API.Global;
using WinCC_REST_API.OPCUA;

namespace WinCC_REST_API_P2P
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

            //globale Werte initialisieren --> URLs aus config File lesen
            Init init = new Init();
            init.Initialize();

            OPCUA_ConditionClient opc = new OPCUA_ConditionClient();//Konstruktor aufrufen
            opc.InitializeLogServer();
            opc.InitializeEventNotification();
            opc.InitializeLogs();
        }
    }
}
