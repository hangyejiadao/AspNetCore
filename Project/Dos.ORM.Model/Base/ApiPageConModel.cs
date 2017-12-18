/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Base
 * 类名称：ApiPageConModel
 * 创建时间：2017/2/21 21:06:43
 * 创建人：Quber
 * 创建说明：WebApi分页方法所需实体（方法参数实体继承的对象）
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
    /// WebApi分页方法所需实体（方法参数实体继承的对象）
    /// </summary>
    public class ApiPageConModel
    {
        private int _pageIndex = 1;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private int _pageSize = 10;
        /// <summary>
        /// 当前分页大小
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }

    /// <summary>
    /// 该实体是客户端调用的时候传递过来的
    /// </summary>
    public class ModelPageConModel : ApiPageConModel
    {
        //实验室ID
        public string TargetId { get; set; }

        //过滤字段
        public string FilterText { get; set; }

        //试验类型ID
        public string TypeId { get; set; }

        //开始日期
        public string StartDate { get; set; }

        //结束日期
        public string EndDate { get; set; }

        //功能室
        public string EquType { get; set; }

    }

}
