/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_RoleModuleData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_RoleModuleData : DBBase<BUS_RoleModule>, IBUS_RoleModuleData
    {
        /// <summary>
        /// 管理角色模块关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="listRoleModule"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool ModifyRoleModule(Guid roleId, List<BUS_RoleModule> listRoleModule, DbTrans trans = null)
        {
            var ret = false;
            var hasData = GetModel(m => m.RoleID == roleId);


            if (hasData == null || DeleteModelOther<BUS_RoleModule>(m => m.RoleID == roleId).Result == OperateRetType.Success)
                foreach (var item in listRoleModule)
                {
                    ret = InsertModel(item, trans).Result == OperateRetType.Success;
                }

            return ret;
        }
    }
}
