/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_RoleData
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
using System.Data;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_RoleData : DBBase<SYS_Role>, ISYS_RoleData
    {
        /// <summary>
        /// 根据管理员Id获取其角色列表
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public List<SYS_Role> GetUserRoles(Guid operatorId)
        {
            var retSql = @"
                SELECT * FROM dbo.SYS_Role a
                LEFT JOIN dbo.SYS_OperatorRoleRelation b ON a.RoleId=b.RoleId
                WHERE b.OperatorId='{0}';
            ";

            var retList = GetModelsSql(string.Format(retSql, operatorId));
            return retList;
        }

        /// <summary>
        /// 根据角色Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="comId"></param>
        /// <returns></returns>
        public DataTable GetRoleOperators(Guid depId, Guid? comId)
        {
            if (comId == null) return new DataTable();

            var retSql = @"
                SELECT a.OperatorId,a.Account,a.Realname,a.Nickname,(SELECT COUNT(1) FROM dbo.SYS_OperatorRoleRelation b WHERE b.OperatorId=a.OperatorId AND b.RoleId='{0}') ThisCount
                FROM dbo.SYS_Operator a
                WHERE a.CompanyId='{1}';
            ";

            var dt = GetDataTableSql(string.Format(retSql, depId, comId));
            return dt;
        }
    }
}
