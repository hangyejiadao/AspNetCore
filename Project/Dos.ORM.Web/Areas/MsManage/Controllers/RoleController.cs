using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dos.ORM.Web.Areas.MsManage.Controllers
{
    public class RoleController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_RoleData BusRole { get; set; }
        [Ninject.Inject]
        private IBUS_ModuleData BusModule { get; set; }
        [Ninject.Inject]
        private IBUS_RoleModuleData BusRoleModuleRelation { get; set; }

        //
        // GET: /MsManage/Role/
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
        [ResultLogFilter(OptType = OperateBtn.Search)]
        public JsonResult GetList(DgConModel dgCon)
        {
            var rolename = Request["RoleName"] ?? "";

            var exp = ExpHelper.Create<BUS_Role>(m => m.RoleName != "");
            if (!string.IsNullOrWhiteSpace(rolename))
                exp = exp.And(m => m.RoleName.Contains(rolename));


            var retList = BusRole.GetPagesForDg(dgCon, "Order", "asc", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new BUS_Role() :
                this.BusRole.GetModel(m => m.ID == gKeyId);

            return View(dtlModel);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="moduleIds"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(string moduleIds, BUS_Role model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在

            var exp = OType == "add" ?
               ExpHelper.Create<BUS_Role>(m => m.RoleName == model.RoleName) :
               ExpHelper.Create<BUS_Role>(m => m.ID != gKeyId && m.RoleName == model.RoleName);
            var isExist = this.BusRole.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "角色名称已存在，不能保存！"
                });
            }
            #endregion

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                if (OType == "add")
                {
                    model.ID = Guid.NewGuid();

                    gKeyId = model.ID;

                    ret = this.BusRole.InsertModel(model);
                }
                else
                {
                    var updateExp = ExpHelper.Create<BUS_Role>(m => m.ID == gKeyId);
                    var oldModel = this.BusRole.GetModel(updateExp);

                    oldModel.RoleName = model.RoleName;
                    oldModel.Order = model.Order;
                    oldModel.Note = model.Note;

                    ret = this.BusRole.UpdateModel(oldModel, updateExp);
                }

                //角色模块关系
                if (ret.Result == OperateRetType.Success)
                {
                    moduleIds = string.IsNullOrWhiteSpace(moduleIds) ? Guid.Empty.ToString() : moduleIds.TrimEnd(',').TrimStart(',');
                    var moduleIdArr = moduleIds.Split(',');
                    var listRoleModule = (from item in moduleIdArr
                                          where Guid.Parse(item) != Guid.Empty
                                          select new BUS_RoleModule
                                          {
                                              ID = Guid.NewGuid(),
                                              RoleID = gKeyId,
                                              ModuleID = Guid.Parse(item)
                                          }).ToList();
                    this.BusRoleModuleRelation.ModifyRoleModule(gKeyId, listRoleModule, trans);
                }

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_Role> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                #region 删除模块 角色关系
                var roleIds = list.Select(p => p.ID).ToList();

                var retDelModBtn = this.BusRoleModuleRelation.DeleteModelOther<BUS_RoleModule>(m => m.RoleID.In(roleIds), trans);
                #endregion

                ret = this.BusRole.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModule()
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = this.BusModule.GetModulesForRole(gKeyId, this.BusRoleModuleRelation.GetModels(p => p.RoleID == gKeyId).ToList());

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }
    }
}