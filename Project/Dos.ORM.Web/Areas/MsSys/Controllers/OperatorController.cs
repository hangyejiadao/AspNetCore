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
    public class OperatorController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_OperatorData SysOperator { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorRoleRelationData SysOperatorRoleRelation { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorDepartmentRelationData SysOperatorDepartmentRelation { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorPostRelationData SysOperatorPostRelation { get; set; }
        [Ninject.Inject]
        private ISYS_DepartmentData SysDepartment { get; set; }
        [Ninject.Inject]
        private ISYS_RoleData SysRole { get; set; }
        [Ninject.Inject]
        private ISYS_PostData SysPost { get; set; }

        public ActionResult Index()
        {
            //账户类型
            var operTypes = GetEnumDicList<OperatorType>();
            if (MsSysUserModel.AccountType > 1)
            {
                //去除超级管理员一项
                operTypes.Remove(1);
            }
            ViewBag.OperatorTypes = new SelectList(operTypes, "Key", "Value");

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
            var accountType = Request["accountType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_Operator>(c => c.Status == 1 && c.Account != "admin");
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.Account.Contains(keyName) || m.Nickname.Contains(keyName) || m.Realname.Contains(keyName));

            if (!string.IsNullOrWhiteSpace(accountType))
            {
                int iAccountType = Convert.ToInt32(accountType);
                exp = exp.And(c => c.AccountType == iAccountType);
            }

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysOperator.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导出人员
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="accountType"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Export)]
        public JsonResult ExportList(string comId, string accountType, string keyName)
        {
            var exp = ExpHelper.Create<SYS_Operator>(c => c.Status == 1 && c.Account != "admin");
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.Account.Contains(keyName) || m.Nickname.Contains(keyName) || m.Realname.Contains(keyName));

            if (!string.IsNullOrWhiteSpace(accountType))
            {
                int iAccountType = Convert.ToInt32(accountType);
                exp = exp.And(c => c.AccountType == iAccountType);
            }

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(comId))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(comId));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retDt = SysOperator.GetModelsToDt(exp);

            var ret = new OperateModel
            {
                Msg = "导出成功！",
                Data = NpoiHelper.ExportToXls(retDt, "管理员信息")
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Operator> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                #region 删除管理员角色关系和管理员部门关系

                var operIds = list.Select(item => item.OperatorId).ToList();

                var retDelModBtn = SysOperatorRoleRelation.DeleteModelOther<SYS_OperatorRoleRelation>(m => m.OperatorId.In(operIds), trans);
                var retDelRolMod = SysOperatorDepartmentRelation.DeleteModelOther<SYS_OperatorDepartmentRelation>(m => m.OperatorId.In(operIds), trans);
                var retDelPosMod = SysOperatorPostRelation.DeleteModelOther<SYS_OperatorPostRelation>(m => m.OperatorId.In(operIds), trans);

                #endregion

                ret = SysOperator.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Operator { OperatorId = gKeyId } :
                SysOperator.GetModel(m => m.OperatorId == gKeyId);

            //账户类型
            var operTypes = GetEnumDicList<OperatorType>();
            if (MsSysUserModel.AccountType > 1)
            {
                //去除超级管理员一项
                operTypes.Remove(1);
            }
            ViewBag.OperatorTypes = new SelectList(operTypes, "Key", "Value");

            return View(dtlModel);
        }

        /// <summary>
        /// 获取所有的部门信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDepartments(DgConModel dgCon)
        {
            var exp = ExpHelper.Create<SYS_Department>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == MsSysUserModel.CompanyId);
            var retList = SysDepartment.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有的角色信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetRoles(DgConModel dgCon)
        {
            var exp = ExpHelper.Create<SYS_Role>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == MsSysUserModel.CompanyId);
            var retList = SysRole.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有的岗位信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetPosts(DgConModel dgCon)
        {
            var exp = ExpHelper.Create<SYS_Post>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == MsSysUserModel.CompanyId);
            var retList = SysPost.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取管理员的所有部门、角色和岗位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDepRolePosts()
        {
            var gKeyId = Guid.Parse(KeyId);

            var depRes = SysOperatorDepartmentRelation.GetModels(m => m.OperatorId == gKeyId);
            var roleRes = SysOperatorRoleRelation.GetModels(m => m.OperatorId == gKeyId);
            var postRes = SysOperatorPostRelation.GetModels(m => m.OperatorId == gKeyId);

            List<string> depIds = new List<string>(),
                roleIds = new List<string>(),
                postIds = new List<string>();

            depIds.AddRange(depRes.Select(item => item.DepartmentId.ToString()));
            roleIds.AddRange(roleRes.Select(item => item.RoleId.ToString()));
            postIds.AddRange(postRes.Select(item => item.PostId.ToString()));

            var ret = new
            {
                dep = string.Join(",", depIds.ToArray()),
                role = string.Join(",", roleIds.ToArray()),
                post = string.Join(",", postIds.ToArray())
            };

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据公司Id获取其下的所有部门、角色和岗位
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDepsRolPoss(Guid comId)
        {
            var dgCon = new DgConModel();

            var expDep = ExpHelper.Create<SYS_Department>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == comId);
            var retListDep = SysDepartment.GetPagesForDg(dgCon, "CrtTime", expDep);

            var expRole = ExpHelper.Create<SYS_Role>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == comId);
            var retListRole = SysRole.GetPagesForDg(dgCon, "CrtTime", expRole);

            var expPost = ExpHelper.Create<SYS_Post>(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == comId);
            var retListPost = SysPost.GetPagesForDg(dgCon, "CrtTime", expPost);

            return Json(new { dep = retListDep, role = retListRole, post = retListPost }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="depIds"></param>
        /// <param name="roleIds"></param>
        /// <param name="postIds"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(string depIds, string roleIds, string postIds, SYS_Operator model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Operator>(m => m.CompanyId == comId && m.Account == model.Account) :
               ExpHelper.Create<SYS_Operator>(m => m.OperatorId != gKeyId && m.CompanyId == comId && m.Account == model.Account);
            var isExist = SysOperator.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "登录账户已存在，不能保存！"
                });
            }
            #endregion

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                if (OType == "add")
                {
                    model.OperatorId = gKeyId;
                    model.CompanyId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;
                    model.Pwd = EndeHelper.Encrypt("123456");
                    model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                    ret = SysOperator.InsertModel(model, trans);
                }
                else
                {
                    var updateExp = ExpHelper.Create<SYS_Operator>(m => m.OperatorId == gKeyId);
                    var oldModel = SysOperator.GetModel(updateExp);

                    if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                    oldModel.AccountType = model.AccountType;
                    oldModel.PhotoPath = model.PhotoPath;
                    oldModel.PhotoWidth = model.PhotoWidth;
                    oldModel.PhotoHeight = model.PhotoHeight;
                    oldModel.Nickname = model.Nickname;
                    oldModel.Realname = model.Realname;
                    oldModel.WeChat = model.WeChat;
                    oldModel.Microblog = model.Microblog;
                    oldModel.Mobile = model.Mobile;
                    oldModel.Tel = model.Tel;
                    oldModel.QQ = model.QQ;
                    oldModel.Email = model.Email;
                    oldModel.ProvinceId = model.ProvinceId;
                    oldModel.CityId = model.CityId;
                    oldModel.CountyId = model.CountyId;
                    oldModel.TownId = model.TownId;
                    oldModel.Address = model.Address;
                    oldModel.IsEnable = model.IsEnable;
                    oldModel.DtlInfo = model.DtlInfo;

                    oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                    oldModel.ModTime = DateTime.Now;

                    ret = SysOperator.UpdateModel(oldModel, updateExp, trans);
                }

                //删除并添加部门、角色关系
                SysOperator.SaveDepRoleList(depIds, roleIds, postIds, gKeyId, MsSysUserModel.Operator.OperatorId, trans);

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdatePwd()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateOperatorPwd(string oldPwd, string newPwd)
        {
            var updateRet = false;
            string updateMsg;

            var userModel = MsSysUserModel.Operator;

            if (EndeHelper.Encrypt(oldPwd) != userModel.Pwd)
            {
                updateMsg = "原始密码输入错误！";
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_Operator>(m => m.OperatorId == userModel.OperatorId);
                userModel.Pwd = EndeHelper.Encrypt(newPwd);

                updateRet = SysOperator.UpdateModel("Pwd", userModel.Pwd, updateExp).Result == OperateRetType.Success;
                updateMsg = updateRet ? "密码修改成功！" : "密码修改失败，请稍后再试！";
            }

            var operRet = new OperateModel
            {
                Result = updateRet ? OperateRetType.Success : OperateRetType.Fail,
                Msg = updateMsg
            };

            return Json(operRet, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 设置主题
        /// </summary>
        /// <param name="themeName">主题名称</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SetTheme(string themeName)
        {
            var userModel = MsSysUserModel.Operator;

            var updateExp = ExpHelper.Create<SYS_Operator>(m => m.OperatorId == userModel.OperatorId);
            userModel.ThemeName = themeName;

            var updateRet = SysOperator.UpdateModel("ThemeName", userModel.ThemeName, updateExp).Result == OperateRetType.Success;
            var updateMsg = updateRet ? "主题设置成功！" : "主题设置失败，请稍后再试！";

            //if (updateRet)
            //{
            //    CookieHelper.Set("MsSysTheme", themeName);
            //}

            var operRet = new OperateModel
            {
                Result = updateRet ? OperateRetType.Success : OperateRetType.Fail,
                Msg = updateMsg
            };

            return Json(operRet, JsonRequestBehavior.AllowGet);
        }
    }
}