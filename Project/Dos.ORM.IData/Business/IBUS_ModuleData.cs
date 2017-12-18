/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_ModuleData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_ModuleData : IDBBase<BUS_Module>
    {

        List<BUS_Module> GetMenus(string RoleID);
        List<BUS_Module> GetSuperMenus(string RoleID);

        List<BUS_Module> GetModuleMenus(string RoleID, string ModulePid);
        
        /// <summary>
        /// 获取模块管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForModule(Guid moduleId, Guid parentId);


        /// <summary>
        /// 获取角色管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForRole(Guid roleId, List<BUS_RoleModule> roleModuleList);


        Echart_Model GetEChartsReportByItem(string OrganID, string ItemCode, string Year);

        Echart_Model GetEChartsReportByMonth(string OrganID, string Month);
        
        DgListModel<TW_SYJZBModel> GetSysData(PostAccessDB pageCon, string StrConn);

    }
}
