/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_LogType
 * 创建时间：2016-08-14 14:10:06
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
	/// 实体类SYS_LogType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_LogType")]
	[Serializable]
	public partial class SYS_LogType : Entity 
	{
		#region Model
		private int _LogTypeId;
		private string _LogTypeName;
		private string _Desc;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// _100：登录登出日志  101：数据操作日志  102：异常错误日志  103：一般信息日志  104：其他信息日志
		/// </summary>
		public int LogTypeId
		{
			get{ return _LogTypeId; }
			set
			{
				this.OnPropertyValueChange(_.LogTypeId,_LogTypeId,value);
				this._LogTypeId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogTypeName
		{
			get{ return _LogTypeName; }
			set
			{
				this.OnPropertyValueChange(_.LogTypeName,_LogTypeName,value);
				this._LogTypeName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			get{ return _Desc; }
			set
			{
				this.OnPropertyValueChange(_.Desc,_Desc,value);
				this._Desc=value;
			}
		}
		/// <summary>
		/// _1：正常数据（默认）     0：已删除数据
		/// </summary>
		public int Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status,_Status,value);
				this._Status=value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CrtTime
		{
			get{ return _CrtTime; }
			set
			{
				this.OnPropertyValueChange(_.CrtTime,_CrtTime,value);
				this._CrtTime=value;
			}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid CrtOptId
		{
			get{ return _CrtOptId; }
			set
			{
				this.OnPropertyValueChange(_.CrtOptId,_CrtOptId,value);
				this._CrtOptId=value;
			}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? ModTime
		{
			get{ return _ModTime; }
			set
			{
				this.OnPropertyValueChange(_.ModTime,_ModTime,value);
				this._ModTime=value;
			}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid? ModOptId
		{
			get{ return _ModOptId; }
			set
			{
				this.OnPropertyValueChange(_.ModOptId,_ModOptId,value);
				this._ModOptId=value;
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
				_.LogTypeId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.LogTypeId,
				_.LogTypeName,
				_.Desc,
				_.Status,
				_.CrtTime,
				_.CrtOptId,
				_.ModTime,
				_.ModOptId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._LogTypeId,
				this._LogTypeName,
				this._Desc,
				this._Status,
				this._CrtTime,
				this._CrtOptId,
				this._ModTime,
				this._ModOptId};
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
			public readonly static Field All = new Field("*","SYS_LogType");
			/// <summary>
			/// _100：登录登出日志  101：数据操作日志  102：异常错误日志  103：一般信息日志  104：其他信息日志
			/// </summary>
			public readonly static Field LogTypeId = new Field("LogTypeId","SYS_LogType","_100：登录登出日志  101：数据操作日志  102：异常错误日志  103：一般信息日志  104：其他信息日志");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogTypeName = new Field("LogTypeName","SYS_LogType","LogTypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","SYS_LogType","Desc");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_LogType","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_LogType","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_LogType","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","SYS_LogType","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","SYS_LogType","修改人");
		}
		#endregion

	}
}

