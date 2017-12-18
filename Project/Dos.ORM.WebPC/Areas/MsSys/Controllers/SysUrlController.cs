using Dos.ORM.WebPC.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class SysUrlController : SubBaseController
    {
       

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UrlIndex1(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult UrlIndex2(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult UrlIndex3(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult UrlIndex4(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }
        public ActionResult UrlIndex5(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult UrlIndex6(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult UrlIndex7(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }
        public ActionResult UrlMsgIndex()
        {
            return View();
        }


       
    }
}