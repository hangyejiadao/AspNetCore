/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model
 * 类名称：BUS_Project
 * 创建时间：2017-03-10 10:01:13
 * 创建人：Quber Tool
 * 创建说明：此代码由工具生成，请谨慎修改！
*****************************************************************************************************/

using System;
using Dos.ORM;

namespace Dos.ORM.Model.Business
{
	/// <summary>
    /// 实体类BUS_Project。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Project")]
    [Serializable]
	public partial class BUS_Project : Entity 
	{
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
        #region Model
		private Guid _ID;
		private Guid? _ProjectID;
		private string _ProjectName;
		private string _ProjectShorName;
		private string _ProjectCode;
		private bool? _IsEnable;
		private string _Note;
        private string _DataCollectionUrl;
        private string _SoftUrl;
        private string _BhzApi;
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
		public Guid? ProjectID
		{
            get { return _ProjectID; }
			set
			{
                this.OnPropertyValueChange(_.ProjectID, _ProjectID, value);
                this._ProjectID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
            get { return _ProjectName; }
			set
			{
                this.OnPropertyValueChange(_.ProjectName, _ProjectName, value);
                this._ProjectName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectShorName
		{
            get { return _ProjectShorName; }
			set
			{
                this.OnPropertyValueChange(_.ProjectShorName, _ProjectShorName, value);
                this._ProjectShorName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectCode
		{
            get { return _ProjectCode; }
			set
			{
                this.OnPropertyValueChange(_.ProjectCode, _ProjectCode, value);
                this._ProjectCode = value;
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
		public string Note
		{
            get { return _Note; }
            set
            {
                this.OnPropertyValueChange(_.Note, _Note, value);
                this._Note = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataCollectionUrl
        {
            get { return _DataCollectionUrl; }
			set
			{
                this.OnPropertyValueChange(_.DataCollectionUrl, _DataCollectionUrl, value);
                this._DataCollectionUrl = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
        public string BhzApi
        {
            get { return _BhzApi; }
            set
            {
                this.OnPropertyValueChange(_.BhzApi, _BhzApi, value);
                this._BhzApi = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SoftUrl
        {
            get { return _SoftUrl; }
            set
            {
                this.OnPropertyValueChange(_.SoftUrl, _SoftUrl, value);
                this._SoftUrl = value;
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
                _.ID,
            };
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.ID,
				_.ProjectID,
				_.ProjectName,
				_.ProjectShorName,
				_.ProjectCode,
				_.IsEnable,
				_.Note,
				_.DataCollectionUrl,
                _.BhzApi,                
				_.SoftUrl};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ProjectID,
				this._ProjectName,
				this._ProjectShorName,
				this._ProjectCode,
				this._IsEnable,
				this._Note,
				this._DataCollectionUrl,
                this._BhzApi,
				this._SoftUrl};
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
            public readonly static Field All = new Field("*", "BUS_Project");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BUS_Project", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ProjectID = new Field("ProjectID", "BUS_Project", "ProjectID");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ProjectName = new Field("ProjectName", "BUS_Project", "ProjectName");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ProjectShorName = new Field("ProjectShorName", "BUS_Project", "ProjectShorName");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field ProjectCode = new Field("ProjectCode", "BUS_Project", "ProjectCode");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BUS_Project", "IsEnable");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field Note = new Field("Note", "BUS_Project", "Note");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field DataCollectionUrl = new Field("DataCollectionUrl", "BUS_Project", "DataCollectionUrl");
			/// <summary>
			/// 
			/// </summary>
            public readonly static Field BhzApi = new Field("BhzApi", "BUS_Project", "BhzApi");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SoftUrl = new Field("SoftUrl", "BUS_Project", "SoftUrl");
		}
		#endregion
	}
}
