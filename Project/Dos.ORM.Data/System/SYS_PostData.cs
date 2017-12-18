/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_PostData
 * 创建时间：2016-11-15 17:20:54
 * 创建人：CDKX-ZC-2016002
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Data;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_PostData : DBBase<SYS_Post>, ISYS_PostData
    {
        /// <summary>
        /// 根据岗位Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="comId"></param>
        /// <returns></returns>
        public DataTable GetPostOperators(Guid depId, Guid? comId)
        {
            if (comId == null) return new DataTable();

            var retSql = @"
                SELECT a.OperatorId,a.Account,a.Realname,a.Nickname,(SELECT COUNT(1) FROM dbo.SYS_OperatorPostRelation b WHERE b.OperatorId=a.OperatorId AND b.PostId='{0}') ThisCount
                FROM dbo.SYS_Operator a
                WHERE a.CompanyId='{1}';
            ";

            var dt = GetDataTableSql(string.Format(retSql, depId, comId));
            return dt;
        }
    }
}
