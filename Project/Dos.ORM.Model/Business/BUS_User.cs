/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_User
 * 创建时间：2017-02-09 15:42:10
 * 创建人：Quber Tool
 * 创建说明：此代码由工具生成，请谨慎修改！
*****************************************************************************************************/

using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace Dos.ORM.Model.Business
{
    /// <summary>
    /// 实体类BUS_User 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BUS_User")]
    public partial class BUS_User : Entity
    {
        #region Model
        private Guid _ID;
        private string _Account;
        private string _Password;
        private string _Mobile;
        private string _FullName;
        private string _Job;
        private string _OrganName;
        private bool? _IsEnable;
        private DateTime? _CreateDate;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set
            {
                this.OnPropertyValueChange(_.Account, _Account, value);
                this._Account = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set
            {
                this.OnPropertyValueChange(_.Password, _Password, value);
                this._Password = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                this.OnPropertyValueChange(_.Mobile, _Mobile, value);
                this._Mobile = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FullName
        {
            get { return _FullName; }
            set
            {
                this.OnPropertyValueChange(_.FullName, _FullName, value);
                this._FullName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job
        {
            get { return _Job; }
            set
            {
                this.OnPropertyValueChange(_.Job, _Job, value);
                this._Job = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrganName
        {
            get { return _OrganName; }
            set
            {
                this.OnPropertyValueChange(_.OrganName, _OrganName, value);
                this._OrganName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsEnable
        {
            get { return _IsEnable; }
            set
            {
                this.OnPropertyValueChange(_.IsEnable, _IsEnable, value);
                this._IsEnable = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                this.OnPropertyValueChange(_.CreateDate, _CreateDate, value);
                this._CreateDate = value;
            }
        }
        /// <summary>
        /// ExtRadioBoxList只接受int，用 是否启用 来代替 IsEnable
        /// </summary>
        public int? 是否启用
        {
            get
            {
                if (_IsEnable == null)
                    return null;
                else if ((bool)_IsEnable)
                    return 1;
                else
                    return 0;
            }
            set { this.IsEnable = value == 1; }
        }
        public string 所属角色 { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.ID};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.Account,
				_.Password,
				_.Mobile,
				_.FullName,
				_.Job,
				_.OrganName,
				_.IsEnable,
				_.CreateDate};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._Account,
				this._Password,
				this._Mobile,
				this._FullName,
				this._Job,
				this._OrganName,
				this._IsEnable,
				this._CreateDate};
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "BUS_User");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BUS_User", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Account = new Field("Account", "BUS_User", "Account");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Password = new Field("Password", "BUS_User", "Password");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Mobile = new Field("Mobile", "BUS_User", "Mobile");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field FullName = new Field("FullName", "BUS_User", "FullName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Job = new Field("Job", "BUS_User", "Job");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganName = new Field("OrganName", "BUS_User", "OrganName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BUS_User", "IsEnable");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CreateDate = new Field("CreateDate", "BUS_User", "CreateDate");
        }
        #endregion

    }
}

