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
    public class LoginForGaoLuController :  BaseController
    {
        // GET: MsSys/LoginForGaoLu
        public ActionResult Index()
        {
            string uname = Request.QueryString["uname"];
            if (string.IsNullOrWhiteSpace(uname))
            {
                uname = "rmx_gaolu";
            }
            CheckLogin(uname, "321");

            Response.Redirect("/MsSys/Main/Index2forgaolu?pId=5cc991e7-2fa7-4e76-b54c-e4950c7a1437");

            return View();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="operatorModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(LogType = LogType.LoginInOut, OptType = OperateBtn.LoginIn)]
        public JsonResult CheckLogin(string Account, string Password)
        {
            LoginModel loginModel = null;

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

            return JsonSubmit(loginModel);
        }
    }
}