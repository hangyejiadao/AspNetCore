using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.WebPC.App_Common.Filter;
using Dos.ORM.WebPC.Controllers.Base;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class LogInfoController : SubBaseController
    {
        //[Ninject.Inject]
        //private ISYS_LogInfoData SysLogInfo { get; set; }

        public ActionResult Index()
        {
            ViewBag.LogTypeNames = new SelectList(GetEnumDicList<LogType>(), "Key", "Value");
            ViewBag.OptTypeNames = new SelectList(GetEnumDicList<OperateBtn>(), "Key", "Value");
            ViewBag.OptResultNames = new SelectList(GetEnumDicList<OperateRetType>(), "Key", "Value");

            return View();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        //[ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_LogInfo> list)
        {
            //var ret = SysLogInfo.DeleteModels(list);

            //return Json(ret, JsonRequestBehavior.AllowGet);

            return null;
        }

        public ActionResult Detail()
        {
            //var dtlModel = SysLogInfo.GetModel(m => m.LogId == Guid.Parse(KeyId));

            //return View(dtlModel);

            return null;
        }
    }
}