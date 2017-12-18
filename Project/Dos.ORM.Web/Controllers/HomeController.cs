using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.Model.System;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Dos.ORM.Web.Controllers
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