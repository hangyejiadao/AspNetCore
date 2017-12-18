using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Auth;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.App_Common.Other;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class LoginController : BaseController
    {
        [Ninject.Inject]
        private ISYS_OperatorData SysOperator { get; set; }
        [Ninject.Inject]
        private ISYS_CompanyData SysCompany { get; set; }
        [Ninject.Inject]
        private ISYS_DepartmentData SysDepartment { get; set; }
        [Ninject.Inject]
        private ISYS_RoleData SysRole { get; set; }
        [Ninject.Inject]
        private Iv_SYS_ModuleData vSysModule { get; set; }
        [Ninject.Inject]
        private Iv_SYS_ButtonData vSysButton { get; set; }

        public ActionResult Index()
        {
            MsSysUserAuth.Clear();
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            var validateCode = new ValidateCode();
            string code = validateCode.CreateVerifyCode(4);
            Session["ValidateCode"] = code.ToUpper();
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="operatorModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(LogType = LogType.LoginInOut, OptType = OperateBtn.LoginIn)]
        public JsonResult CheckLogin(SYS_Operator operatorModel)
        {
            OperateModel retModel;

            if (Session["ValidateCode"].ToString().ToLower() != operatorModel.DtlInfo.ToLower())
            {
                retModel = new OperateModel { Result = OperateRetType.LoginInFail, Msg = "验证码输入错误！" };
            }
            else
            {
                operatorModel.Pwd = EndeHelper.Encrypt(operatorModel.Pwd);

                var operModel = SysOperator.GetModel(m => m.Account == operatorModel.Account && m.Pwd == operatorModel.Pwd);

                if (operModel == null)
                {
                    retModel = new OperateModel { Result = OperateRetType.LoginInFail, Msg = "登录失败，请检查登录账户或密码是否正确！" };
                }
                else
                {
                    if (operModel.IsEnable == 1)
                    {
                        #region 用户、角色、模块和按钮信息
                        var userCompanyModel = operModel.CompanyId != null ? SysCompany.GetModel(m => m.CompanyId == operModel.CompanyId) : null;
                        var userDepartmentModels = SysDepartment.GetUserDepartments(operModel.OperatorId);
                        var userRoleModels = SysRole.GetUserRoles(operModel.OperatorId);

                        List<v_SYS_Module> userModuleModels = vSysModule.GetModels(m => m.IsEnable == 1, vSysModule.GetOrderByClip("SortNo", "asc"));
                        if (operModel.AccountType == 3)
                        {
                            if (userRoleModels != null && userRoleModels.Where(m => m.IsEnable == 1).ToList().Count > 0)
                            {
                                var modulesByRoles = new List<v_SYS_Module>();
                                foreach (var item in userRoleModels.Where(m => m.IsEnable == 1).ToList())
                                {
                                    var roleModules = userModuleModels.Where(m => m.RoleId == item.RoleId).ToList();
                                    if (roleModules.Count > 0)
                                    {
                                        modulesByRoles.AddRange(roleModules);
                                    }
                                }
                                userModuleModels = modulesByRoles;
                            }
                            else
                            {
                                userModuleModels = null;
                            }
                        }

                        List<v_SYS_Button> userButtonModels = vSysButton.GetModels();
                        if (operModel.AccountType == 3)
                        {
                            if (userModuleModels != null && userModuleModels.Count > 0)
                            {
                                userButtonModels =
                                    (from itemBtn in userButtonModels
                                     where userButtonModels.Any(itemMod => itemBtn.ModuleId == itemMod.ModuleId)
                                     select itemBtn).ToList();
                            }
                            else
                            {
                                userButtonModels = null;
                            }
                        }

                        var msSysUserModel = new MsSysUserModel
                        {
                            Company = userCompanyModel,
                            Departments = userDepartmentModels,
                            Operator = operModel,
                            Roles = userRoleModels,
                            ModuleList = userModuleModels,
                            ButtonList = userButtonModels
                        };

                        //存储用户相关信息
                        MsSysUserAuth.Set(msSysUserModel);
                        #endregion

                        retModel = new OperateModel { Result = OperateRetType.LoginInSuccess, Msg = "登录成功！" };
                    }
                    else
                    {
                        retModel = new OperateModel { Result = OperateRetType.LoginInFail, Msg = "登录失败，该账户已禁用，请联系管理员！" };
                    }
                }
            }

            return JsonSubmit(retModel);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        [ResultLogFilter(ExecType = 3, LogType = LogType.LoginInOut, OptType = OperateBtn.LoginOut)]
        public ActionResult LoginOut()
        {
            MsSysUserAuth.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}