/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Base
 * 类名称：DB
 * 创建时间：2016-06-13 14:34:51
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.Common;

namespace Dos.ORM.Data.Base
{
    /// <summary>
    /// 数据库访问对象
    /// </summary>
    public class DB
    {
        /// <summary>
        /// SqlServer数据库访问对象
        /// </summary>
        public static readonly DbSession DbCont = new DbSession("SqlServerConn");

        ///// <summary>
        ///// MySql数据库访问对象
        ///// </summary>
        //public static readonly DbSession DbContMySql = new DbSession("MySqlConn");

        static DB()
        {
            //记录执行生成的sql语句，方便调试查看（注意：在发布后，建议不执行此操作，以免影响一定的性能）
            DbCont.RegisterSqlLogger(delegate(string sql)
            {
                Common.Helpers.LogHelper.LogDebug(sql);
            });
        }
    }
}
