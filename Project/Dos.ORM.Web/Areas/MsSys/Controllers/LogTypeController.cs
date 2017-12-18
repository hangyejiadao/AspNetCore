using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.Controllers.Base;
using Newtonsoft.Json.Linq;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class LogTypeController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_LogTypeData SysLogType { get; set; }

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
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_LogType>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.LogTypeName.Contains(keyName));

            var retList = SysLogType.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        #region 获取WebApi分页实例

        [HttpPost]
        public JsonResult GetListWithApi(DgConModel dgCon)
        {
            var keyName = Request["keyName"] ?? "";

            var queryCon = new JObject(
                    new JProperty("LogTypeId", "登录登出"),
                    new JProperty("LogTypeName", "登录登出"),
                    new JProperty("LogTypeName", "登录登出")
                );

            var retModel = GetWabApiPageListForEasyDg(
                "http://localhost:3002/cdkx/api/test/get/list1",//查询条件
                dgCon,//easyui datagrid分页条件
                queryCon);//数据查询条件

            return Json(retModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取WebApi接口提供的分页数据（EasyUI datagrid控件所用）
        /// </summary>
        /// <param name="strApiAddress">WebApi接口地址</param>
        /// <param name="dgCon">easyui datagrid控件默认分页参数实体</param>
        /// <param name="queryCon">数据查询条件</param>
        /// <returns></returns>
        public DgListModel GetWabApiPageListForEasyDg(string strApiAddress, DgConModel dgCon, JObject queryCon)
        {
            //返回EasyUI Datagrid所需数据实体对象
            DgListModel retModel = null;

            #region 组合条件
            JObject conObj = null;
            if (queryCon == null)
            {
                conObj = new JObject
                {
                    new JProperty("PageIndex", dgCon.page),
                    new JProperty("PageSize", dgCon.rows)
                };
            }
            else
            {
                conObj = queryCon;
                conObj.Add(new JProperty("PageIndex", dgCon.page));
                conObj.Add(new JProperty("PageSize", dgCon.rows));
            }
            #endregion

            var queryData = HttpClientHelper.Post<OperateModel>(strApiAddress, JsonHelper.ObjectToJson(conObj));

            if (queryData.Result == OperateRetType.Success)
            {
                var retObj = JsonHelper.JsonToObject<ApiPageRetModel>(JsonHelper.ObjectToJson(queryData.Data));
                retModel = new DgListModel(retObj.List, retObj.TotalCount);
            }

            return retModel;
        }

        #endregion

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteData(List<SYS_LogType> list)
        {
            var ret = SysLogType.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            SYS_LogType dtlModel;

            //操作类型（add、modify、view）和数据Id
            string strOType = Request["oType"], strKeyId = Request["keyId"];
            ViewBag.oType = strOType;
            ViewBag.keyId = strKeyId;

            if (strOType != "add")
            {
                dtlModel = strOType != "add" ? SysLogType.GetModel(m => m.LogTypeId == Convert.ToInt32(strKeyId)) : null;
            }
            else
            {
                dtlModel = new SYS_LogType();
            }

            return View(dtlModel);
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
            var iKeyId = oType != "add" ? Convert.ToInt32(keyId) : 0;

            OperateModel ret;

            #region 检查数据是否存在
            var exp = oType == "add" ?
               ExpHelper.Create<SYS_LogType>(m => m.LogTypeName == model.LogTypeName) :
               ExpHelper.Create<SYS_LogType>(m => m.LogTypeId != iKeyId && m.LogTypeName == model.LogTypeName);
            var isExist = SysLogType.IsExistEntity(exp);

            if (isExist)
            {
                return Json(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "类型名称已存在，不能保存！"
                }, JsonRequestBehavior.AllowGet);
            }
            #endregion

            if (oType == "add")
            {
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = SysLogType.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_LogType>(m => m.LogTypeId == iKeyId);
                var oldModel = SysLogType.GetModel(m => m.LogTypeId == iKeyId);

                oldModel.LogTypeName = model.LogTypeName;
                oldModel.Desc = model.Desc;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = SysLogType.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}