/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_SmsSetOne
 * 创建时间：2017-08-01 10:38:01
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
    /// 实体类BHZ_SmsSetOne 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_SmsSetOne")]
    public partial class BHZ_SmsSetOne : Entity
    {
        #region Model
        private Guid _ID;
        private Guid _OrganID;
        private string _One_Phone;
        private string _Two_Phone;
        private string _Three_Phone;
        private string _Four_Phone;
        private int? _One_Timer;
        private int? _Two_Timer;
        private int? _Three_Timer;
        private int? _Four_Timer;
        private int? _Over_Timer;
        private string _TempletText;
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
        public string One_Phone
        {
            get { return _One_Phone; }
            set
            {
                this.OnPropertyValueChange(_.One_Phone, _One_Phone, value);
                this._One_Phone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Two_Phone
        {
            get { return _Two_Phone; }
            set
            {
                this.OnPropertyValueChange(_.Two_Phone, _Two_Phone, value);
                this._Two_Phone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Three_Phone
        {
            get { return _Three_Phone; }
            set
            {
                this.OnPropertyValueChange(_.Three_Phone, _Three_Phone, value);
                this._Three_Phone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Four_Phone
        {
            get { return _Four_Phone; }
            set
            {
                this.OnPropertyValueChange(_.Four_Phone, _Four_Phone, value);
                this._Four_Phone = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? One_Timer
        {
            get { return _One_Timer; }
            set
            {
                this.OnPropertyValueChange(_.One_Timer, _One_Timer, value);
                this._One_Timer = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Two_Timer
        {
            get { return _Two_Timer; }
            set
            {
                this.OnPropertyValueChange(_.Two_Timer, _Two_Timer, value);
                this._Two_Timer = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Three_Timer
        {
            get { return _Three_Timer; }
            set
            {
                this.OnPropertyValueChange(_.Three_Timer, _Three_Timer, value);
                this._Three_Timer = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Four_Timer
        {
            get { return _Four_Timer; }
            set
            {
                this.OnPropertyValueChange(_.Four_Timer, _Four_Timer, value);
                this._Four_Timer = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Over_Timer
        {
            get { return _Over_Timer; }
            set
            {
                this.OnPropertyValueChange(_.Over_Timer, _Over_Timer, value);
                this._Over_Timer = value;
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
				_.One_Phone,
				_.Two_Phone,
				_.Three_Phone,
				_.Four_Phone,
				_.One_Timer,
				_.Two_Timer,
				_.Three_Timer,
				_.Four_Timer,
				_.Over_Timer,
				_.TempletText,
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
				this._One_Phone,
				this._Two_Phone,
				this._Three_Phone,
				this._Four_Phone,
				this._One_Timer,
				this._Two_Timer,
				this._Three_Timer,
				this._Four_Timer,
				this._Over_Timer,
				this._TempletText,
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
            public readonly static Field All = new Field("*", "BHZ_SmsSetOne");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_SmsSetOne", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BHZ_SmsSetOne", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_Phone = new Field("One_Phone", "BHZ_SmsSetOne", "One_Phone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_Phone = new Field("Two_Phone", "BHZ_SmsSetOne", "Two_Phone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_Phone = new Field("Three_Phone", "BHZ_SmsSetOne", "Three_Phone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_Phone = new Field("Four_Phone", "BHZ_SmsSetOne", "Four_Phone");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_Timer = new Field("One_Timer", "BHZ_SmsSetOne", "One_Timer");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_Timer = new Field("Two_Timer", "BHZ_SmsSetOne", "Two_Timer");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_Timer = new Field("Three_Timer", "BHZ_SmsSetOne", "Three_Timer");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_Timer = new Field("Four_Timer", "BHZ_SmsSetOne", "Four_Timer");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Over_Timer = new Field("Over_Timer", "BHZ_SmsSetOne", "Over_Timer");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field TempletText = new Field("TempletText", "BHZ_SmsSetOne", "TempletText");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BHZ_SmsSetOne", "IsEnable");
        }
        #endregion

    }
}

