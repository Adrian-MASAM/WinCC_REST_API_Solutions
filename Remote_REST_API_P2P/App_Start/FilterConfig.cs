using System.Web;
using System.Web.Mvc;

namespace Remote_REST_API_P2P
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
