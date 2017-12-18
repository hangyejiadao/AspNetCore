/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_SampleType
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
	/// 实体类BUS_SampleType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_SampleType")]
	public partial class BUS_SampleType : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _ParentID;
		private string _TypeName;
		private string _TypeCode;
		private int? _Order;
		private string _Note;
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
		public Guid? ParentID
		{
			get{ return _ParentID; }
			set
			{
				this.OnPropertyValueChange(_.ParentID,_ParentID,value);
				this._ParentID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			get{ return _TypeName; }
			set
			{
				this.OnPropertyValueChange(_.TypeName,_TypeName,value);
				this._TypeName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeCode
		{
			get{ return _TypeCode; }
			set
			{
				this.OnPropertyValueChange(_.TypeCode,_TypeCode,value);
				this._TypeCode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Order
		{
			get{ return _Order; }
			set
			{
				this.OnPropertyValueChange(_.Order,_Order,value);
				this._Order=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			get{ return _Note; }
			set
			{
				this.OnPropertyValueChange(_.Note,_Note,value);
				this._Note=value;
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
				_.TypeName,
				_.TypeCode,
				_.Order,
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
				this._TypeName,
				this._TypeCode,
				this._Order,
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
			public readonly static Field All = new Field("*","BUS_SampleType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_SampleType","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParentID = new Field("ParentID","BUS_SampleType","ParentID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TypeName = new Field("TypeName","BUS_SampleType","TypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TypeCode = new Field("TypeCode","BUS_SampleType","TypeCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Order = new Field("Order","BUS_SampleType","Order");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_SampleType","Note");
		}
		#endregion

	}
}

