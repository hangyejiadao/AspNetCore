/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_Operator
 * 创建时间：2016-11-24 15:54:11
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
	/// 实体类SYS_Operator 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_Operator")]
	[Serializable]
	public partial class SYS_Operator : Entity 
	{
		#region Model
		private Guid _OperatorId;
		private Guid? _CompanyId;
		private string _Account;
		private string _Pwd;
		private int? _AccountType;
		private int? _PhotoWidth;
		private int? _PhotoHeight;
		private string _PhotoPath;
		private string _Nickname;
		private string _Realname;
		private string _WeChat;
		private string _Microblog;
		private string _Mobile;
		private string _Tel;
		private string _QQ;
		private string _Email;
		private int? _ProvinceId=-1;
		private int? _CityId=-1;
		private int? _CountyId=-1;
		private int? _TownId=-1;
		private string _Address;
		private string _ThemeName;
		private int _IsEnable=1;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 管理员Id
		/// </summary>
		public Guid OperatorId
		{
			get{ return _OperatorId; }
			set
			{
				this.OnPropertyValueChange(_.OperatorId,_OperatorId,value);
				this._OperatorId=value;
			}
		}
		/// <summary>
		/// 公司Id
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
		/// 登录账户
		/// </summary>
		public string Account
		{
			get{ return _Account; }
			set
			{
				this.OnPropertyValueChange(_.Account,_Account,value);
				this._Account=value;
			}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string Pwd
		{
			get{ return _Pwd; }
			set
			{
				this.OnPropertyValueChange(_.Pwd,_Pwd,value);
				this._Pwd=value;
			}
		}
		/// <summary>
		/// _1：超级管理员  2：公司总管理员  3：公司普通管理员
		/// </summary>
		public int? AccountType
		{
			get{ return _AccountType; }
			set
			{
				this.OnPropertyValueChange(_.AccountType,_AccountType,value);
				this._AccountType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PhotoWidth
		{
			get{ return _PhotoWidth; }
			set
			{
				this.OnPropertyValueChange(_.PhotoWidth,_PhotoWidth,value);
				this._PhotoWidth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PhotoHeight
		{
			get{ return _PhotoHeight; }
			set
			{
				this.OnPropertyValueChange(_.PhotoHeight,_PhotoHeight,value);
				this._PhotoHeight=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoPath
		{
			get{ return _PhotoPath; }
			set
			{
				this.OnPropertyValueChange(_.PhotoPath,_PhotoPath,value);
				this._PhotoPath=value;
			}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname
		{
			get{ return _Nickname; }
			set
			{
				this.OnPropertyValueChange(_.Nickname,_Nickname,value);
				this._Nickname=value;
			}
		}
		/// <summary>
		/// 真是姓名
		/// </summary>
		public string Realname
		{
			get{ return _Realname; }
			set
			{
				this.OnPropertyValueChange(_.Realname,_Realname,value);
				this._Realname=value;
			}
		}
		/// <summary>
		/// 多个微信使用逗号分隔
		/// </summary>
		public string WeChat
		{
			get{ return _WeChat; }
			set
			{
				this.OnPropertyValueChange(_.WeChat,_WeChat,value);
				this._WeChat=value;
			}
		}
		/// <summary>
		/// 多个微博使用逗号分隔
		/// </summary>
		public string Microblog
		{
			get{ return _Microblog; }
			set
			{
				this.OnPropertyValueChange(_.Microblog,_Microblog,value);
				this._Microblog=value;
			}
		}
		/// <summary>
		/// 多个手机号码使用逗号分隔
		/// </summary>
		public string Mobile
		{
			get{ return _Mobile; }
			set
			{
				this.OnPropertyValueChange(_.Mobile,_Mobile,value);
				this._Mobile=value;
			}
		}
		/// <summary>
		/// 多个联系电话使用逗号分隔
		/// </summary>
		public string Tel
		{
			get{ return _Tel; }
			set
			{
				this.OnPropertyValueChange(_.Tel,_Tel,value);
				this._Tel=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			get{ return _QQ; }
			set
			{
				this.OnPropertyValueChange(_.QQ,_QQ,value);
				this._QQ=value;
			}
		}
		/// <summary>
		/// 多个邮箱地址使用逗号分隔
		/// </summary>
		public string Email
		{
			get{ return _Email; }
			set
			{
				this.OnPropertyValueChange(_.Email,_Email,value);
				this._Email=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvinceId
		{
			get{ return _ProvinceId; }
			set
			{
				this.OnPropertyValueChange(_.ProvinceId,_ProvinceId,value);
				this._ProvinceId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityId
		{
			get{ return _CityId; }
			set
			{
				this.OnPropertyValueChange(_.CityId,_CityId,value);
				this._CityId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CountyId
		{
			get{ return _CountyId; }
			set
			{
				this.OnPropertyValueChange(_.CountyId,_CountyId,value);
				this._CountyId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TownId
		{
			get{ return _TownId; }
			set
			{
				this.OnPropertyValueChange(_.TownId,_TownId,value);
				this._TownId=value;
			}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string Address
		{
			get{ return _Address; }
			set
			{
				this.OnPropertyValueChange(_.Address,_Address,value);
				this._Address=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ThemeName
		{
			get{ return _ThemeName; }
			set
			{
				this.OnPropertyValueChange(_.ThemeName,_ThemeName,value);
				this._ThemeName=value;
			}
		}
		/// <summary>
		/// _1：是（默认）     0：否
		/// </summary>
		public int IsEnable
		{
			get{ return _IsEnable; }
			set
			{
				this.OnPropertyValueChange(_.IsEnable,_IsEnable,value);
				this._IsEnable=value;
			}
		}
		/// <summary>
		/// 详细信息
		/// </summary>
		public string DtlInfo
		{
			get{ return _DtlInfo; }
			set
			{
				this.OnPropertyValueChange(_.DtlInfo,_DtlInfo,value);
				this._DtlInfo=value;
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
				_.OperatorId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.OperatorId,
				_.CompanyId,
				_.Account,
				_.Pwd,
				_.AccountType,
				_.PhotoWidth,
				_.PhotoHeight,
				_.PhotoPath,
				_.Nickname,
				_.Realname,
				_.WeChat,
				_.Microblog,
				_.Mobile,
				_.Tel,
				_.QQ,
				_.Email,
				_.ProvinceId,
				_.CityId,
				_.CountyId,
				_.TownId,
				_.Address,
				_.ThemeName,
				_.IsEnable,
				_.DtlInfo,
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
				this._OperatorId,
				this._CompanyId,
				this._Account,
				this._Pwd,
				this._AccountType,
				this._PhotoWidth,
				this._PhotoHeight,
				this._PhotoPath,
				this._Nickname,
				this._Realname,
				this._WeChat,
				this._Microblog,
				this._Mobile,
				this._Tel,
				this._QQ,
				this._Email,
				this._ProvinceId,
				this._CityId,
				this._CountyId,
				this._TownId,
				this._Address,
				this._ThemeName,
				this._IsEnable,
				this._DtlInfo,
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
			public readonly static Field All = new Field("*","SYS_Operator");
			/// <summary>
			/// 管理员Id
			/// </summary>
			public readonly static Field OperatorId = new Field("OperatorId","SYS_Operator","管理员Id");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","SYS_Operator","公司Id");
			/// <summary>
			/// 登录账户
			/// </summary>
			public readonly static Field Account = new Field("Account","SYS_Operator","登录账户");
			/// <summary>
			/// 登录密码
			/// </summary>
			public readonly static Field Pwd = new Field("Pwd","SYS_Operator","登录密码");
			/// <summary>
			/// _1：超级管理员  2：公司总管理员  3：公司普通管理员
			/// </summary>
			public readonly static Field AccountType = new Field("AccountType","SYS_Operator","_1：超级管理员  2：公司总管理员  3：公司普通管理员");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoWidth = new Field("PhotoWidth","SYS_Operator","PhotoWidth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoHeight = new Field("PhotoHeight","SYS_Operator","PhotoHeight");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoPath = new Field("PhotoPath","SYS_Operator","PhotoPath");
			/// <summary>
			/// 昵称
			/// </summary>
			public readonly static Field Nickname = new Field("Nickname","SYS_Operator","昵称");
			/// <summary>
			/// 真是姓名
			/// </summary>
			public readonly static Field Realname = new Field("Realname","SYS_Operator","真是姓名");
			/// <summary>
			/// 多个微信使用逗号分隔
			/// </summary>
			public readonly static Field WeChat = new Field("WeChat","SYS_Operator","多个微信使用逗号分隔");
			/// <summary>
			/// 多个微博使用逗号分隔
			/// </summary>
			public readonly static Field Microblog = new Field("Microblog","SYS_Operator","多个微博使用逗号分隔");
			/// <summary>
			/// 多个手机号码使用逗号分隔
			/// </summary>
			public readonly static Field Mobile = new Field("Mobile","SYS_Operator","多个手机号码使用逗号分隔");
			/// <summary>
			/// 多个联系电话使用逗号分隔
			/// </summary>
			public readonly static Field Tel = new Field("Tel","SYS_Operator","多个联系电话使用逗号分隔");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QQ = new Field("QQ","SYS_Operator","QQ");
			/// <summary>
			/// 多个邮箱地址使用逗号分隔
			/// </summary>
			public readonly static Field Email = new Field("Email","SYS_Operator","多个邮箱地址使用逗号分隔");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProvinceId = new Field("ProvinceId","SYS_Operator","ProvinceId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CityId = new Field("CityId","SYS_Operator","CityId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CountyId = new Field("CountyId","SYS_Operator","CountyId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TownId = new Field("TownId","SYS_Operator","TownId");
			/// <summary>
			/// 联系地址
			/// </summary>
			public readonly static Field Address = new Field("Address","SYS_Operator","联系地址");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ThemeName = new Field("ThemeName","SYS_Operator","ThemeName");
			/// <summary>
			/// _1：是（默认）     0：否
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","SYS_Operator","_1：是（默认）     0：否");
			/// <summary>
			/// 详细信息
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","SYS_Operator","详细信息");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_Operator","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_Operator","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_Operator","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","SYS_Operator","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","SYS_Operator","修改人");
		}
		#endregion

	}
}

