/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Module
 * 创建时间：2017-02-22 16:18:27
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
	/// 实体类BUS_Module 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Module")]
	public partial class BUS_Module : Entity 
	{
        /// <summary>
        /// 模块管理，treegrid父节点Id
        /// </summary>
        public Nullable<Guid> _parentId
        {
            get { return ParentID; }
        }
        /// <summary>
        /// ExtRadioBoxList只接受int，用 是否启用 来代替 IsHide
        /// </summary>
        public int? 是否隐藏
        {
            get
            {
                if (_IsHide == null)
                    return null;
                else if ((bool)_IsHide)
                    return 1;
                else
                    return 0;
            }
            set { this._IsHide = value == 1; }
        }
		#region Model
		private Guid _ID;
		private Guid? _ParentID;
        private string _ModuleCode;
        private string _ModuleName;
        private string _PathURL;
        private int? _OrderNum;
		private string _PicUrl;
		private string _PicCss;
		private bool? _IsHide;
		private string _Note;
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
        public string ModuleCode
		{
            get { return _ModuleCode; }
			set
			{
                this.OnPropertyValueChange(_.ModuleCode, _ModuleCode, value);
                this._ModuleCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
        public string ModuleName
		{
            get { return _ModuleName; }
			set
			{
                this.OnPropertyValueChange(_.ModuleName, _ModuleName, value);
                this._ModuleName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
        public string PathURL
		{
            get { return _PathURL; }
			set
			{
                this.OnPropertyValueChange(_.PathURL, _PathURL, value);
                this._PathURL = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
        public int? OrderNum
        {
            get { return _OrderNum; }
            set
            {
                this.OnPropertyValueChange(_.OrderNum, _OrderNum, value);
                this._OrderNum = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
		public string PicUrl
		{
            get { return _PicUrl; }
			set
			{
                this.OnPropertyValueChange(_.PicUrl, _PicUrl, value);
                this._PicUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicCss
		{
            get { return _PicCss; }
			set
			{
                this.OnPropertyValueChange(_.PicCss, _PicCss, value);
                this._PicCss = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsHide
		{
            get { return _IsHide; }
			set
			{
                this.OnPropertyValueChange(_.IsHide, _IsHide, value);
                this._IsHide = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
            get { return _Note; }
			set
			{
                this.OnPropertyValueChange(_.Note, _Note, value);
                this._Note = value;
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
				_.ParentID,
				_.ModuleCode,
				_.ModuleName,
				_.PathURL,
				_.OrderNum,
				_.PicUrl,
				_.PicCss,
				_.IsHide,
				_.Note};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ParentID,
				this._ModuleCode,
				this._ModuleName,
				this._PathURL,
				this._OrderNum,
				this._PicUrl,
				this._PicCss,
				this._IsHide,
				this._Note};
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
            public readonly static Field All = new Field("*", "BUS_Module");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BUS_Module", "ID");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ParentID = new Field("ParentID", "BUS_Module", "ParentID");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ModuleCode = new Field("ModuleCode", "BUS_Module", "ModuleCode");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ModuleName = new Field("ModuleName", "BUS_Module", "ModuleName");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field PathURL = new Field("PathURL", "BUS_Module", "PathURL");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field OrderNum = new Field("OrderNum", "BUS_Module", "OrderNum");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field PicUrl = new Field("PicUrl", "BUS_Module", "PicUrl");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field PicCss = new Field("PicCss", "BUS_Module", "PicCss");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field IsHide = new Field("IsHide", "BUS_Module", "IsHide");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field Note = new Field("Note", "BUS_Module", "Note");
		}
		#endregion

	}
}

