/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_LogInfo
 * 创建时间：2016-09-03 13:56:28
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
	/// 实体类SYS_LogInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_LogInfo")]
	[Serializable]
	public partial class SYS_LogInfo : Entity 
	{
		#region Model
		private Guid _LogId;
		private int? _LogTypeId;
		private string _LogTypeName;
		private Guid? _CompanyId;
		private string _DataId;
		private Guid? _OptUserId;
		private string _OptUserName;
		private DateTime _OptTime;
		private string _OptModuleName;
		private string _OptModulePath;
		private int? _OptTypeId;
		private string _OptTypeName;
		private int? _OptResultId;
		private string _OptResultName;
		private string _OptSystem;
		private string _Browser;
		private string _IP;
		private string _Mac;
		private string _Desc;
		private int _Status;
		/// <summary>
		/// 
		/// </summary>
		public Guid LogId
		{
			get{ return _LogId; }
			set
			{
				this.OnPropertyValueChange(_.LogId,_LogId,value);
				this._LogId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogTypeId
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
		public Guid? CompanyId
		{
			get{ return _CompanyId; }
			set
			{
				this.OnPropertyValueChange(_.CompanyId,_CompanyId,value);
				this._CompanyId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataId
		{
			get{ return _DataId; }
			set
			{
				this.OnPropertyValueChange(_.DataId,_DataId,value);
				this._DataId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? OptUserId
		{
			get{ return _OptUserId; }
			set
			{
				this.OnPropertyValueChange(_.OptUserId,_OptUserId,value);
				this._OptUserId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptUserName
		{
			get{ return _OptUserName; }
			set
			{
				this.OnPropertyValueChange(_.OptUserName,_OptUserName,value);
				this._OptUserName=value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime OptTime
		{
			get{ return _OptTime; }
			set
			{
				this.OnPropertyValueChange(_.OptTime,_OptTime,value);
				this._OptTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptModuleName
		{
			get{ return _OptModuleName; }
			set
			{
				this.OnPropertyValueChange(_.OptModuleName,_OptModuleName,value);
				this._OptModuleName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptModulePath
		{
			get{ return _OptModulePath; }
			set
			{
				this.OnPropertyValueChange(_.OptModulePath,_OptModulePath,value);
				this._OptModulePath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OptTypeId
		{
			get{ return _OptTypeId; }
			set
			{
				this.OnPropertyValueChange(_.OptTypeId,_OptTypeId,value);
				this._OptTypeId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptTypeName
		{
			get{ return _OptTypeName; }
			set
			{
				this.OnPropertyValueChange(_.OptTypeName,_OptTypeName,value);
				this._OptTypeName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OptResultId
		{
			get{ return _OptResultId; }
			set
			{
				this.OnPropertyValueChange(_.OptResultId,_OptResultId,value);
				this._OptResultId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptResultName
		{
			get{ return _OptResultName; }
			set
			{
				this.OnPropertyValueChange(_.OptResultName,_OptResultName,value);
				this._OptResultName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OptSystem
		{
			get{ return _OptSystem; }
			set
			{
				this.OnPropertyValueChange(_.OptSystem,_OptSystem,value);
				this._OptSystem=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Browser
		{
			get{ return _Browser; }
			set
			{
				this.OnPropertyValueChange(_.Browser,_Browser,value);
				this._Browser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			get{ return _IP; }
			set
			{
				this.OnPropertyValueChange(_.IP,_IP,value);
				this._IP=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mac
		{
			get{ return _Mac; }
			set
			{
				this.OnPropertyValueChange(_.Mac,_Mac,value);
				this._Mac=value;
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
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.LogId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.LogId,
				_.LogTypeId,
				_.LogTypeName,
				_.CompanyId,
				_.DataId,
				_.OptUserId,
				_.OptUserName,
				_.OptTime,
				_.OptModuleName,
				_.OptModulePath,
				_.OptTypeId,
				_.OptTypeName,
				_.OptResultId,
				_.OptResultName,
				_.OptSystem,
				_.Browser,
				_.IP,
				_.Mac,
				_.Desc,
				_.Status};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._LogId,
				this._LogTypeId,
				this._LogTypeName,
				this._CompanyId,
				this._DataId,
				this._OptUserId,
				this._OptUserName,
				this._OptTime,
				this._OptModuleName,
				this._OptModulePath,
				this._OptTypeId,
				this._OptTypeName,
				this._OptResultId,
				this._OptResultName,
				this._OptSystem,
				this._Browser,
				this._IP,
				this._Mac,
				this._Desc,
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
			public readonly static Field All = new Field("*","SYS_LogInfo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogId = new Field("LogId","SYS_LogInfo","LogId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogTypeId = new Field("LogTypeId","SYS_LogInfo","LogTypeId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogTypeName = new Field("LogTypeName","SYS_LogInfo","LogTypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","SYS_LogInfo","CompanyId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DataId = new Field("DataId","SYS_LogInfo","DataId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptUserId = new Field("OptUserId","SYS_LogInfo","OptUserId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptUserName = new Field("OptUserName","SYS_LogInfo","OptUserName");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field OptTime = new Field("OptTime","SYS_LogInfo","创建时间");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptModuleName = new Field("OptModuleName","SYS_LogInfo","OptModuleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptModulePath = new Field("OptModulePath","SYS_LogInfo","OptModulePath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptTypeId = new Field("OptTypeId","SYS_LogInfo","OptTypeId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptTypeName = new Field("OptTypeName","SYS_LogInfo","OptTypeName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptResultId = new Field("OptResultId","SYS_LogInfo","OptResultId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptResultName = new Field("OptResultName","SYS_LogInfo","OptResultName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OptSystem = new Field("OptSystem","SYS_LogInfo","OptSystem");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Browser = new Field("Browser","SYS_LogInfo","Browser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IP = new Field("IP","SYS_LogInfo","IP");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Mac = new Field("Mac","SYS_LogInfo","Mac");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","SYS_LogInfo","Desc");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_LogInfo","_1：正常数据（默认）     0：已删除数据");
		}
		#endregion

	}
}

