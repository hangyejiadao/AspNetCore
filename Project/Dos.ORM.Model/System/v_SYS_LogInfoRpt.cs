/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：v_SYS_LogInfoRpt
 * 创建时间：2016-09-17 12:34:02
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
	/// 实体类v_SYS_LogInfoRpt 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("v_SYS_LogInfoRpt")]
	[Serializable]
	public partial class v_SYS_LogInfoRpt : Entity 
	{
		#region Model
		private int? _LogYear;
		private int? _LogMonth;
		private int? _LogDay;
		private int? _LogCount;
		private Guid? _OperatorId;
		private string _UserName;
		private Guid? _CompanyId;
		/// <summary>
		/// 
		/// </summary>
		public int? LogYear
		{
			get{ return _LogYear; }
			set
			{
				this.OnPropertyValueChange(_.LogYear,_LogYear,value);
				this._LogYear=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogMonth
		{
			get{ return _LogMonth; }
			set
			{
				this.OnPropertyValueChange(_.LogMonth,_LogMonth,value);
				this._LogMonth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogDay
		{
			get{ return _LogDay; }
			set
			{
				this.OnPropertyValueChange(_.LogDay,_LogDay,value);
				this._LogDay=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogCount
		{
			get{ return _LogCount; }
			set
			{
				this.OnPropertyValueChange(_.LogCount,_LogCount,value);
				this._LogCount=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? OperatorId
		{
			get{ return _OperatorId; }
			set
			{
				this.OnPropertyValueChange(_.OperatorId,_OperatorId,value);
				this._OperatorId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			get{ return _UserName; }
			set
			{
				this.OnPropertyValueChange(_.UserName,_UserName,value);
				this._UserName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? CompanyId
		{
			get{ return _CompanyId; }
			set
			{
				this.OnPropertyValueChange(_.CompanyId,_CompanyId,value);
				this._CompanyId=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 是否只读
		/// </summary>
		public override bool IsReadOnly()
		{
			return true;
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.LogYear,
				_.LogMonth,
				_.LogDay,
				_.LogCount,
				_.OperatorId,
				_.UserName,
				_.CompanyId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._LogYear,
				this._LogMonth,
				this._LogDay,
				this._LogCount,
				this._OperatorId,
				this._UserName,
				this._CompanyId};
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
			public readonly static Field All = new Field("*","v_SYS_LogInfoRpt");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogYear = new Field("LogYear","v_SYS_LogInfoRpt","LogYear");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogMonth = new Field("LogMonth","v_SYS_LogInfoRpt","LogMonth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogDay = new Field("LogDay","v_SYS_LogInfoRpt","LogDay");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogCount = new Field("LogCount","v_SYS_LogInfoRpt","LogCount");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OperatorId = new Field("OperatorId","v_SYS_LogInfoRpt","OperatorId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserName = new Field("UserName","v_SYS_LogInfoRpt","UserName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","v_SYS_LogInfoRpt","CompanyId");
		}
		#endregion

	}
}

