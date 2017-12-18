/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_BHZBHJ
 * 创建时间：2017-06-26 14:46:57
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
    /// 实体类BHZ_BHZBHJ 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_BHZBHJ")]
    public partial class BHZ_BHZBHJ : Entity
    {
        //treegrid父节点Id    
        public Nullable<Guid> _parentId
        {
            get { return _ParentID; }
        }

        public string OrganName { get; set; }


        #region Model
        private Guid _ID;
        private Guid _OrganID;
        private Guid? _ParentID;
        private string _BlendNO;
        private string _BlendName;
        private int? _IsOnline;
        private int? _IsLinkDev;
        private string _Memo;
        private DateTime? _UpdateDate;
        private bool? _Status;
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
        public Guid? ParentID
        {
            get { return _ParentID; }
            set
            {
                this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BlendNO
        {
            get { return _BlendNO; }
            set
            {
                this.OnPropertyValueChange(_.BlendNO, _BlendNO, value);
                this._BlendNO = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BlendName
        {
            get { return _BlendName; }
            set
            {
                this.OnPropertyValueChange(_.BlendName, _BlendName, value);
                this._BlendName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsOnline
        {
            get { return _IsOnline; }
            set
            {
                this.OnPropertyValueChange(_.IsOnline, _IsOnline, value);
                this._IsOnline = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsLinkDev
        {
            get { return _IsLinkDev; }
            set
            {
                this.OnPropertyValueChange(_.IsLinkDev, _IsLinkDev, value);
                this._IsLinkDev = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            get { return _Memo; }
            set
            {
                this.OnPropertyValueChange(_.Memo, _Memo, value);
                this._Memo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            get { return _UpdateDate; }
            set
            {
                this.OnPropertyValueChange(_.UpdateDate, _UpdateDate, value);
                this._UpdateDate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? Status
        {
            get { return _Status; }
            set
            {
                this.OnPropertyValueChange(_.Status, _Status, value);
                this._Status = value;
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
				_.ParentID,
				_.BlendNO,
				_.BlendName,
				_.IsOnline,
				_.IsLinkDev,
				_.Memo,
				_.UpdateDate,
				_.Status};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._OrganID,
				this._ParentID,
				this._BlendNO,
				this._BlendName,
				this._IsOnline,
				this._IsLinkDev,
				this._Memo,
				this._UpdateDate,
				this._Status};
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
            public readonly static Field All = new Field("*", "BHZ_BHZBHJ");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_BHZBHJ", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BHZ_BHZBHJ", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParentID = new Field("ParentID", "BHZ_BHZBHJ", "ParentID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BlendNO = new Field("BlendNO", "BHZ_BHZBHJ", "BlendNO");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BlendName = new Field("BlendName", "BHZ_BHZBHJ", "BlendName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsOnline = new Field("IsOnline", "BHZ_BHZBHJ", "IsOnline");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsLinkDev = new Field("IsLinkDev", "BHZ_BHZBHJ", "IsLinkDev");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Memo = new Field("Memo", "BHZ_BHZBHJ", "Memo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UpdateDate = new Field("UpdateDate", "BHZ_BHZBHJ", "UpdateDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Status = new Field("Status", "BHZ_BHZBHJ", "Status");
        }
        #endregion

    }
}

