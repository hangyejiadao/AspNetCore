using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.WebPC.App_Common.Auth;
using Dos.ORM.WebPC.App_Common.Filter;
using Dos.ORM.WebPC.App_Common.Other;
using Dos.ORM.WebPC.Controllers.Base;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using Dos.ORM.Model.Business;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class LoginController : BaseController
    {
      
        public ActionResult Index()
        {
            LoginUserAuth.Clear();

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
        public JsonResult CheckLogin(string Account, string Password, string ValidateCode)
        {                   
            LoginModel loginModel = null;

            if (Session["ValidateCode"].ToString().ToLower() != ValidateCode.ToLower())
            {
                loginModel = new LoginModel
                {
                    Result = OperateRetType.LoginInFail,
                    Msg = "验证码输入错误！"
                };
            }
            else
            {
                loginModel = HttpClientHelper.Post<LoginModel>(WebAPIHelper.CheckLoginAPI, "{'Account':'" + Account + "','Password':'" + Password + "'}");

                if (loginModel == null)
                {
                    loginModel = new LoginModel
                    {
                        Result = OperateRetType.LoginInFail,
                        Msg = "账户验证失败！"
                    };
                }
                else
                {
                    #region 用户、角色                 
                    var LoginUser = new LoginUserModel
                    {
                        User = loginModel.User,
                        Role = loginModel.Role,
                        UserRole = loginModel.UserRole
                    };

                    //存储用户相关信息
                    LoginUserAuth.Set(LoginUser);
                    #endregion                   

                }
            }

            return JsonSubmit(loginModel);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        [ResultLogFilter(ExecType = 3, LogType = LogType.LoginInOut, OptType = OperateBtn.LoginOut)]
        public ActionResult LoginOut()
        {
            LoginUserAuth.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}