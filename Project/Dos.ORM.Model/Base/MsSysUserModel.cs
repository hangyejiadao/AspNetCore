/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Model.BusinessModel
 * 类名称：MsUserModel
 * 创建时间：2015-11-25 14:54:43
 * 创建人：Quber
 * 创建说明：用户相关信息实体（用于保存用户登录后的相关信息）
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using Dos.ORM.Model.System;

namespace Dos.ORM.Model.Base
{
    /// <summary>
    /// 用户相关信息实体（用于保存用户登录后的相关信息）
    /// </summary>
    public class MsSysUserModel
    {
        /// <summary>
        /// 管理员信息
        /// </summary>
        public SYS_Operator Operator { get; set; }

        /// <summary>
        /// 公司信息
        /// </summary>
        public SYS_Company Company { get; set; }

        /// <summary>
        /// 部门信息
        /// </summary>
        public List<SYS_Department> Departments { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public List<SYS_Role> Roles { get; set; }

        ///// <summary>
        ///// 模块列表
        ///// </summary>
        public List<v_SYS_Module> ModuleList { get; set; }

        ///// <summary>
        ///// 按钮列表
        ///// </summary>
        public List<v_SYS_Button> ButtonList { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public bool IsSuperAdmin
        {
            get { return Operator.AccountType == 1; }
        }

        /// <summary>
        /// 管理员类型（1：超级管理员  2：公司总管理员  3：公司普通管理员）
        /// </summary>
        public int? AccountType
        {
            get { return Operator.AccountType; }
        }

        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName
        {
            get
            {
                return string.IsNullOrWhiteSpace(Operator.Realname)
                    ? string.IsNullOrWhiteSpace(Operator.Nickname) ? Operator.Account : Operator.Nickname
                    : string.IsNullOrWhiteSpace(Operator.Realname) ? Operator.Account : Operator.Realname;
            }
        }

        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid? CompanyId
        {
            get { return Operator != null ? Operator.CompanyId : null; }
        }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            get { return Company != null ? Company.CompanyName : null; }
        }

        private bool _IsEnableLog = true;
        /// <summary>
        /// 是否启用记录日志
        /// </summary>
        public bool IsEnableLog
        {
            get { return _IsEnableLog; }
            set { _IsEnableLog = value; }
        }

        ///// <summary>
        ///// 部门名称
        ///// </summary>
        //public string DepartmentName
        //{
        //    get { return Department != null ? Department.DepartmentName : null; }
        //}

        ///// <summary>
        ///// 角色Id
        ///// </summary>
        //public Guid? RoleId
        //{
        //    get { return Operator != null ? Operator.RoleId : Guid.Empty; }
        //}

        ///// <summary>
        ///// 角色名称
        ///// </summary>
        //public string RoleName
        //{
        //    get { return Role != null ? Role.RoleName : null; }
        //}
    }
}
