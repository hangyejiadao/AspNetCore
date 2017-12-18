/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_Role
 * 创建时间：2016-09-01 15:35:32
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
	/// 实体类SYS_Role 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_Role")]
	[Serializable]
	public partial class SYS_Role : Entity 
	{
		#region Model
		private Guid _RoleId;
		private Guid? _CompanyId;
		private string _RoleName;
		private int _IsEnable=1;
		private string _Desc;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid RoleId
		{
			get{ return _RoleId; }
			set
			{
				this.OnPropertyValueChange(_.RoleId,_RoleId,value);
				this._RoleId=value;
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
		public string RoleName
		{
			get{ return _RoleName; }
			set
			{
				this.OnPropertyValueChange(_.RoleName,_RoleName,value);
				this._RoleName=value;
			}
		}
		/// <summary>
		/// _1：启用（默认）     0：禁用
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
				_.RoleId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.RoleId,
				_.CompanyId,
				_.RoleName,
				_.IsEnable,
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
				this._RoleId,
				this._CompanyId,
				this._RoleName,
				this._IsEnable,
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
			public readonly static Field All = new Field("*","SYS_Role");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleId = new Field("RoleId","SYS_Role","RoleId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","SYS_Role","CompanyId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleName = new Field("RoleName","SYS_Role","RoleName");
			/// <summary>
			/// _1：启用（默认）     0：禁用
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","SYS_Role","_1：启用（默认）     0：禁用");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","SYS_Role","Desc");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_Role","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_Role","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_Role","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","SYS_Role","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","SYS_Role","修改人");
		}
		#endregion

	}
}

