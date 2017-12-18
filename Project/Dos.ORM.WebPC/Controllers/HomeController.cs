using System.Web.Mvc;

namespace Dos.ORM.WebPC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();

            //区域重定向
            //return RedirectToRoute(new { area = "MsSys", controller = "Login", action = "Index" });
            return RedirectToAction("Index", "Login", new { area = "MsSys" });
        }
    }
}