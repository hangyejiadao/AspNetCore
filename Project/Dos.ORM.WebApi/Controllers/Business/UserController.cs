using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Security;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Model.Models;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 系统用户API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "user")]
    public class UserController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_UserData BusUser { get; set; }

        [Ninject.Inject]
        private IBUS_RoleData BusRole { get; set; }

        [Ninject.Inject]
        private IBUS_UserRoleData BusUserRole { get; set; }

        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return BusUser.GetList();
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return BusUser.GetOne(id);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [POST("add")]
        public OperateModel AddModel([FromBody]BUS_User model)
        {
            BUS_User user = new BUS_User();
            user.ID = Guid.NewGuid();
            user.Account = model.Account;
            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1");
            user.Mobile = model.Mobile;
            user.FullName = model.FullName;
            user.Job = model.Job;
            user.OrganName = model.OrganName;
            user.IsEnable = model.IsEnable;
            user.CreateDate = DateTime.Now;

            return BusUser.InsertModel(user);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [POST("login")]
        public LoginModel LoginVal([FromBody]BUS_User model)
        {
            LoginModel loginModel = null;
            if (string.IsNullOrWhiteSpace(model.Account))
            {
                loginModel = new LoginModel
                {
                    Result = OperateRetType.LoginInFail,
                    Msg = "无此账户，验证失败！"                  
                };
            }
            else if (string.IsNullOrWhiteSpace(model.Password))
            {
                loginModel = new LoginModel
                {
                    Result = OperateRetType.LoginInFail,
                    Msg = "密码错误，验证失败！"                  
                };            
            }
            else    
            {
                model.Password = EndeHelper.Encrypt(model.Password);
                var user = BusUser.GetModel(m=>m.Account==model.Account.ToLower() && m.Password==model.Password);               
                var userRole = BusUserRole.GetModel(m => m.AccountID == user.ID);
                var roleName = BusRole.GetModel(m => m.ID == userRole.RoleID);
                if (user != null)
                {
                    if (user.IsEnable == true)
                    {
                        loginModel = new LoginModel
                        {
                            Result = OperateRetType.LoginInSuccess,
                            Msg = "账户验证成功！",
                            User = user,
                            Role = roleName,
                            UserRole=userRole
                        };
                    }
                    else
                    {
                        loginModel = new LoginModel
                         {
                             Result = OperateRetType.LoginInFail,
                             Msg = "登录失败，该账户已禁用，请联系管理员！"                           
                         };
                    }
                }
                else
                {
                    loginModel = new LoginModel
                    {
                        Result = OperateRetType.LoginInFail,
                        Msg = "登录失败！"
                    };
                }
            }

            return loginModel;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [POST("editpwd")]
        public OperateModel UpdatePwd(PostPwdModel model)
        {
            var updateRet = false;
            string updateMsg = "";
                      
            try
            {
                var updateExp = ExpHelper.Create<BUS_User>(m => m.ID == model.userId);
                updateRet = BusUser.UpdateModel("Password", model.newPwd, updateExp).Result == OperateRetType.Success;
                updateMsg = updateRet ? "密码修改成功！" : "密码修改失败，请稍后再试！";
            }
            catch
            {
                updateRet = false;
                updateMsg ="密码修改失败！";
            }

            var operRet = new OperateModel
            {
                Result = updateRet ? OperateRetType.Success : OperateRetType.Fail,
                Msg = updateMsg
            };

            return operRet;
        }


    }
}