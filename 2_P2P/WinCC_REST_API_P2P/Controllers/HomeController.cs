using System.Web.Mvc;

namespace WinCC_REST_API_P2P.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
