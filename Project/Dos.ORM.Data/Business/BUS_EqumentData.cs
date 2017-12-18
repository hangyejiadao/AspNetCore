/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_EqumentData
 * 创建时间：2017-02-09 15:42:09
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
using Dos.ORM.Model.BusView;
using KXFramework.Common;
using System.Linq.Expressions;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_EqumentData : DBBase<BUS_Equment>, IBUS_EqumentData
    {
        #region 获取设备基本数据

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BUS_Equment> GetList(Guid organId)
        {
            return DB.DbCont.From<BUS_Equment>().Where(m => m.OrganID == organId).ToEnumerable();
        }

        /// <summary>
        /// 获取设备以及对应照片列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <returns></returns>
        public IEnumerable<EquView> GetListWPic(Guid organId)
        {
            try
            {
                //todo 方1
                var strSql = @"SELECT A.*,B.CutPath FROM BUS_Equment A 
                                LEFT JOIN BUS_File B ON A.EquipmentID=B.ModuleDataId 
                                WHERE A.OrganID='{0}' AND B.OrganId='{0}'";
                var list = DB.DbCont.FromSql(string.Format(strSql, organId)).ToEnumerable<EquView>();

                //todo 方2
                //var select = DB.DbCont.From<BUS_Equment>().LeftJoin<BUS_File>((a, b) => a.EquipmentID == b.ModuleDataId)
                //            .Where(m=>m.OrganID==organId)
                //            .Select(BUS_Equment._.All, BUS_File._.CutPath).ToDataTable();
                //var list = EntityHelper.DataTableToList<EquView>(select); 

                //todo 方3 linq查询多表转成list，子类赋值基类太麻烦，待深究
                //var select = (from a in GetModels()
                //              join b in fileDal.GetModels() on a.EquipmentID equals b.ModuleDataId into g
                //              from g1 in g.DefaultIfEmpty()
                //              where a.OrganID == organId
                //              select new EquView
                //              {    
                //                 ID=a.ID,
                //                 EquipmentID =a.EquipmentID,
                //                 EquipmentName =a.EquipmentName,
                //                 CutPath = g1 == null ? null : g1.CutPath,

                //              }).ToList();

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
                    var model = GetModel(m => m.EquipmentID == id);
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
                    var select = DB.DbCont.From<BUS_Equment>().
                        LeftJoin<BUS_File>((a, b) => a.EquipmentID == b.ModuleDataId).Where(BUS_Equment._.EquipmentID == id).
                        Select(BUS_Equment._.All, BUS_File._.CutPath).ToDataTable();

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

        #region 设备数据同步
        private static readonly object ObjBusEqument = new object();
        /// <summary>
        /// 同步设备数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_Equment> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            lock (ObjBusEqument)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    try
                    {
                        var proIds = modelList.Select(m => m.EquipmentID).ToList();
                        var testerExit = GetModels(m => m.EquipmentID.In(proIds));//重复数据
                        //var testerNon = GetModels(m => m.EquipmentID.NotIn(proIds));//不重复数据
                        if (testerExit != null && testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_Equment>();

                            foreach (var item in testerExit)
                            {
                                var newItem = modelList.FirstOrDefault(m => m.EquipmentID == item.EquipmentID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);

                            var testerNon = proIds.Except(testerExit.Select(m => m.EquipmentID)).ToList();
                            if (testerNon.Count > 0)
                            {
                                var nonList = (from a in modelList
                                               join b in testerNon on a.EquipmentID equals b
                                               select a).ToList();
                                InsertModels(nonList, trans);
                            }
                        }
                        //if (testerNon != null && testerNon.Count > 0)
                        //{
                        //    var testerExitNew = new List<BUS_Equment>();

                        //    foreach (var item in testerNon)
                        //    {
                        //        var newItem = modelList.FirstOrDefault(m => m.EquipmentID == item.EquipmentID);
                        //        if (newItem != null)
                        //        {
                        //            newItem.ID = item.ID;
                        //            testerExitNew.Add(newItem);
                        //        }
                        //    }
                        //    InsertModels(testerExitNew, trans);
                        //}
                        else
                        {
                            //var testerNon = proIds.Except(testerExit.Select(m => m.EquipmentID)).ToList();
                            //if (testerNon.Count > 0)
                            //{
                            //    var nonList = (from a in modelList
                            //                   join b in testerNon on a.EquipmentID equals b
                            //                   select a).ToList();
                            //    InsertModels(nonList, trans);
                            //}
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Equment"))
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
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Equment", false);
                        return resultInfo;
                    }
                }
            }
        }

        #endregion

        public DgListModel<BUS_Equment> GetList(DgConModel dgCon, Expression<Func<BUS_Equment, bool>> whereLambda = null)
        {
            var section = DB.DbCont.From<BUS_Equment>()
                .LeftJoin<BUS_File>((a, b) => a.EquipmentID == b.ModuleDataId)
                .Select(BUS_Equment._.All, BUS_File._.FilePath)
                .Where(whereLambda).OrderBy(GetOrderByClip(dgCon));

            var totalCount = section.Count();
            var retList = section.Page(dgCon.rows, dgCon.page).ToList();

            return new DgListModel<BUS_Equment>(retList, totalCount);
        }

    }

}
