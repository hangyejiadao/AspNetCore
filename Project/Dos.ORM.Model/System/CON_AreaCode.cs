/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：CON_AreaCode
 * 创建时间：2016-11-24 14:23:25
 * 创建人：Quber Tool
 * 创建说明：此代码由工具生成，请谨慎修改！
*****************************************************************************************************/

using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace Dos.ORM.Model.System
{
	/// <summary>
	/// 实体类CON_AreaCode 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("CON_AreaCode")]
	[Serializable]
	public partial class CON_AreaCode : Entity 
	{
		#region Model
		private int _AreaId;
		private int? _AreaCode;
		private int? _ParentAreaCode;
		private string _AreaName;
		private int? _AreaLevel;
		/// <summary>
		/// 
		/// </summary>
		public int AreaId
		{
			get{ return _AreaId; }
			set
			{
				this.OnPropertyValueChange(_.AreaId,_AreaId,value);
				this._AreaId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AreaCode
		{
			get{ return _AreaCode; }
			set
			{
				this.OnPropertyValueChange(_.AreaCode,_AreaCode,value);
				this._AreaCode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentAreaCode
		{
			get{ return _ParentAreaCode; }
			set
			{
				this.OnPropertyValueChange(_.ParentAreaCode,_ParentAreaCode,value);
				this._ParentAreaCode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaName
		{
			get{ return _AreaName; }
			set
			{
				this.OnPropertyValueChange(_.AreaName,_AreaName,value);
				this._AreaName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AreaLevel
		{
			get{ return _AreaLevel; }
			set
			{
				this.OnPropertyValueChange(_.AreaLevel,_AreaLevel,value);
				this._AreaLevel=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.AreaId,
				_.AreaCode,
				_.ParentAreaCode,
				_.AreaName,
				_.AreaLevel};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._AreaId,
				this._AreaCode,
				this._ParentAreaCode,
				this._AreaName,
				this._AreaLevel};
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
			public readonly static Field All = new Field("*","CON_AreaCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AreaId = new Field("AreaId","CON_AreaCode","AreaId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AreaCode = new Field("AreaCode","CON_AreaCode","AreaCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParentAreaCode = new Field("ParentAreaCode","CON_AreaCode","ParentAreaCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AreaName = new Field("AreaName","CON_AreaCode","AreaName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AreaLevel = new Field("AreaLevel","CON_AreaCode","AreaLevel");
		}
		#endregion

	}
}

