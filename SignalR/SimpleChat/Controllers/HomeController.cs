using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class HomeController : Controller
    {
        // using genrated proxy of js
        public ActionResult Index()
        {
            return View();
        }

        // using custom proxy 
        public ActionResult Index2()
        {
            return View();
        }
    }
}