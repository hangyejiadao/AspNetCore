/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_ReportData
 * 创建时间：2017-02-21 09:21:51
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Linq.Expressions;
using Dos.ORM.Model.BusView;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_ReportData : IDBBase<BUS_Report>
    {

        DgListModel GetList(DgConModel dgCon, Expression<Func<BUS_Report, bool>> whereLambda = null);

        /// <summary>
        /// 获取报告列表
        /// </summary>
        /// <returns></returns>
        List<BUS_Report> GetList(Guid organId);

        /// <summary>
        /// 获取报告以及对应样品列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReportView> GetListWSample(Guid organId);

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应样品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperateModel GetOneWSample(Guid id);

        /// <summary>
        /// 同步报告数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        OperateModel AddModelList(IList<BUS_Report> modelList, Guid projectId, string timeStamp);
    }
}
