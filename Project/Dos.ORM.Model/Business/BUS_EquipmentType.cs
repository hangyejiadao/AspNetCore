/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_EquipmentType
 * 创建时间：2017-02-21 18:51:25
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
	/// 实体类BUS_EquipmentType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_EquipmentType")]
	public partial class BUS_EquipmentType : Entity 
	{

        //扩展字段
        public string FilePath
        {
            get;
            set;
        }

		#region Model
		private Guid _ID;
		private Guid _EquipmentTypeID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _EquipmentTypeName;
		private int? _EquipmentTypeSort;
		private bool? _IsEnable;
		/// <summary>
		/// 
		/// </summary>
		public Guid ID
		{
			get{ return _ID; }
			set
			{
				this.OnPropertyValueChange(_.ID,_ID,value);
				this._ID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid EquipmentTypeID
		{
			get{ return _EquipmentTypeID; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentTypeID,_EquipmentTypeID,value);
				this._EquipmentTypeID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ProjectID
		{
			get{ return _ProjectID; }
			set
			{
				this.OnPropertyValueChange(_.ProjectID,_ProjectID,value);
				this._ProjectID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? OrganID
		{
			get{ return _OrganID; }
			set
			{
				this.OnPropertyValueChange(_.OrganID,_OrganID,value);
				this._OrganID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EquipmentTypeName
		{
			get{ return _EquipmentTypeName; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentTypeName,_EquipmentTypeName,value);
				this._EquipmentTypeName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EquipmentTypeSort
		{
			get{ return _EquipmentTypeSort; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentTypeSort,_EquipmentTypeSort,value);
				this._EquipmentTypeSort=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsEnable
		{
			get{ return _IsEnable; }
			set
			{
				this.OnPropertyValueChange(_.IsEnable,_IsEnable,value);
				this._IsEnable=value;
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
				_.EquipmentTypeID,
				_.ProjectID,
				_.OrganID,
				_.EquipmentTypeName,
				_.EquipmentTypeSort,
				_.IsEnable};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._EquipmentTypeID,
				this._ProjectID,
				this._OrganID,
				this._EquipmentTypeName,
				this._EquipmentTypeSort,
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
			public readonly static Field All = new Field("*","BUS_EquipmentType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_EquipmentType","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentTypeID = new Field("EquipmentTypeID","BUS_EquipmentType","EquipmentTypeID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_EquipmentType","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_EquipmentType","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentTypeName = new Field("EquipmentTypeName","BUS_EquipmentType","EquipmentTypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentTypeSort = new Field("EquipmentTypeSort","BUS_EquipmentType","EquipmentTypeSort");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","BUS_EquipmentType","IsEnable");
		}
		#endregion

	}
}

