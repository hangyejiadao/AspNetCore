/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：BUS_UserLaboratoryData
 * 创建时间：2017-02-15 11:06:10
 * 创建人：zjg-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using System.Collections.Generic;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_UserLaboratoryData : DBBase<BUS_UserLaboratory>, IBUS_UserLaboratoryData
    {
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<BUS_UserLaboratory> GetUserLab(string AccountID)
        {
            var Exec_SQL = @"SELECT A.*,B.TargetName,BhzApi,SyjApi
                               FROM BUS_UserLaboratory A WITH(NOLOCK) LEFT JOIN  
                                    (SELECT ProjectID TargetId, ProjectShorName TargetName,0 OrderNum,BhzApi,SyjApi FROM dbo.BUS_Project WITH(NOLOCK) 
                                    UNION ALL SELECT OrganID TargetId,OrganShorName TargetName,OrderNum,NULL BhzApi,NULL SyjApi FROM dbo.BUS_Laboratory WITH(NOLOCK)) B ON A.TargetId=B.TargetId
                              WHERE A.AccountID='{0}' ORDER BY A.ParentId,B.OrderNum ASC";
            var Module = DB.DbCont.FromSql(string.Format(Exec_SQL, AccountID)).ToList<BUS_UserLaboratory>();
            return Module;
        }
    }



}
