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
using Dos.ORM.Web.App_Api.Base;

namespace Dos.ORM.Web.App_Api.Business
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
                var user = BusUser.GetModel(m=>m.Account==model.Account && m.Password==model.Password);               
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
    }
}