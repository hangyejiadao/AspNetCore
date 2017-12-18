/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_ButtonData
 * 创建时间：2016-09-21 16:22:38
 * 创建人：Quber
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
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_ButtonData : IDBBase<SYS_Button>
    {
        /// <summary>
        /// 获取模块管理所需的所有按钮
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="allBtns"></param>
        /// <param name="moduleButtonList"></param>
        /// <returns></returns>
        List<ZTreeModel> GetButtonsForModule(Guid moduleId, List<SYS_Button> allBtns, List<SYS_ModuleButtonRelation> moduleButtonList);
    }
}
