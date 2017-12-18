/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：BUS_MixingPlanData
 * 创建时间：2017-03-07 11:24:29
 * 创建人：MS-20170220SVOI
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
using Dos.ORM.Model.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using Dos.ORM.Common.Enums;

namespace Dos.ORM.Data.Business
{

    /// <summary>
    /// 拌合站数据交互
    /// </summary>
    public class BUS_MixingPlanData : DBBase<BUS_MixingPlan>, IBUS_MixingPlanData
    {
        private static object obj = new object();
        /// <summary>
        /// 分页查询拌合站数据
        /// </summary>
        /// <param name="organId"></param>
        /// <returns></returns>
        public Page<BUS_MixingPlan> GetList(Guid organId, int pageindex, int pagesize)
        {
            int totalcount = 0;
            var r = ExtPage(pageindex, pagesize, ref totalcount, w => w.OrganID == organId);
            return r;
        }
        /// <summary>
        /// 批量插入拌合站数据
        /// </summary>
        /// <param name="modelList">待更新拌合站列表</param>
        /// <param name="projectId">项目ID</param>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        public Model.Base.OperateModel AddModelList(IList<BUS_MixingPlan> modelList, Guid projectId, string timeStamp)
        {
            if (modelList == null || modelList.Count <= 0)
            {
                return new OperateModel(OperateRetType.Fail, "modelList不能为空");
            }
            else if (modelList.Count > 20)
            {
                return new OperateModel(OperateRetType.Fail, "一次最多只能传20条数据");
            }
            modelList = modelList.GroupBy(x => x.OrganID).Select(x => x.FirstOrDefault()).ToList();
            OperateModel resultInfo = new OperateModel();
            lock (obj)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    var listIds = modelList.Select(x => x.OrganID).ToList();
                    var exitIds = GetModelsSql("SELECT * FROM BUS_MixingPlan WHERE OrganID IN('" + string.Join("','", listIds) + "')");//数据库存在的
                    if (exitIds != null && exitIds.Count > 0)
                    {
                        var existsModels = new List<BUS_MixingPlan>();
                        foreach (var item in exitIds)
                        {
                            var r = modelList.FirstOrDefault(x => x.OrganID == item.OrganID);
                            r.ID = item.ID;
                            existsModels.Add(r);
                        }
                        var nonList = modelList.Except(existsModels).ToList();
                        try
                        {
                            UpdateModels(existsModels, trans);
                            if (nonList != null && nonList.Count > 0)
                                InsertModels(nonList, trans);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_MixingPlan", false);
                            return new OperateModel(OperateRetType.Fail, "fail");
                        }
                    }
                    else
                    {
                        try
                        {
                            InsertModels(modelList.ToList(), trans);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_MixingPlan", false);
                            return new OperateModel(OperateRetType.Fail, "fail");
                        }
                    }
                    if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_MixingPlan"))
                    {
                        resultInfo.Result = OperateRetType.Success;
                        resultInfo.Msg = "操作成功";
                        resultInfo.Data = true;
                    }
                    trans.Commit();
                    return resultInfo;
                }
            }
        }
    }
}
