﻿/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：BUS_NewsInfoData
 * 创建时间：2016-09-22 17:38:47
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_NewsInfoData : DBBase<BUS_NewsInfo>, IBUS_NewsInfoData
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public object GetList(DgConModel dgCon, Expression<Func<BUS_NewsInfo, bool>> whereLambda = null)
        {
            var section = DB.DbCont.From<BUS_NewsInfo>()
                .LeftJoin<BUS_NewsType>((a, b) => a.NewsTypeId == b.NewsTypeId)
                .Select(BUS_NewsInfo._.All, BUS_NewsType._.NewsTypeName).Where(whereLambda).OrderBy(GetOrderByClip(dgCon));

            var totalCount = section.Count();
            var retList = section.Page(dgCon.rows, dgCon.page).ToDataTable();

            return new DgListModel(retList, totalCount);
        }
    }
}
