/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_RoleModuleData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.IData.Base;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_RoleModuleData : IDBBase<BUS_RoleModule>
    {
        /// <summary>
        /// 管理角色模块关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="listRoleModule"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        bool ModifyRoleModule(Guid roleId, List<BUS_RoleModule> listRoleModule, DbTrans trans = null);
    }
}
