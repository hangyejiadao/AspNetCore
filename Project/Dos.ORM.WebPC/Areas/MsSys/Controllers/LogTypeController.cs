using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.WebPC.Controllers.Base;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class LogTypeController : SubBaseController
    {
        //[Ninject.Inject]
        //private ISYS_LogTypeData SysLogType { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(DgConModel dgCon)
        {
            //var keyName = Request["keyName"] ?? "";

            //var exp = ExpHelper.Create<SYS_LogType>(c => c.Status == 1);
            //if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.LogTypeName.Contains(keyName));

            //var retList = SysLogType.GetPagesForDg(dgCon, "CrtTime", exp);

            //return Json(retList, JsonRequestBehavior.AllowGet);
            return null;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteData(List<SYS_LogType> list)
        {
            //var ret = SysLogType.DeleteModels(list);

            //return Json(ret, JsonRequestBehavior.AllowGet);

            return null;
        }

        public ActionResult Detail()
        {
            //SYS_LogType dtlModel;

            ////操作类型（add、modify、view）和数据Id
            //string strOType = Request["oType"], strKeyId = Request["keyId"];
            //ViewBag.oType = strOType;
            //ViewBag.keyId = strKeyId;

            //if (strOType != "add")
            //{
            //    dtlModel = strOType != "add" ? SysLogType.GetModel(m => m.LogTypeId == Convert.ToInt32(strKeyId)) : null;
            //}
            //else
            //{
            //    dtlModel = new SYS_LogType();
            //}

            //return View(dtlModel);
            return null;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="oType"></param>
        /// <param name="keyId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveData(string oType, string keyId, SYS_LogType model)
        {
            //var iKeyId = oType != "add" ? Convert.ToInt32(keyId) : 0;

            //OperateModel ret;

            //#region 检查数据是否存在
            //var exp = oType == "add" ?
            //   ExpHelper.Create<SYS_LogType>(m => m.LogTypeName == model.LogTypeName) :
            //   ExpHelper.Create<SYS_LogType>(m => m.LogTypeId != iKeyId && m.LogTypeName == model.LogTypeName);
            //var isExist = SysLogType.IsExistEntity(exp);

            //if (isExist)
            //{
            //    return Json(new OperateModel
            //    {
            //        Result = OperateRetType.Fail,
            //        Msg = "类型名称已存在，不能保存！"
            //    }, JsonRequestBehavior.AllowGet);
            //}
            //#endregion

            //if (oType == "add")
            //{
            //    model.CrtOptId = LoginUser.User.ID;

            //    ret = SysLogType.InsertModel(model);
            //}
            //else
            //{
            //    var updateExp = ExpHelper.Create<SYS_LogType>(m => m.LogTypeId == iKeyId);
            //    var oldModel = SysLogType.GetModel(m => m.LogTypeId == iKeyId);

            //    oldModel.LogTypeName = model.LogTypeName;
            //    oldModel.Desc = model.Desc;

            //    oldModel.ModOptId = LoginUser.User.ID;
            //    oldModel.ModTime = DateTime.Now;

            //    ret = SysLogType.UpdateModel(oldModel, updateExp);
            //}

            //return JsonSubmit(ret);
            return null;
        }
    }
}