using System.Web.Mvc;

namespace Project_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Preferences()
        {
            return View();
        }
    }
}