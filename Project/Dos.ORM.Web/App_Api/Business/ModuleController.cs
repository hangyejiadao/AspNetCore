using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
    /// 模块API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "module")]
    public class ModuleController : BaseApiController
    {

        [Ninject.Inject]
        private IBUS_ModuleData BusModule { get; set; }


        [Ninject.Inject]
        private IBUS_UserLaboratoryData BusUserLaboratory { get; set; }


        /// <summary>
        /// 获取模块菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [GET("get/menus/{roleID}")]
        public OperateModel GetMenus(string roleId)
        {
            var retList = BusModule.GetMenus(roleId);

            OperateModel operModel = null;

            if (retList != null && retList.Count > 0)
            {
                var Model = new ModuleTree()
                {
                    Modules = retList
                };

                Model.Init();

                operModel = new OperateModel()
                {
                    Result = OperateRetType.Success,
                    Msg = "获取菜单成功！",
                    Data = Model
                };
            }
            else
            {
                operModel = new OperateModel()
                {
                    Result = OperateRetType.Fail,
                    Msg = "获取菜单失败！"
                };
            }
            return operModel;
        }



        /// <summary>
        /// 获取项目实验室
        /// </summary>
        /// <param name="accountId">用户账号Id</param>
        /// <returns></returns>
        [GET("get/userlab/{accountID}")]
        public OperateModel GetUserLab(string accountId)
        {
            var retList = BusUserLaboratory.GetUserLab(accountId);

            OperateModel operModel = null;

            if (retList != null && retList.Count > 0)
            {
                var Model = new XmLabTree()
                {
                    XmLab = retList
                };

                Model.Init();

                operModel = new OperateModel()
                {
                    Result = OperateRetType.Success,
                    Msg = "项目实验室成功！",
                    Data = Model
                };
            }
            else
            {
                operModel = new OperateModel()
                {
                    Result = OperateRetType.Fail,
                    Msg = "项目实验室失败！"
                };
            }
            return operModel;
        }



    }
}