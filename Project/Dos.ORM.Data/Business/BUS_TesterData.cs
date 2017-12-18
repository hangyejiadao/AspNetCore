/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_TesterData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Transactions;
using Dos.ORM.Common.Enums;
using Dos.ORM.Model.BusView;
using KXFramework.Common;
using System.Linq.Expressions;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_TesterData : DBBase<BUS_Tester>, IBUS_TesterData
    {

        #region 获取试验检测人员基本数据

        /// <summary>
        /// 获取验检测人员列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BUS_Tester> GetList(Guid organId)
        {
            return DB.DbCont.From<BUS_Tester>().Where(m => m.OrganID == organId).ToEnumerable();
        }

        /// <summary>
        /// 获取人员以及对应照片列表
        /// </summary>
        /// <returns></returns>
        public OperateModel GetListWPic()
        {
            OperateModel resultInfo = new OperateModel();

            try
            {
                var select = DB.DbCont.From<BUS_Tester>().LeftJoin<BUS_File>((a, b) => a.PersonID == b.ModuleDataId).
                    Select(BUS_Tester._.All, BUS_File._.CutPath).ToList();

                if (select != null)
                {
                    resultInfo.Result = OperateRetType.Success;
                    resultInfo.Msg = "操作成功！";
                    resultInfo.Data = select;
                }
                return resultInfo;
            }
            catch (Exception ex)
            {
                return resultInfo;
            }
        }

        /// <summary>
        /// 获取人员以及对应照片列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <returns></returns>
        public List<TesterView> GetListWPic(Guid organId)
        {
            try
            {
                var select = DB.DbCont.From<BUS_Tester>().LeftJoin<BUS_File>((a, b) => a.PersonID == b.ModuleDataId)
                            .Where(m => m.OrganID == organId)
                            .Select(BUS_Tester._.All, BUS_File._.CutPath).ToDataTable();

                var list = EntityHelper.DataTableToList<TesterView>(select);

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        public OperateModel GetOne(Guid id)
        {
            OperateModel resultInfo = new OperateModel();

            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var model = GetModel(m => m.PersonID == id);
                    if (model != null)
                    {
                        resultInfo.Result = OperateRetType.Success;
                        resultInfo.Msg = "操作成功！";
                        resultInfo.Data = model;
                    }
                }
                return resultInfo;
            }
            catch (Exception ex)
            {
                return resultInfo;
            }
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateModel GetOneWPic(Guid id)
        {
            OperateModel resultInfo = new OperateModel();
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var select = DB.DbCont.From<BUS_Tester>().
                        LeftJoin<BUS_File>((a, b) => a.PersonID == b.ModuleDataId).Where(BUS_Tester._.PersonID == id).
                        Select(BUS_Tester._.All, BUS_File._.CutPath).ToList();

                    if (select != null)
                    {
                        resultInfo.Result = OperateRetType.Success;
                        resultInfo.Msg = "操作成功！";
                        resultInfo.Data = select;
                    }
                }

                return resultInfo;
            }
            catch (Exception ex)
            {
                resultInfo.Msg = ex.ToString();
                return resultInfo;
            }
        }

        #endregion

        #region 同步试验检测人员
        private static readonly object ObjBusTester = new object();
        /// <summary>
        /// 批量增加测试人员数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_Tester> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();
            modelList = modelList.GroupBy(x => x.PersonID).Select(x => x.FirstOrDefault()).ToList();
            lock (ObjBusTester)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    var pesonIds = modelList.Select(m => m.PersonID).ToList();
                    var testerExit = GetModels(m => m.PersonID.In(pesonIds));
                    try
                    {
                        if (testerExit != null && testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_Tester>();
                            foreach (var item in testerExit)
                            {
                                var newItem = modelList.FirstOrDefault(m => m.PersonID == item.PersonID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);
                            var nonList = modelList.Except(testerExitNew).ToList();
                            if (nonList != null && nonList.Count > 0)
                            {
                                InsertModels(nonList, trans);
                            }
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Tester"))
                        {
                            resultInfo.Result = OperateRetType.Success;
                            resultInfo.Msg = "操作成功";
                            resultInfo.Data = true;
                        }
                        trans.Commit();
                        return resultInfo;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Tester", false);
                        return resultInfo;
                    }
                }
            }

        }

        /// <summary>
        /// 批量增加测试人员数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList2(IList<BUS_Tester> modelList)
        {
            OperateModel resultInfo = new OperateModel();

            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                try
                {

                    foreach (var lt1 in modelList)
                    {
                        var lt = lt1;
                        var tester = GetModel(m => m.PersonID == lt.PersonID);

                        if (tester == null)
                        {
                            tester = lt;
                            InsertModel(tester);
                        }
                        else
                        {
                            lt.ID = tester.ID;
                            tester = lt;
                            UpdateModel(tester, m => m.PersonID == lt.PersonID);
                        }
                    }

                    resultInfo.Result = OperateRetType.Success;
                    resultInfo.Msg = "操作成功";
                    trans.Commit();

                    return resultInfo;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return resultInfo;
                }
            }
        }

        /// <summary>
        /// 批量增加测试人员数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList1(IList<BUS_Tester> modelList, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                try
                {
                    if (modelList.Count > 0 && !string.IsNullOrEmpty(timeStamp))
                    {
                        foreach (var lt1 in modelList)
                        {
                            var lt = lt1;
                            var tester = GetModel(m => m.PersonID == lt.PersonID);

                            if (tester == null)
                            {
                                tester = lt;
                                InsertModel(tester);
                            }
                            else
                            {
                                lt.ID = tester.ID;
                                tester = lt;
                                UpdateModel(tester, m => m.PersonID == lt.PersonID);
                            }
                        }

                        if (API_SyncLogData.AddApiLog(timeStamp, "BUS_Tester"))
                        {
                            resultInfo.Result = OperateRetType.Success;
                            resultInfo.Msg = "操作成功";
                            resultInfo.Data = true;
                        }

                        trans.Commit();
                    }

                    return resultInfo;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    API_SyncLogData.AddApiLog(timeStamp, "BUS_Tester", false);
                    return resultInfo;
                }
            }
        }

        #endregion


        public DgListModel<BUS_Tester> GetList(DgConModel dgCon, Expression<Func<BUS_Tester, bool>> whereLambda = null)
        {
            var section = DB.DbCont.From<BUS_Tester>()
                .LeftJoin<BUS_File>((a, b) => a.PersonID == b.ModuleDataId)
                .Select(BUS_Tester._.All, BUS_File._.FilePath)
                .Where(whereLambda).OrderBy(GetOrderByClip(dgCon));

            var totalCount = section.Count();
            var retList = section.Page(dgCon.rows, dgCon.page).ToList();

            return new DgListModel<BUS_Tester>(retList, totalCount);
        }

    }
}
