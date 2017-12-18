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
    public class ModuleController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_ModuleData SysModule { get; set; }
        [Ninject.Inject]
        private ISYS_ModuleButtonRelationData SysModuleButtonRelation { get; set; }
        [Ninject.Inject]
        private ISYS_RoleModuleRelationData SysRoleModuleRelation { get; set; }
        [Ninject.Inject]
        private ISYS_ButtonData SysButton { get; set; }

        public ActionResult Index()
        {
            ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");

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
            var moduleType = Request["moduleType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_Module>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.ModuleName.Contains(keyName));

            if (!string.IsNullOrWhiteSpace(moduleType))
            {
                int iModuleType = Convert.ToInt32(moduleType);
                exp = exp.And(c => c.ModuleType == iModuleType);
            }

            var retList = SysModule.GetPagesForDg(dgCon, "SortNo", "asc", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Module> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {

                #region 删除模块按钮关系和角色模块关系
                var moduleIds = list.Select(item => item.ModuleId).ToList();

                var retDelModBtn = SysModuleButtonRelation.DeleteModelOther<SYS_ModuleButtonRelation>(m => m.ModuleId.In(moduleIds), trans);
                var retDelRolMod = SysRoleModuleRelation.DeleteModelOther<SYS_RoleModuleRelation>(m => m.ModuleId.In(moduleIds), trans);
                #endregion

                ret = SysModule.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            SYS_Module dtlModel;

            if (OType != "add")
            {
                dtlModel = SysModule.GetModel(m => m.ModuleId == gKeyId);

                ViewBag.keyId = gKeyId;
                ViewBag.parentId = dtlModel == null ? Guid.Empty : dtlModel.ParentId ?? Guid.Empty;
            }
            else
            {
                ViewBag.keyId = Guid.Empty;
                ViewBag.parentId = Guid.Empty;
                dtlModel = new SYS_Module();
            }

            ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");
            ViewBag.OperatePageTypes = new SelectList(GetEnumDicList<OperatePageType>(), "Key", "Value");

            return View(dtlModel);
        }

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModule(int moduleType, Guid parentId)
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = SysModule.GetModulesForModule(moduleType, gKeyId, parentId);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有按钮
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetButton()
        {
            var gKeyId = Guid.Parse(KeyId);

            //枚举按钮集合
            //var allBtns = EnumHelper.GetItemValueList<OperateBtn>().Select(item => new SYS_Button
            //{
            //    ButtonId = item.Key,
            //    ButtonName = item.Value
            //}).ToList();

            //数据表按钮集合
            var allBtns = SysButton.GetModels(c => c.Status == 1).ToList();

            var moduleList = SysButton.GetButtonsForModule(
                gKeyId, allBtns,
                SysModuleButtonRelation.GetModels(m => m.ModuleId == gKeyId).ToList());

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="buttonIds"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(string buttonIds, SYS_Module model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            model.ParentId = model.ParentId == Guid.Empty || model.ParentId == null ? null : model.ParentId;

            #region 检查数据是否存在
            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Module>(m => m.ParentId == model.ParentId && (m.ModuleName == model.ModuleName || (m.ModulePath == model.ModulePath && model.ModulePath != null))) :
               ExpHelper.Create<SYS_Module>(m => m.ModuleId != gKeyId && m.ParentId == model.ParentId && (m.ModuleName == model.ModuleName || (m.ModulePath == model.ModulePath && model.ModulePath != null)));
            var isExist = SysModule.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "该模块名称或模块路径已存在，不能保存！"
                });
            }
            #endregion

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                if (OType == "add")
                {
                    model.ModuleId = gKeyId;
                    model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                    ret = SysModule.InsertModel(model, trans);
                }
                else
                {
                    var updateExp = ExpHelper.Create<SYS_Module>(m => m.ModuleId == gKeyId);
                    var oldModel = SysModule.GetModel(updateExp);

                    oldModel.ParentId = model.ParentId;
                    oldModel.ModuleType = model.ModuleType;
                    oldModel.ModuleName = model.ModuleName;
                    oldModel.IconName = model.IconName;
                    oldModel.IconPath = model.IconPath;
                    oldModel.ModulePath = model.ModulePath;
                    oldModel.IsOperatePage = model.IsOperatePage;
                    oldModel.OperatePageType = model.OperatePageType;
                    oldModel.IsExpand = model.IsExpand;
                    oldModel.IsEnable = model.IsEnable;
                    oldModel.SortNo = model.SortNo;
                    oldModel.Desc = model.Desc;

                    oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                    oldModel.ModTime = DateTime.Now;

                    ret = SysModule.UpdateModel(oldModel, updateExp, trans);
                }

                //角色模块关系
                if (ret.Result == OperateRetType.Success)
                {
                    buttonIds = string.IsNullOrWhiteSpace(buttonIds) ? "" : buttonIds;

                    if (!string.IsNullOrWhiteSpace(buttonIds))
                    {
                        var moduleIdArr = buttonIds.Split(',');
                        var listRoleModule = (from item in moduleIdArr
                                              where item != "0"
                                              select new SYS_ModuleButtonRelation()
                                              {
                                                  MbId = Guid.NewGuid(),
                                                  ModuleId = gKeyId,
                                                  ButtonId = Guid.Parse(item),
                                                  CrtTime = DateTime.Now,
                                                  CrtOptId = MsSysUserModel.Operator.OperatorId
                                              }).ToList();
                        SysModuleButtonRelation.ModifyModuleButton(gKeyId, listRoleModule, trans);
                    }
                }

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }
    }
}