/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_ModuleData
 * 创建时间：2016-09-21 16:31:39
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_ModuleData : IDBBase<SYS_Module>
    {
        /// <summary>
        /// 获取模块管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForModule(int moduleType, Guid moduleId, Guid parentId);

        /// <summary>
        /// 获取角色管理所需模块
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleType"></param>
        /// <param name="roleModuleList"></param>
        /// <returns></returns>
        List<ZTreeModel> GetModulesForRole(int moduleType, Guid roleId, List<SYS_RoleModuleRelation> roleModuleList);
    }
}
