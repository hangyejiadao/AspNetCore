/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_SmsSetTwo
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
    /// 实体类BHZ_SmsSetTwo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_SmsSetTwo")]
    public partial class BHZ_SmsSetTwo : Entity
    {
        public string OrganName { get; set; }

        #region Model
        private Guid _ID;
        private Guid _OrganID;
        private string _SendType;
        private string _MobilePhone;
        private int? _OverQty;
        private string _TempletText;
        private DateTime? _NextExec;
        private string _Seconds;
        private string _Minutes;
        private string _Hours;
        private string _Day;
        private string _Month;
        private string _Week;
        private string _Year;
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
        public string SendType
        {
            get { return _SendType; }
            set
            {
                this.OnPropertyValueChange(_.SendType, _SendType, value);
                this._SendType = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone
        {
            get { return _MobilePhone; }
            set
            {
                this.OnPropertyValueChange(_.MobilePhone, _MobilePhone, value);
                this._MobilePhone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OverQty
        {
            get { return _OverQty; }
            set
            {
                this.OnPropertyValueChange(_.OverQty, _OverQty, value);
                this._OverQty = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TempletText
        {
            get { return _TempletText; }
            set
            {
                this.OnPropertyValueChange(_.TempletText, _TempletText, value);
                this._TempletText = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? NextExec
        {
            get { return _NextExec; }
            set
            {
                this.OnPropertyValueChange(_.NextExec, _NextExec, value);
                this._NextExec = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Seconds
        {
            get { return _Seconds; }
            set
            {
                this.OnPropertyValueChange(_.Seconds, _Seconds, value);
                this._Seconds = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Minutes
        {
            get { return _Minutes; }
            set
            {
                this.OnPropertyValueChange(_.Minutes, _Minutes, value);
                this._Minutes = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hours
        {
            get { return _Hours; }
            set
            {
                this.OnPropertyValueChange(_.Hours, _Hours, value);
                this._Hours = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Day
        {
            get { return _Day; }
            set
            {
                this.OnPropertyValueChange(_.Day, _Day, value);
                this._Day = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Month
        {
            get { return _Month; }
            set
            {
                this.OnPropertyValueChange(_.Month, _Month, value);
                this._Month = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Week
        {
            get { return _Week; }
            set
            {
                this.OnPropertyValueChange(_.Week, _Week, value);
                this._Week = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get { return _Year; }
            set
            {
                this.OnPropertyValueChange(_.Year, _Year, value);
                this._Year = value;
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
				_.SendType,
				_.MobilePhone,
				_.OverQty,
				_.TempletText,
				_.NextExec,
				_.Seconds,
				_.Minutes,
				_.Hours,
				_.Day,
				_.Month,
				_.Week,
				_.Year,
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
				this._SendType,
				this._MobilePhone,
				this._OverQty,
				this._TempletText,
				this._NextExec,
				this._Seconds,
				this._Minutes,
				this._Hours,
				this._Day,
				this._Month,
				this._Week,
				this._Year,
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
            public readonly static Field All = new Field("*", "BHZ_SmsSetTwo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_SmsSetTwo", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BHZ_SmsSetTwo", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SendType = new Field("SendType", "BHZ_SmsSetTwo", "SendType");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MobilePhone = new Field("MobilePhone", "BHZ_SmsSetTwo", "MobilePhone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OverQty = new Field("OverQty", "BHZ_SmsSetTwo", "OverQty");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field TempletText = new Field("TempletText", "BHZ_SmsSetTwo", "TempletText");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field NextExec = new Field("NextExec", "BHZ_SmsSetTwo", "NextExec");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Seconds = new Field("Seconds", "BHZ_SmsSetTwo", "Seconds");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Minutes = new Field("Minutes", "BHZ_SmsSetTwo", "Minutes");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Hours = new Field("Hours", "BHZ_SmsSetTwo", "Hours");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Day = new Field("Day", "BHZ_SmsSetTwo", "Day");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Month = new Field("Month", "BHZ_SmsSetTwo", "Month");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Week = new Field("Week", "BHZ_SmsSetTwo", "Week");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Year = new Field("Year", "BHZ_SmsSetTwo", "Year");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BHZ_SmsSetTwo", "IsEnable");
        }
        #endregion

    }
}

