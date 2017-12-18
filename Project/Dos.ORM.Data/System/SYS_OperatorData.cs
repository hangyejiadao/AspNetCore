/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_OperatorData
 * 创建时间：2016-08-14 14:52:59
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_OperatorData : DBBase<SYS_Operator>, ISYS_OperatorData
    {
        [Ninject.Inject]
        private ISYS_OperatorDepartmentRelationData SysOperatorDepartmentRelationData { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorRoleRelationData SysOperatorRoleRelationData { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorPostRelationData SysOperatorPostRelationData { get; set; }

        /// <summary>
        /// 删除并添加部门、角色关系
        /// </summary>
        /// <param name="depIds"></param>
        /// <param name="roleIds"></param>
        /// <param name="postIds"></param>
        /// <param name="operatorId"></param>
        /// <param name="crtOptId"></param>
        /// <param name="trans"></param>
        public void SaveDepRoleList(string depIds, string roleIds, string postIds, Guid operatorId, Guid crtOptId, DbTrans trans = null)
        {
            DeleteModelOther<SYS_OperatorDepartmentRelation>(m => m.OperatorId == operatorId);
            if (!string.IsNullOrWhiteSpace(depIds))
            {
                var depIdArr = depIds.TrimEnd(',').Split(',');
                foreach (var item in depIdArr)
                {
                    var addDepRe = new SYS_OperatorDepartmentRelation
                    {
                        OdId = Guid.NewGuid(),
                        DepartmentId = Guid.Parse(item),
                        OperatorId = operatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = crtOptId
                    };
                    SysOperatorDepartmentRelationData.InsertModel(addDepRe, trans);
                }
            }

            DeleteModelOther<SYS_OperatorRoleRelation>(m => m.OperatorId == operatorId, trans);
            if (!string.IsNullOrWhiteSpace(roleIds))
            {
                var roleIdArr = roleIds.TrimEnd(',').Split(',');
                foreach (var item in roleIdArr)
                {
                    var addDepRe = new SYS_OperatorRoleRelation
                    {
                        OrId = Guid.NewGuid(),
                        RoleId = Guid.Parse(item),
                        OperatorId = operatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = crtOptId
                    };
                    SysOperatorRoleRelationData.InsertModel(addDepRe, trans);
                }
            }

            DeleteModelOther<SYS_OperatorPostRelation>(m => m.OperatorId == operatorId, trans);
            if (!string.IsNullOrWhiteSpace(postIds))
            {
                var roleIdArr = postIds.TrimEnd(',').Split(',');
                foreach (var item in roleIdArr)
                {
                    var addPostRe = new SYS_OperatorPostRelation
                    {
                        OpId = Guid.NewGuid(),
                        PostId = Guid.Parse(item),
                        OperatorId = operatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = crtOptId
                    };
                    SysOperatorPostRelationData.InsertModel(addPostRe, trans);
                }
            }
        }
    }
}
