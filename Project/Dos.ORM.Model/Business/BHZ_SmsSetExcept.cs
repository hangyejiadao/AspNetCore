/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_SmsSetExcept
 * 创建时间：2017-07-26 16:28:08
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
    /// 实体类BHZ_SmsSetExcept 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_SmsSetExcept")]
    public partial class BHZ_SmsSetExcept : Entity
    {
        #region Model
        private Guid _ID;
        private Guid _OrganID;
        private Guid _BHJID;
        private int? _UnUpDay;
        private string _AdminName;
        private string _AdminPhone;
        private string _NoticePhone;
        private bool? _IsEnable;
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
        public Guid OrganID
        {
            get { return _OrganID; }
            set
            {
                this.OnPropertyValueChange(_.OrganID, _OrganID, value);
                this._OrganID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid BHJID
        {
            get { return _BHJID; }
            set
            {
                this.OnPropertyValueChange(_.BHJID, _BHJID, value);
                this._BHJID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UnUpDay
        {
            get { return _UnUpDay; }
            set
            {
                this.OnPropertyValueChange(_.UnUpDay, _UnUpDay, value);
                this._UnUpDay = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminName
        {
            get { return _AdminName; }
            set
            {
                this.OnPropertyValueChange(_.AdminName, _AdminName, value);
                this._AdminName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminPhone
        {
            get { return _AdminPhone; }
            set
            {
                this.OnPropertyValueChange(_.AdminPhone, _AdminPhone, value);
                this._AdminPhone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticePhone
        {
            get { return _NoticePhone; }
            set
            {
                this.OnPropertyValueChange(_.NoticePhone, _NoticePhone, value);
                this._NoticePhone = value;
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
				_.OrganID,
				_.BHJID,
				_.UnUpDay,
				_.AdminName,
				_.AdminPhone,
				_.NoticePhone,
				_.IsEnable};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._OrganID,
				this._BHJID,
				this._UnUpDay,
				this._AdminName,
				this._AdminPhone,
				this._NoticePhone,
				this._IsEnable};
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
            public readonly static Field All = new Field("*", "BHZ_SmsSetExcept");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_SmsSetExcept", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BHZ_SmsSetExcept", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BHJID = new Field("BHJID", "BHZ_SmsSetExcept", "BHJID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UnUpDay = new Field("UnUpDay", "BHZ_SmsSetExcept", "UnUpDay");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field AdminName = new Field("AdminName", "BHZ_SmsSetExcept", "AdminName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field AdminPhone = new Field("AdminPhone", "BHZ_SmsSetExcept", "AdminPhone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field NoticePhone = new Field("NoticePhone", "BHZ_SmsSetExcept", "NoticePhone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BHZ_SmsSetExcept", "IsEnable");
        }
        #endregion

    }
}

