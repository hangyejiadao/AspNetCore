/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Member
 * 创建时间：2016-09-22 17:38:47
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
	/// 实体类BUS_Member 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Member")]
	[Serializable]
	public partial class BUS_Member : Entity 
	{
		#region Model
		private Guid _MemberId;
		private Guid? _CompanyId;
		private string _Account;
		private string _Pwd;
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
		private string _Address;
		private int _IsEnable;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 管理员Id
		/// </summary>
		public Guid MemberId
		{
			get{ return _MemberId; }
			set
			{
				this.OnPropertyValueChange(_.MemberId,_MemberId,value);
				this._MemberId=value;
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
				_.MemberId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.MemberId,
				_.CompanyId,
				_.Account,
				_.Pwd,
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
				_.Address,
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
				this._MemberId,
				this._CompanyId,
				this._Account,
				this._Pwd,
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
				this._Address,
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
			public readonly static Field All = new Field("*","BUS_Member");
			/// <summary>
			/// 管理员Id
			/// </summary>
			public readonly static Field MemberId = new Field("MemberId","BUS_Member","管理员Id");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","BUS_Member","公司Id");
			/// <summary>
			/// 登录账户
			/// </summary>
			public readonly static Field Account = new Field("Account","BUS_Member","登录账户");
			/// <summary>
			/// 登录密码
			/// </summary>
			public readonly static Field Pwd = new Field("Pwd","BUS_Member","登录密码");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoWidth = new Field("PhotoWidth","BUS_Member","PhotoWidth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoHeight = new Field("PhotoHeight","BUS_Member","PhotoHeight");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PhotoPath = new Field("PhotoPath","BUS_Member","PhotoPath");
			/// <summary>
			/// 昵称
			/// </summary>
			public readonly static Field Nickname = new Field("Nickname","BUS_Member","昵称");
			/// <summary>
			/// 真是姓名
			/// </summary>
			public readonly static Field Realname = new Field("Realname","BUS_Member","真是姓名");
			/// <summary>
			/// 多个微信使用逗号分隔
			/// </summary>
			public readonly static Field WeChat = new Field("WeChat","BUS_Member","多个微信使用逗号分隔");
			/// <summary>
			/// 多个微博使用逗号分隔
			/// </summary>
			public readonly static Field Microblog = new Field("Microblog","BUS_Member","多个微博使用逗号分隔");
			/// <summary>
			/// 多个手机号码使用逗号分隔
			/// </summary>
			public readonly static Field Mobile = new Field("Mobile","BUS_Member","多个手机号码使用逗号分隔");
			/// <summary>
			/// 多个联系电话使用逗号分隔
			/// </summary>
			public readonly static Field Tel = new Field("Tel","BUS_Member","多个联系电话使用逗号分隔");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QQ = new Field("QQ","BUS_Member","QQ");
			/// <summary>
			/// 多个邮箱地址使用逗号分隔
			/// </summary>
			public readonly static Field Email = new Field("Email","BUS_Member","多个邮箱地址使用逗号分隔");
			/// <summary>
			/// 联系地址
			/// </summary>
			public readonly static Field Address = new Field("Address","BUS_Member","联系地址");
			/// <summary>
			/// _1：是（默认）     0：否
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","BUS_Member","_1：是（默认）     0：否");
			/// <summary>
			/// 详细信息
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","BUS_Member","详细信息");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","BUS_Member","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","BUS_Member","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","BUS_Member","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","BUS_Member","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","BUS_Member","修改人");
		}
		#endregion

	}
}

