using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class LogInfoController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_LogInfoData SysLogInfo { get; set; }

        public ActionResult Index()
        {
            ViewBag.LogTypeNames = new SelectList(GetEnumDicList<LogType>(), "Key", "Value");
            ViewBag.OptTypeNames = new SelectList(GetEnumDicList<OperateBtn>(), "Key", "Value");
            ViewBag.OptResultNames = new SelectList(GetEnumDicList<OperateRetType>(), "Key", "Value");

            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        [HttpPost]
        //[ResultLogFilter(OptType = OperateBtn.Search)]
        public JsonResult GetList(DgConModel dgCon)
        {
            dgCon.sort = dgCon.sort == "CrtTime" ? "OptTime" : dgCon.sort;

            var logType = Request["logType"] ?? "";
            var optType = Request["optType"] ?? "";
            var optResult = Request["optResult"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_LogInfo>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.OptModuleName.Contains(keyName));
            if (!string.IsNullOrWhiteSpace(logType)) exp = exp.And(c => c.LogTypeId == Convert.ToInt32(logType));
            if (!string.IsNullOrWhiteSpace(optType)) exp = exp.And(c => c.OptTypeId == Convert.ToInt32(optType));
            if (!string.IsNullOrWhiteSpace(optResult)) exp = exp.And(c => c.OptResultId == Convert.ToInt32(optResult));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysLogInfo.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Export)]
        public JsonResult ExportList(string comId, string logType, string optType, string optResult, string keyName)
        {
            var exp = ExpHelper.Create<SYS_LogInfo>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.OptModuleName.Contains(keyName));
            if (!string.IsNullOrWhiteSpace(logType)) exp = exp.And(c => c.LogTypeId == Convert.ToInt32(logType));
            if (!string.IsNullOrWhiteSpace(optType)) exp = exp.And(c => c.OptTypeId == Convert.ToInt32(optType));
            if (!string.IsNullOrWhiteSpace(optResult)) exp = exp.And(c => c.OptResultId == Convert.ToInt32(optResult));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(comId))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(comId));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retDt = SysLogInfo.GetModelsToDt(exp);

            var ret = new OperateModel
            {
                Msg = "导出成功！",
                Data = NpoiHelper.ExportToXls(retDt, "日志信息")
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
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
            var ret = SysLogInfo.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var dtlModel = SysLogInfo.GetModel(m => m.LogId == Guid.Parse(KeyId));

            return View(dtlModel);
        }
    }
}