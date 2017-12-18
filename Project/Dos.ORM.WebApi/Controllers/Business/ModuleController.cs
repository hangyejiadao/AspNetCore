using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Model.Models;
using Dos.ORM.WebApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 模块API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "module")]
    public class ModuleController : BaseApiController
    {

        [Ninject.Inject]
        private IBUS_ModuleData Bus_Module { get; set; }

        [Ninject.Inject]
        private IBUS_UserLaboratoryData Bus_UserLaboratory { get; set; }

        [Ninject.Inject]
        private IBUS_MixingPlanData BUS_MixingPlan { get; set; }


        #region 获取模块和菜单

        /// <summary>
        /// 获取模块菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [GET("get/menus/{roleId}")]
        public OperateModel GetMenus(string roleId)
        {
            var retList = Bus_Module.GetMenus(roleId);

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
        /// 获取一级模块
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [GET("get/supermenus/{roleId}")]
        public OperateModel GetSuperMenus(string roleId)
        {
            var retList = Bus_Module.GetSuperMenus(roleId);

            OperateModel operModel = null;

            if (retList != null && retList.Count > 0)
            {

                operModel = new OperateModel()
                {
                    Result = OperateRetType.Success,
                    Msg = "获取菜单成功！",
                    Data = retList
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
            var retList = Bus_UserLaboratory.GetUserLab(accountId);

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
        
        /// <summary>
        /// PC获取项目实验室树和模块
        /// </summary>
        /// <param name="pageCon"></param>
        /// <returns></returns>
        [POST("get/labmodule")]
        public OperateModel PostLabModule([FromBody]PostLabModule pageCon)
        {

            OperateModel operModel = null;

            var ModuleList = Bus_Module.GetModuleMenus(pageCon.RoleId,pageCon.ModulePid);

            if (ModuleList != null && ModuleList.Count > 0)
            {
                var XmLabList = Bus_UserLaboratory.GetUserLab(pageCon.AccountId);
                
                //03 拌合站数据监控系统 添加extraData数据
                var Module = Bus_Module.GetModel(s => s.ID == Guid.Parse(pageCon.ModulePid));
                List<BUS_MixingPlan> UrlList = null;
                if (Module.ModuleCode == "03")
                {
                    UrlList = BUS_MixingPlan.GetModels();
                }

                var Model = new T_LabModule()
                {
                    ModulePid = Guid.Parse(pageCon.ModulePid),
                    ModuleCode=Module.ModuleCode,
                    XmLabList = XmLabList,
                    ModuleList = ModuleList,
                    UrlList = UrlList,
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

        #endregion


        #region  力学设备数据监控系统数据

        /// <summary>
        /// 访问数据库获取 力学设备数据监控系统数据
        /// </summary>
        /// <param name="pageCon"></param>
        /// <returns></returns>
        [POST("get/accessdb")]
        public OperateModel<TW_SYJZBModel> PostSysData([FromBody]PostAccessDB pageCon)
        {

            OperateModel<TW_SYJZBModel> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.OrganID))
            {
                OperModel = new OperateModel<TW_SYJZBModel>
                {
                    Result = OperateRetType.Fail,
                    Msg = "参数OrganID不能为空，获取失败！"
                };
            }
            else if (string.IsNullOrWhiteSpace(pageCon.TypeCode))
            {
                OperModel = new OperateModel<TW_SYJZBModel>
                {
                    Result = OperateRetType.Fail,
                    Msg = "参数TypeCode不能为空，获取失败！"
                };
            }
            else
            {
                var Exec_SQL = @"SELECT A.* 
                               FROM BUS_Project A WITH(NOLOCK) INNER JOIN 
                                    BUS_ProjectLaboratory B WITH(NOLOCK) ON A.ProjectID=B.ProjectID INNER JOIN
                                    BUS_Laboratory C WITH(NOLOCK) ON B.OrganID=C.OrganID       
                              WHERE C.OrganID='{0}'";

                var Model = DB.DbCont.FromSql(string.Format(Exec_SQL, pageCon.OrganID)).ToFirstDefault<BUS_Project>();

                if (string.IsNullOrWhiteSpace(Model.DataCollectionUrl))
                {
                    OperModel = new OperateModel<TW_SYJZBModel>
                    {
                        Result = OperateRetType.Fail,
                        Msg = "项目连接数据未设置，获取失败！"
                    };
                }
                else
                {
                                      
                    try
                    {

                        var retList = Bus_Module.GetSysData(pageCon, Model.DataCollectionUrl);
                        retList.rows.ForEach(item => { item.URL = Model.SoftUrl; });
                        
                        OperModel = new OperateModel<TW_SYJZBModel>
                        {
                            Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                            Msg = retList != null ? "获取成功！" : "获取失败！",
                            Data = retList
                        };
                    }
                    catch
                    {
                        OperModel = new OperateModel<TW_SYJZBModel>
                        {
                            Result = OperateRetType.Fail,
                            Msg = "获取失败！"
                        };
                    }
                }
            }
            return OperModel;
        }

        #endregion


        #region 拌合站相关接口

        /// <summary>
        /// 根据用户获取项目拌合站接口地址
        /// </summary>
        /// <returns></returns>
        [GET("get/bhzapi/{accountId}")]
        public OperateModel GetBhzApiList(string accountId)
        {
            OperateModel OperModel = null;
            if (string.IsNullOrWhiteSpace(accountId))
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "accountId不能为空，获取失败！"
                };
            }
            else
            {

                var Exec_SQL = string.Format(@"SELECT A.TargetId,A.ParentId,B.BhzApi FROM BUS_UserLaboratory A WITH(NOLOCK) INNER JOIN 
                                               BUS_Project B WITH(NOLOCK) ON A.ParentId=B.ProjectID AND A.ParentId IS NOT NULL WHERE A.AccountID='{0}'", accountId);

                var retList = DB.DbCont.FromSql(Exec_SQL).ToList<object>();

                OperModel = new OperateModel
                {
                    Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = retList != null ? "获取成功！" : "获取失败！",
                    Data = retList
                };
            }
            return OperModel;
        }

        #endregion

    }
}