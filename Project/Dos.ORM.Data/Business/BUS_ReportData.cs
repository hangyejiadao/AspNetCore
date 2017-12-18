/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：BUS_ReportData
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
using System.Linq;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Linq.Expressions;
using Dos.ORM.Model.BusView;
using KXFramework.Common;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_ReportData : DBBase<BUS_Report>, IBUS_ReportData
    {
        #region 获取报告基本数据

        /// <summary>
        /// 获取报告列表
        /// </summary>
        /// <returns></returns>
        public List<BUS_Report> GetList(Guid organId)
        {
            return GetModels(m => m.OrganID == organId);
        }

        /// <summary>
        /// 获取报告列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public DgListModel GetList(DgConModel dgCon, Expression<Func<BUS_Report, bool>> whereLambda = null)
        {
            var section = DB.DbCont.From<BUS_Report>()
                .LeftJoin<BUS_Sample>((a, b) => a.SampleID == b.SampleID && a.ProjectID==b.ProjectID && a.OrganID==b.OrganID)
                .Select(BUS_Report._.All, BUS_Sample._.SampleName,BUS_Sample._.SampleNumber,
                        BUS_Sample._.SampleTypeID,BUS_Sample._.EngineeringPurposes)
                .Where(whereLambda).OrderBy(GetOrderByClip(dgCon));

            var totalCount = section.Count();
            var retList = section.Page(dgCon.rows, dgCon.page).ToDataTable();

            return new DgListModel(retList, totalCount);
        }

        /// <summary>
        /// 获取报告以及对应样品列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<Model.BusView.ReportView> GetListWSample(Guid organId) 
        {
            try
            {
                var select = DB.DbCont.From<BUS_Report>().LeftJoin<BUS_Sample>((a, b) => a.SampleID == b.SampleID)
                        .Where(m=>m.OrganID == organId)
                        .Select(BUS_Report._.All, BUS_Sample._.SampleName, BUS_Sample._.SampleCode, BUS_Sample._.EngineeringPurposes).ToList<Model.BusView.ReportView>();

                return select;
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
                    var model = GetModel(m => m.ReportID == id);
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
                resultInfo.Msg = ex.ToString();
                return resultInfo;
            }
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应样品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateModel GetOneWSample(Guid id)
        {
            OperateModel resultInfo = new OperateModel();
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var select = DB.DbCont.From<BUS_Report>().
                        LeftJoin<BUS_Sample>((a, b) => a.SampleID == b.SampleID).Where(BUS_Report._.ReportID == id).
                        Select(BUS_Report._.All,BUS_Sample._.SampleName,BUS_Sample._.SampleCode,BUS_Sample._.EngineeringPurposes).ToDataTable();

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

        #region 报告数据同步
        private static readonly object _lockerForReport = new object();
        /// <summary>
        /// 同步报告数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_Report> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();
            if (modelList != null)
                modelList = modelList.GroupBy(x => x.ReportID).Select(x => x.FirstOrDefault()).ToList();
            lock (_lockerForReport)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    try
                    {
                        var Id_List = modelList.Select(m => m.ReportID).ToList();

                        var Exit_List = GetModels(m => m.ReportID.In(Id_List));

                        if (Exit_List != null && Exit_List.Count > 0)
                        {
                            var New_List = new List<BUS_Report>();

                            foreach (var item in Exit_List)
                            {
                                var newItem = modelList.SingleOrDefault(m => m.ReportID == item.ReportID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    New_List.Add(newItem);
                                }
                            }
                            UpdateModels(New_List, trans);
                            
                            //var list = (from p in modelList select p.ReportID).Except(from m in Exit_List select m.ReportID).ToList();
                            var Not_List = modelList.Except(New_List).ToList();                                                        
                            if (Not_List != null && Not_List.Count > 0)
                            {
                                InsertModels(Not_List, trans);
                            }

                            //var Not_List = proIds.Except(Exit_List.Select(m => m.ReportID)).ToList();
                            //if (Not_List.Count > 0)
                            //{
                            //    var nonList = (from a in modelList
                            //                   join b in Not_List on a.ReportID equals b
                            //                   select a).ToList();
                            //    InsertModels(nonList, trans);
                            //}
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Report"))
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
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Report", false);
                        resultInfo.Msg = ex.ToString();
                        return resultInfo;
                    }
                }
            }
        }

        #endregion
    }


    public class ReportView
    {
        public BUS_Report Report { get; set; }

        public string SampleName { get; set; }
        public string SampleCode { get; set; }
    }
}
