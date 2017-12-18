using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.WebPC.App_Common.Auth;
using Dos.ORM.WebPC.Controllers.Base;
using Newtonsoft.Json.Linq;
using Dos.ORM.WebPC.Models;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class MainController : SubBaseController
    {                    
        //系统主页-主页      
        public ActionResult Index()
        {

            ViewBag.OrganName = LoginUser.User.OrganName;
            ViewBag.FullName = LoginUser.User.FullName;
            return View();
        }

        //系统主页-平台Old     
        public ActionResult Index1(string pId)
        {          
            ViewBag.ModulePid = pId;
            return View();
        }

        //系统主页-平台New    
        public ActionResult Index2(string pId)
        {
            ViewBag.ModulePid = pId;
            return View();
        }
        public ActionResult Index2forgaolu(string pId)
        {
            ViewBag.ModulePid = pId;
            return View();
        }
        public ActionResult Index3forgaolu(string pId)
        {
            ViewBag.ModulePid = pId;
            return View();
        }
        //系统主页-拌合站      
        public ActionResult Index3(string pId)
        {
            ViewBag.ModulePid = pId;           
            return View();
        }
        
             
        //系统项目主页      
        public ActionResult TestIndex(string pId)
        {           
            ViewBag.ModulePid = pId;
            return View();
        }
              

        //个人下拉菜单     
        public ActionResult Person()
        {
            return View();
        }
               
        //主题设置下拉菜单        
        public ActionResult Themes()
        {
            return View();
        }

        public ActionResult Content()
        {
            return View();
        }
             
        // 获取菜单       
        [HttpGet]
        public JsonResult GetModule()
        {
            var RoleID = LoginUser.UserRole.RoleID;

            string url = string.Format(WebAPIHelper.GetSuperMenuAPI + "/{0}", RoleID);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            if (OperModel == null)
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "调用接口失败！"
                };
            }
           
            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }
              
        //获取项目菜单      
        [HttpGet]
        public JsonResult GetUserLab()
        {

            var AccountID = LoginUser.User.ID;

            string url = string.Format(WebAPIHelper.GetUserLabAPI + "/{0}", AccountID);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            if (OperModel == null)
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "调用接口失败！"
                };
            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        //获取项目_菜单      
        [HttpGet]
        public JsonResult GetLabModule(string ModulePid)
        {
            var AccountId = LoginUser.User.ID;
            var RoleId = LoginUser.UserRole.RoleID;

            var queryCon = new JObject(
              new JProperty("AccountId", AccountId),
              new JProperty("RoleId", RoleId),            
              new JProperty("ModulePid", ModulePid)
              );

            var OperModel = HttpClientHelper.Post<OperateModel>(WebAPIHelper.GetLabModuleAPI, JsonHelper.ObjectToJson(queryCon));
            
            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }
              
        // 锁屏、解锁屏
        [HttpPost]
        public JsonResult GetSetLock(string lockType, string unlockPwd)
        {
            var isLock = false;

            //是否解锁成功，解锁成功与否提示信息
            var unlockIsRight = false;
            var tipMsg = string.Empty;

            if (lockType == "set")
            {
                SessionHelper.Set("SCREEN_ISLOCK", true);
                isLock = true;
            }
            else if (lockType == "get")
                isLock = SessionHelper.Get("SCREEN_ISLOCK") != null && Convert.ToBoolean(SessionHelper.Get("SCREEN_ISLOCK"));
            else if (lockType == "unlock")
            {
                unlockPwd = EndeHelper.Encrypt(unlockPwd);
                unlockIsRight = unlockPwd == LoginUser.User.Password;
                tipMsg = unlockPwd == LoginUser.User.Password ? "系统解锁成功！" : "系统解锁失败，请检查您的密码是否正确！";

                if (unlockIsRight)
                {
                    SessionHelper.Set("SCREEN_ISLOCK", false);
                    isLock = false;
                }
            }

            var retModel = new OperateModel
            {
                Result = unlockIsRight ? OperateRetType.Success : OperateRetType.Fail,
                Msg = tipMsg,
                Data = isLock
            };

            return Json(retModel, JsonRequestBehavior.AllowGet);
        }

        //修改密码页面
        public ActionResult PasswordIndex()
        {
            return View();
        }

        //修改密码
        [HttpPost]
        public JsonResult UpdatePwd(string oldPwd, string newPwd)
        {
         
            var userModel = LoginUser.User;

            OperateModel OperModel = null;

            if (EndeHelper.Encrypt(oldPwd) != userModel.Password)
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "原始密码输入错误！"
                };
            }
            else
            {
                var conObj = new JObject(
                    new JProperty("userId", userModel.ID),
                    new JProperty("oldPwd", userModel.Password),
                    new JProperty("newPwd", EndeHelper.Encrypt(newPwd))
                    );

                OperModel = HttpClientHelper.Post<OperateModel>(WebAPIHelper.EditPwdAPI, JsonHelper.ObjectToJson(conObj));

                if (OperModel == null)
                {
                    OperModel = new OperateModel
                    {
                        Result = OperateRetType.Fail,
                        Msg = "密码修改失败！"
                    };                   
                }

            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }


    }
}