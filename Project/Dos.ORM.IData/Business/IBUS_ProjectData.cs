/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_ProjectData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System.Collections.Generic;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_ProjectData : IDBBase<BUS_Project>
    {

        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        OperateModel GetList();

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 同步项目数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        OperateModel AddModelList(IList<BUS_Project> modelList, Guid projectId, string timeStamp);

        /// <summary>
        /// 获取角色管理所需项目和试验室
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projName"></param>
        /// <param name="selectedIds"></param>
        /// <param name="isInit"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForUser(Guid userId, string projName, string selectedIds, bool isInit);

        /// <summary>
        /// 获取角色管理中已选择项目和试验室
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesSelectedForUser(Guid userId);

        /// <summary>
        /// 根据ID获取角色管理中的项目和试验室
        /// </summary>
        /// <param name="newIds"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForUserFromID(string newIds);
    }
}
