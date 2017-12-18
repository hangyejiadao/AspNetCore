/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_TesterData
 * 创建时间：2017-02-09 15:42:10
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
using Dos.ORM.Model.BusView;
using System.Linq.Expressions;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_TesterData : IDBBase<BUS_Tester>
    {
        /// <summary>
        /// 获取试验检测人员列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<BUS_Tester> GetList(Guid organId);

        /// <summary>
        /// 获取人员以及对应照片列表
        /// </summary>
        /// <returns></returns>
        OperateModel GetListWPic();

        /// <summary>
        /// 获取人员以及对应照片列表
        /// </summary>
        /// <returns></returns>
        List<TesterView> GetListWPic(Guid organId);

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperateModel GetOneWPic(Guid id);

        /// <summary>
        /// 带时间戳批量增加测试人员数据
        /// </summary>
        /// <param name="modelList">测试人员list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        OperateModel AddModelList(IList<BUS_Tester> modelList, Guid projectId, string timeStamp);


        DgListModel<BUS_Tester> GetList(DgConModel dgCon, Expression<Func<BUS_Tester, bool>> whereLambda = null);
    }
}
