/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_Company
 * 创建时间：2016-11-24 15:56:32
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
	/// 实体类SYS_Company 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_Company")]
	[Serializable]
	public partial class SYS_Company : Entity 
	{
		#region Model
		private Guid _CompanyId;
		private Guid? _ParentId;
		private string _CompanyName;
		private string _ConMan;
		private string _WeChat;
		private string _Microblog;
		private string _Mobile;
		private string _Tel;
		private string _Email;
        private int? _ProvinceId = -1;
        private int? _CityId = -1;
        private int? _CountyId = -1;
        private int? _TownId = -1;
		private string _Address;
		private int? _LogoWidth;
		private int? _LogoHeight;
		private string _LogoPath;
		private string _Lng;
		private string _Lat;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 公司Id
		/// </summary>
		public Guid CompanyId
		{
			get{ return _CompanyId; }
			set
			{
				this.OnPropertyValueChange(_.CompanyId,_CompanyId,value);
				this._CompanyId=value;
			}
		}
		/// <summary>
		/// 父级Id
		/// </summary>
		public Guid? ParentId
		{
			get{ return _ParentId; }
			set
			{
				this.OnPropertyValueChange(_.ParentId,_ParentId,value);
				this._ParentId=value;
			}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string CompanyName
		{
			get{ return _CompanyName; }
			set
			{
				this.OnPropertyValueChange(_.CompanyName,_CompanyName,value);
				this._CompanyName=value;
			}
		}
		/// <summary>
		/// 多个联系人使用逗号分隔
		/// </summary>
		public string ConMan
		{
			get{ return _ConMan; }
			set
			{
				this.OnPropertyValueChange(_.ConMan,_ConMan,value);
				this._ConMan=value;
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
		public int? LogoWidth
		{
			get{ return _LogoWidth; }
			set
			{
				this.OnPropertyValueChange(_.LogoWidth,_LogoWidth,value);
				this._LogoWidth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogoHeight
		{
			get{ return _LogoHeight; }
			set
			{
				this.OnPropertyValueChange(_.LogoHeight,_LogoHeight,value);
				this._LogoHeight=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogoPath
		{
			get{ return _LogoPath; }
			set
			{
				this.OnPropertyValueChange(_.LogoPath,_LogoPath,value);
				this._LogoPath=value;
			}
		}
		/// <summary>
		/// 经度
		/// </summary>
		public string Lng
		{
			get{ return _Lng; }
			set
			{
				this.OnPropertyValueChange(_.Lng,_Lng,value);
				this._Lng=value;
			}
		}
		/// <summary>
		/// 纬度
		/// </summary>
		public string Lat
		{
			get{ return _Lat; }
			set
			{
				this.OnPropertyValueChange(_.Lat,_Lat,value);
				this._Lat=value;
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
				_.CompanyId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.CompanyId,
				_.ParentId,
				_.CompanyName,
				_.ConMan,
				_.WeChat,
				_.Microblog,
				_.Mobile,
				_.Tel,
				_.Email,
				_.ProvinceId,
				_.CityId,
				_.CountyId,
				_.TownId,
				_.Address,
				_.LogoWidth,
				_.LogoHeight,
				_.LogoPath,
				_.Lng,
				_.Lat,
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
				this._CompanyId,
				this._ParentId,
				this._CompanyName,
				this._ConMan,
				this._WeChat,
				this._Microblog,
				this._Mobile,
				this._Tel,
				this._Email,
				this._ProvinceId,
				this._CityId,
				this._CountyId,
				this._TownId,
				this._Address,
				this._LogoWidth,
				this._LogoHeight,
				this._LogoPath,
				this._Lng,
				this._Lat,
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
			public readonly static Field All = new Field("*","SYS_Company");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","SYS_Company","公司Id");
			/// <summary>
			/// 父级Id
			/// </summary>
			public readonly static Field ParentId = new Field("ParentId","SYS_Company","父级Id");
			/// <summary>
			/// 公司名称
			/// </summary>
			public readonly static Field CompanyName = new Field("CompanyName","SYS_Company","公司名称");
			/// <summary>
			/// 多个联系人使用逗号分隔
			/// </summary>
			public readonly static Field ConMan = new Field("ConMan","SYS_Company","多个联系人使用逗号分隔");
			/// <summary>
			/// 多个微信使用逗号分隔
			/// </summary>
			public readonly static Field WeChat = new Field("WeChat","SYS_Company","多个微信使用逗号分隔");
			/// <summary>
			/// 多个微博使用逗号分隔
			/// </summary>
			public readonly static Field Microblog = new Field("Microblog","SYS_Company","多个微博使用逗号分隔");
			/// <summary>
			/// 多个手机号码使用逗号分隔
			/// </summary>
			public readonly static Field Mobile = new Field("Mobile","SYS_Company","多个手机号码使用逗号分隔");
			/// <summary>
			/// 多个联系电话使用逗号分隔
			/// </summary>
			public readonly static Field Tel = new Field("Tel","SYS_Company","多个联系电话使用逗号分隔");
			/// <summary>
			/// 多个邮箱地址使用逗号分隔
			/// </summary>
			public readonly static Field Email = new Field("Email","SYS_Company","多个邮箱地址使用逗号分隔");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProvinceId = new Field("ProvinceId","SYS_Company","ProvinceId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CityId = new Field("CityId","SYS_Company","CityId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CountyId = new Field("CountyId","SYS_Company","CountyId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TownId = new Field("TownId","SYS_Company","TownId");
			/// <summary>
			/// 联系地址
			/// </summary>
			public readonly static Field Address = new Field("Address","SYS_Company","联系地址");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogoWidth = new Field("LogoWidth","SYS_Company","LogoWidth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogoHeight = new Field("LogoHeight","SYS_Company","LogoHeight");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LogoPath = new Field("LogoPath","SYS_Company","LogoPath");
			/// <summary>
			/// 经度
			/// </summary>
			public readonly static Field Lng = new Field("Lng","SYS_Company","经度");
			/// <summary>
			/// 纬度
			/// </summary>
			public readonly static Field Lat = new Field("Lat","SYS_Company","纬度");
			/// <summary>
			/// 详细信息
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","SYS_Company","详细信息");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_Company","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_Company","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_Company","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","SYS_Company","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","SYS_Company","修改人");
		}
		#endregion

	}
}

