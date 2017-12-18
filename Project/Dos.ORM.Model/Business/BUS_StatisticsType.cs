/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_StatisticsType
 * 创建时间：2017-03-03 11:53:40
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
	/// 实体类BUS_StatisticsType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_StatisticsType")]
	public partial class BUS_StatisticsType : Entity 
	{
		#region Model
		private Guid _ID;
		private string _TypeName;
		private string _TypeCode;
		private string _Unit;
		private int? _Order;
		private bool? _IsScene;
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
		public string Unit
		{
			get{ return _Unit; }
			set
			{
				this.OnPropertyValueChange(_.Unit,_Unit,value);
				this._Unit=value;
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
		public bool? IsScene
		{
			get{ return _IsScene; }
			set
			{
				this.OnPropertyValueChange(_.IsScene,_IsScene,value);
				this._IsScene=value;
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
				_.TypeName,
				_.TypeCode,
				_.Unit,
				_.Order,
				_.IsScene};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._TypeName,
				this._TypeCode,
				this._Unit,
				this._Order,
				this._IsScene};
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
			public readonly static Field All = new Field("*","BUS_StatisticsType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_StatisticsType","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TypeName = new Field("TypeName","BUS_StatisticsType","TypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TypeCode = new Field("TypeCode","BUS_StatisticsType","TypeCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Unit = new Field("Unit","BUS_StatisticsType","Unit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Order = new Field("Order","BUS_StatisticsType","Order");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsScene = new Field("IsScene","BUS_StatisticsType","IsScene");
		}
		#endregion

	}
}

