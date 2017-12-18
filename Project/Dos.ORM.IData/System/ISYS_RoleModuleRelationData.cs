/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_RoleModuleRelationData
 * 创建时间：2016-09-21 16:36:42
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
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_RoleModuleRelationData : IDBBase<SYS_RoleModuleRelation>
    {
        /// <summary>
        /// 管理角色模块关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="listRoleModule"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        bool ModifyRoleModule(Guid roleId, List<SYS_RoleModuleRelation> listRoleModule, DbTrans trans = null);
    }
}
