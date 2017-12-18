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
using System.Web.Security;

namespace Dos.ORM.Web.Areas.MsManage.Controllers
{
    public class UserController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_UserData BusUser { get; set; }
        [Ninject.Inject]
        private IBUS_RoleData BusRole { get; set; }
        [Ninject.Inject]
        private IBUS_UserRoleData BusUserRoleRelation { get; set; }
        [Ninject.Inject]
        private IBUS_UserLaboratoryData BusUserLab { get; set; }
        [Ninject.Inject]
        private IBUS_ProjectData BusProj { get; set; }
        [Ninject.Inject]
        private IBUS_LaboratoryData BusLab { get; set; }
        [Ninject.Inject]
        private IBUS_ProjectLaboratoryData BusProjLabRelation { get; set; }

        //
        // GET: /MsManage/User/
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
            var account = Request["Account"] ?? "";

            var exp = ExpHelper.Create<BUS_User>(m => m.Account != "");
            if (!string.IsNullOrWhiteSpace(account))
                exp = exp.And(m => m.Account.Contains(account));


            var retList = BusUser.GetPagesForDg(dgCon, "CreateDate", exp);

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
                new BUS_User() { IsEnable = false } :
                BusUser.GetModel(m => m.ID == gKeyId);

            if (dtlModel.IsEnable == null)
                dtlModel.IsEnable = false;

            var allRoles = this.BusRole.GetModels(null);
            var myRole = this.BusUserRoleRelation.GetModel(p => p.AccountID == gKeyId);
            dtlModel.所属角色 = myRole == null ? Guid.Empty.ToString() : myRole.RoleID.ToString();
            allRoles.Insert(0, new BUS_Role() { ID = Guid.Empty, RoleName = "请选择..." });
            SelectList sltRole = new SelectList(allRoles, "ID", "RoleName", myRole == null ? Guid.Empty.ToString() : myRole.RoleID.ToString());
            ViewBag.RoleModel = sltRole;
            dtlModel.Password = EndeHelper.Decrypt(dtlModel.Password);

            return View(dtlModel);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(BUS_User model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var exp = OType == "add" ?
               ExpHelper.Create<BUS_User>(m => m.Account == model.Account) :
               ExpHelper.Create<BUS_User>(m => m.ID != gKeyId && m.Account == model.Account);
            var isExist = this.BusUser.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "账户名称已存在，不能保存！"
                });
            }
            #endregion

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                if (OType == "add")
                {
                    model.Password = EndeHelper.Encrypt(model.Password);
                    model.ID = Guid.NewGuid();
                    model.CreateDate = DateTime.Now;

                    gKeyId = model.ID;

                    ret = BusUser.InsertModel(model);
                }
                else
                {
                    var updateExp = ExpHelper.Create<BUS_User>(m => m.ID == gKeyId);
                    var oldModel = BusUser.GetModel(updateExp);

                    oldModel.Account = model.Account;
                    oldModel.Password = EndeHelper.Encrypt(model.Password);
                    oldModel.Mobile = model.Mobile;
                    oldModel.FullName = model.FullName;
                    oldModel.Job = model.Job;
                    oldModel.OrganName = model.OrganName;
                    oldModel.是否启用 = model.是否启用;

                    ret = BusUser.UpdateModel(oldModel, updateExp);
                }

                //账户角色关系
                this.BusUser.SaveRole(model.所属角色, gKeyId, trans);

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
        public JsonResult DeleteData(List<BUS_User> list)
        {
            var ret = BusUser.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 选择项目或试验室
        /// </summary>
        /// <returns></returns>
        public ActionResult Select()
        {
            System.Diagnostics.Debug.Write(KeyId);
            return View();
        }

        /// <summary>
        /// 获取项目试验室列表
        /// </summary>
        /// <param name="projName"></param>
        /// <param name="selectedIds"></param>
        /// <param name="isInit"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetProjLabModule(string projName, string selectedIds, bool isInit)
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = this.BusProj.GetModulesForUser(gKeyId, projName, selectedIds, isInit);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取已选择的项目试验室列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetProjLabSelected()
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = this.BusProj.GetModulesSelectedForUser(gKeyId);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据项目ID获取项目试验室列表
        /// </summary>
        /// <param name="newIds"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetProjLabFromId(string newIds)
        {
            var moduleList = this.BusProj.GetModulesForUserFromID(newIds);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存账户项目、试验室关系
        /// </summary>
        /// <param name="selectedIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveProjLab(string selectedIds)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                selectedIds = string.IsNullOrWhiteSpace(selectedIds) ? string.Empty : selectedIds.TrimEnd(',').TrimStart(',');

                var userlabModels = new List<BUS_UserLaboratory>();
                this.BusUserLab.DeleteModel(p => p.AccountID == gKeyId);
                if (!string.IsNullOrWhiteSpace(selectedIds))
                {
                    var ids = selectedIds.Split(',');

                    foreach (var item in ids)
                    {
                        var proj = this.BusProj.GetModel(p => p.ProjectID == Guid.Parse(item));
                        if (proj != null)
                        {
                            userlabModels.Add(new BUS_UserLaboratory
                            {
                                ID = Guid.NewGuid(),
                                AccountID = gKeyId,
                                TargetId = (Guid)proj.ProjectID,
                                TargetName = proj.ProjectName
                            });
                        }
                        else
                        {
                            var lab = this.BusLab.GetModel(p => p.OrganID == Guid.Parse(item));
                            var projlab = this.BusProjLabRelation.GetModel(p => p.OrganID == Guid.Parse(item));
                            userlabModels.Add(new BUS_UserLaboratory
                            {
                                ID = Guid.NewGuid(),
                                AccountID = gKeyId,
                                TargetId = (Guid)lab.OrganID,
                                TargetName = lab.OrganName,
                                ParentId = projlab.ProjectID
                            });
                        }
                    }
                    ret = this.BusUserLab.InsertModels(userlabModels);
                }
                else
                {
                    ret = new OperateModel() { Result = OperateRetType.Success, Msg = "数据保存成功！" };
                }


                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }

    }
}