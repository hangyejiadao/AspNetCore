using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class LogReportController : MsSysController
    {
        [Ninject.Inject]
        private Iv_SYS_LogInfoRptData vSysLogInfoRpt { get; set; }

        public ActionResult Index()
        {
            ViewBag.LogTypeNames = new SelectList(GetEnumDicList<LogType>(), "Key", "Value");
            ViewBag.OptTypeNames = new SelectList(GetEnumDicList<OperateBtn>(), "Key", "Value");
            ViewBag.OptResultNames = new SelectList(GetEnumDicList<OperateRetType>(), "Key", "Value");

            return View();
        }

        [HttpPost]
        public JsonResult GetLogRpt()
        {
            var retList = new List<List<v_SYS_LogInfoRpt>>();
            var userIds = new List<Guid?>();

            var logRpt = vSysLogInfoRpt.GetModels();

            //统计一共有哪些管理员Id
            foreach (var item in logRpt)
            {
                if (!userIds.Contains(item.OperatorId))
                {
                    userIds.Add(item.OperatorId);
                }
            }

            //将相同管理员分为一组
            foreach (var item in userIds)
            {
                var retItem = new List<v_SYS_LogInfoRpt>();
                foreach (var rpt in logRpt.Where(m => m.OperatorId == item))
                {
                    retItem.Add(rpt);
                }
                retList.Add(retItem);
            }

            return Json(retList, JsonRequestBehavior.AllowGet);
        }
    }
}