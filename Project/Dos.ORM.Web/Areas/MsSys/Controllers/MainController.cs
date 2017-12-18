using System;
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
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class MainController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_ModuleData SysModule { get; set; }

        /// <summary>
        /// 系统主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 个人下拉菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Person()
        {
            return View();
        }

        /// <summary>
        /// 主题设置下拉菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Themes()
        {
            return View();
        }

        public ActionResult Content()
        {
            return View();
        }

        /// <summary>
        /// 获取管理员菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModule()
        {
            var moduleListSys = new List<ZTreeModel>();
            var moduleListBus = new List<ZTreeModel>();

            var userAuth = MsSysUserAuth.Get();
            if (userAuth != null)
            {
                if (userAuth.IsSuperAdmin || userAuth.AccountType == 2)
                {
                    var allModules = SysModule.GetModels(m => m.Status == 1 && m.IsEnable == 1 && m.OperatePageType == 1);
                    moduleListSys = allModules.Where(m => m.ModuleType == (int)ModuleType.System).OrderBy(m => m.SortNo).ToList().ToModelList<SYS_Module, ZTreeModel>();
                    moduleListBus = allModules.Where(m => m.ModuleType >= (int)ModuleType.Business).OrderBy(m => m.SortNo).ToList().ToModelList<SYS_Module, ZTreeModel>();
                }
                else
                {
                    if (userAuth.ModuleList != null)
                    {
                        var allModules = userAuth.ModuleList.Where(m => m.OperatePageType == 1).ToList();
                        moduleListSys = allModules.Where(m => m.ModuleType == (int)ModuleType.System).OrderBy(m => m.SortNo).ToList().ToModelList<v_SYS_Module, ZTreeModel>();
                        moduleListBus = allModules.Where(m => m.ModuleType >= (int)ModuleType.Business).OrderBy(m => m.SortNo).ToList().ToModelList<v_SYS_Module, ZTreeModel>();
                    }
                }
            }

            #region 去掉图标地址
            var moduleListSysNoIcon = new List<ZTreeModel>();
            foreach (var item in moduleListSys)
            {
                item.icon = null;
                moduleListSysNoIcon.Add(item);
            }
            var moduleListBusNoIcon = new List<ZTreeModel>();
            foreach (var item in moduleListBus)
            {
                item.icon = null;
                moduleListBusNoIcon.Add(item);
            }
            #endregion

            #region easyui-accordion所需菜单
            var moduleListSysEui = new List<ZTreeModelRelation>();
            foreach (var item in moduleListSys.Where(m => (Guid)m.pId == Guid.Empty))
            {
                var moduleListSysEuiSon = new List<ZTreeModel>();
                foreach (var son in moduleListSys.Where(s => (Guid)s.pId == (Guid)item.id))
                {
                    moduleListSysEuiSon.Add(new ZTreeModelRelation
                    {
                        id = son.id,
                        pId = son.pId,
                        name = son.name,
                        iconName = son.iconName,
                        src = son.src
                    });
                }

                moduleListSysEui.Add(new ZTreeModelRelation
                {
                    id = item.id,
                    pId = item.pId,
                    name = item.name,
                    iconName = item.iconName,
                    src = item.src,
                    Sons = moduleListSysEuiSon
                });
            }

            var moduleListBusEui = new List<ZTreeModelRelation>();
            foreach (var item in moduleListBus.Where(m => (Guid)m.pId == Guid.Empty))
            {
                var moduleListBusEuiSon = new List<ZTreeModel>();
                foreach (var son in moduleListBus.Where(s => (Guid)s.pId == (Guid)item.id))
                {
                    moduleListBusEuiSon.Add(new ZTreeModelRelation
                    {
                        id = son.id,
                        pId = son.pId,
                        name = son.name,
                        iconName = son.iconName,
                        src = son.src
                    });
                }

                moduleListBusEui.Add(new ZTreeModelRelation
                {
                    id = item.id,
                    pId = item.pId,
                    name = item.name,
                    iconName = item.iconName,
                    src = item.src,
                    Sons = moduleListBusEuiSon
                });
            }
            #endregion

            var retModule = new
            {
                ztreeModule = new { sys = moduleListSysNoIcon, bus = moduleListBusNoIcon },
                easyModule = new { sys = moduleListSysEui, bus = moduleListBusEui }
            };

            return Json(retModule, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 锁屏、解锁屏
        /// </summary>
        /// <param name="lockType">查询类型（get：初始化获取，set：设置锁屏，unlock：解锁）</param>
        /// <param name="unlockPwd">解锁的密码</param>
        /// <returns></returns>
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
                unlockIsRight = unlockPwd == MsSysUserModel.Operator.Pwd;
                tipMsg = unlockPwd == MsSysUserModel.Operator.Pwd ? "系统解锁成功！" : "系统解锁失败，请检查您的密码是否正确！";

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
    }
}