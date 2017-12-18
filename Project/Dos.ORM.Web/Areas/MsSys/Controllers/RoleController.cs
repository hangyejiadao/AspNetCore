using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class RoleController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_RoleData SysRole { get; set; }
        [Ninject.Inject]
        private ISYS_ModuleData SysModule { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorRoleRelationData SysOperatorRoleRelation { get; set; }
        [Ninject.Inject]
        private ISYS_RoleModuleRelationData SysRoleModuleRelation { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorRoleRelationData SysOperatorRoleRelationData { get; set; }

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
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_Role>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.RoleName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysRole.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Role> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {

                #region 删除管理员角色、角色模块关系
                var roleIds = list.Select(item => item.RoleId).ToList();

                SysOperatorRoleRelation.DeleteModelOther<SYS_OperatorRoleRelation>(m => m.RoleId.In(roleIds), trans);
                SysRoleModuleRelation.DeleteModelOther<SYS_RoleModuleRelation>(m => m.RoleId.In(roleIds), trans);
                #endregion

                ret = SysRole.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 选择角色人员
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectOperator()
        {
            return View();
        }

        /// <summary>
        /// 根据角色Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonResult GetRoleOperators(Guid? comId, Guid roleId)
        {
            var ret = SysRole.GetRoleOperators(roleId, comId == null || comId == Guid.Empty ? MsSysUserModel.CompanyId : comId);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存角色下的人员（关系）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="opers"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRoleOperators(Guid roleId, List<SYS_Operator> opers)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                SysOperatorRoleRelationData.DeleteModel(m => m.RoleId == roleId, trans);

                var insertList = new List<SYS_OperatorRoleRelation>();
                foreach (var item in opers)
                {
                    insertList.Add(new SYS_OperatorRoleRelation
                    {
                        OrId = Guid.NewGuid(),
                        RoleId = roleId,
                        OperatorId = item.OperatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = MsSysUserModel.Operator.OperatorId
                    });
                }
                ret = SysOperatorRoleRelationData.InsertModels(insertList, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Role { RoleId = gKeyId } :
                SysRole.GetModel(m => m.RoleId == gKeyId);

            ViewBag.keyId = OType == "add" ? Guid.Empty : gKeyId;
            ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");

            return View(dtlModel);
        }

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModule(int moduleType)
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = SysModule.GetModulesForRole(
                moduleType,
                gKeyId,
                SysRoleModuleRelation.GetModels(m => m.RoleId == gKeyId).ToList());

            return Json(moduleList, JsonRequestBehavior.AllowGet);
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
        public JsonResult SaveData(string moduleIds, SYS_Role model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Role>(m => m.CompanyId == comId && m.RoleName == model.RoleName) :
               ExpHelper.Create<SYS_Role>(m => m.RoleId != gKeyId && m.CompanyId == comId && m.RoleName == model.RoleName);
            var isExist = SysRole.IsExistEntity(exp);

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
                    model.RoleId = gKeyId;
                    model.CompanyId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;
                    model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                    ret = SysRole.InsertModel(model, trans);
                }
                else
                {
                    var updateExp = ExpHelper.Create<SYS_Role>(m => m.RoleId == gKeyId);
                    var oldModel = SysRole.GetModel(updateExp);

                    if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                    oldModel.RoleName = model.RoleName;
                    oldModel.IsEnable = model.IsEnable;
                    oldModel.Desc = model.Desc;

                    oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                    oldModel.ModTime = DateTime.Now;

                    ret = SysRole.UpdateModel(oldModel, updateExp, trans);
                }

                //角色模块关系
                if (ret.Result == OperateRetType.Success)
                {
                    moduleIds = string.IsNullOrWhiteSpace(moduleIds) ? Guid.Empty.ToString() : moduleIds;

                    var moduleIdArr = moduleIds.Split(',');
                    var listRoleModule = (from item in moduleIdArr
                                          where Guid.Parse(item) != Guid.Empty
                                          select new SYS_RoleModuleRelation
                                          {
                                              RmId = Guid.NewGuid(),
                                              RoleId = gKeyId,
                                              ModuleId = Guid.Parse(item),
                                              CrtTime = DateTime.Now,
                                              CrtOptId = MsSysUserModel.Operator.OperatorId
                                          }).ToList();
                    SysRoleModuleRelation.ModifyRoleModule(gKeyId, listRoleModule, trans);
                }

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }
    }
}