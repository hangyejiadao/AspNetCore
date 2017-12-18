/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Base
 * 类名称：ApiPageRetModel
 * 创建时间：2017/2/21 21:08:03
 * 创建人：Quber
 * 创建说明：WebApi分页方法所需实体（返回的分页数据对象）
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    /// <summary>
    /// WebApi分页方法所需实体（返回的分页数据对象）
    /// </summary>
    public class ApiPageRetModel : ApiPageConModel
    {
        private int _totalCount = 0;
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        public object List { get; set; }
    }

    /// <summary>
    /// WebApi分页方法所需实体（返回的分页数据对象）
    /// </summary>
    public class ApiPageResult : ApiPageConModel
    {
        private int _totalCount = 0;
        /// <summary>
        /// 总条数
        /// </summary>
        public int Count
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        public object Items { get; set; }
    }
}
