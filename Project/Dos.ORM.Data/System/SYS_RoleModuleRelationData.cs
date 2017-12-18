/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_RoleModuleRelationData
 * 创建时间：2016-08-14 14:52:59
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_RoleModuleRelationData : DBBase<SYS_RoleModuleRelation>, ISYS_RoleModuleRelationData
    {
        /// <summary>
        /// 管理角色模块关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="listRoleModule"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool ModifyRoleModule(Guid roleId, List<SYS_RoleModuleRelation> listRoleModule, DbTrans trans = null)
        {
            var ret = false;
            var hasData = GetModel(m => m.RoleId == roleId);


            if (hasData == null || DeleteModelOther<SYS_RoleModuleRelation>(m => m.RoleId == roleId).Result == OperateRetType.Success)
                foreach (var item in listRoleModule)
                {
                    ret = InsertModel(item, trans).Result == OperateRetType.Success;
                }

            return ret;
        }
    }
}
