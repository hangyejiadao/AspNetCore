/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_ModuleButtonRelationData
 * 创建时间：2016-08-14 14:52:59
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_ModuleButtonRelationData : DBBase<SYS_ModuleButtonRelation>, ISYS_ModuleButtonRelationData
    {
        /// <summary>
        /// 管理模块按钮关系
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="listModuleButton"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool ModifyModuleButton(Guid moduleId, List<SYS_ModuleButtonRelation> listModuleButton, DbTrans trans = null)
        {
            var ret = false;
            var hasData = GetModel(m => m.ModuleId == moduleId);

            if (hasData == null || DeleteModelOther<SYS_ModuleButtonRelation>(m => m.ModuleId == moduleId).Result == OperateRetType.Success)
                foreach (var item in listModuleButton)
                {
                    ret = InsertModel(item, trans).Result == OperateRetType.Success;
                }

            return ret;
        }
    }
}
