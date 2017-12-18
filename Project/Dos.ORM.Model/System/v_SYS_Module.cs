/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：v_SYS_Module
 * 创建时间：2016-11-15 19:36:20
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
	/// 实体类v_SYS_Module 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("v_SYS_Module")]
	[Serializable]
	public partial class v_SYS_Module : Entity 
	{
		#region Model
		private Guid _ModuleId;
		private Guid? _ParentId;
		private int _ModuleType;
		private string _ModuleName;
		private string _IconName;
		private string _IconPath;
		private string _ModulePath;
		private int? _IsOperatePage;
		private int? _OperatePageType;
		private int _IsExpand;
		private int _IsEnable;
		private int? _SortNo;
		private string _Desc;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		private Guid? _RoleId;
		/// <summary>
		/// 
		/// </summary>
		public Guid ModuleId
		{
			get{ return _ModuleId; }
			set
			{
				this.OnPropertyValueChange(_.ModuleId,_ModuleId,value);
				this._ModuleId=value;
			}
		}
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public int ModuleType
		{
			get{ return _ModuleType; }
			set
			{
				this.OnPropertyValueChange(_.ModuleType,_ModuleType,value);
				this._ModuleType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModuleName
		{
			get{ return _ModuleName; }
			set
			{
				this.OnPropertyValueChange(_.ModuleName,_ModuleName,value);
				this._ModuleName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IconName
		{
			get{ return _IconName; }
			set
			{
				this.OnPropertyValueChange(_.IconName,_IconName,value);
				this._IconName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IconPath
		{
			get{ return _IconPath; }
			set
			{
				this.OnPropertyValueChange(_.IconPath,_IconPath,value);
				this._IconPath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModulePath
		{
			get{ return _ModulePath; }
			set
			{
				this.OnPropertyValueChange(_.ModulePath,_ModulePath,value);
				this._ModulePath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsOperatePage
		{
			get{ return _IsOperatePage; }
			set
			{
				this.OnPropertyValueChange(_.IsOperatePage,_IsOperatePage,value);
				this._IsOperatePage=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperatePageType
		{
			get{ return _OperatePageType; }
			set
			{
				this.OnPropertyValueChange(_.OperatePageType,_OperatePageType,value);
				this._OperatePageType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsExpand
		{
			get{ return _IsExpand; }
			set
			{
				this.OnPropertyValueChange(_.IsExpand,_IsExpand,value);
				this._IsExpand=value;
			}
		}
		/// <summary>
		/// 
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
		public int? SortNo
		{
			get{ return _SortNo; }
			set
			{
				this.OnPropertyValueChange(_.SortNo,_SortNo,value);
				this._SortNo=value;
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
		/// 
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
		/// 
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
		/// 
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
		/// 
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
		/// 
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
		/// <summary>
		/// 
		/// </summary>
		public Guid? RoleId
		{
			get{ return _RoleId; }
			set
			{
				this.OnPropertyValueChange(_.RoleId,_RoleId,value);
				this._RoleId=value;
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
				_.ModuleId,
				_.ParentId,
				_.ModuleType,
				_.ModuleName,
				_.IconName,
				_.IconPath,
				_.ModulePath,
				_.IsOperatePage,
				_.OperatePageType,
				_.IsExpand,
				_.IsEnable,
				_.SortNo,
				_.Desc,
				_.Status,
				_.CrtTime,
				_.CrtOptId,
				_.ModTime,
				_.ModOptId,
				_.RoleId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ModuleId,
				this._ParentId,
				this._ModuleType,
				this._ModuleName,
				this._IconName,
				this._IconPath,
				this._ModulePath,
				this._IsOperatePage,
				this._OperatePageType,
				this._IsExpand,
				this._IsEnable,
				this._SortNo,
				this._Desc,
				this._Status,
				this._CrtTime,
				this._CrtOptId,
				this._ModTime,
				this._ModOptId,
				this._RoleId};
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
			public readonly static Field All = new Field("*","v_SYS_Module");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleId = new Field("ModuleId","v_SYS_Module","ModuleId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParentId = new Field("ParentId","v_SYS_Module","ParentId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleType = new Field("ModuleType","v_SYS_Module","ModuleType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleName = new Field("ModuleName","v_SYS_Module","ModuleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IconName = new Field("IconName","v_SYS_Module","IconName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IconPath = new Field("IconPath","v_SYS_Module","IconPath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModulePath = new Field("ModulePath","v_SYS_Module","ModulePath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsOperatePage = new Field("IsOperatePage","v_SYS_Module","IsOperatePage");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OperatePageType = new Field("OperatePageType","v_SYS_Module","OperatePageType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsExpand = new Field("IsExpand","v_SYS_Module","IsExpand");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","v_SYS_Module","IsEnable");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SortNo = new Field("SortNo","v_SYS_Module","SortNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","v_SYS_Module","Desc");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Status = new Field("Status","v_SYS_Module","Status");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","v_SYS_Module","CrtTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","v_SYS_Module","CrtOptId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","v_SYS_Module","ModTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","v_SYS_Module","ModOptId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleId = new Field("RoleId","v_SYS_Module","RoleId");
		}
		#endregion

	}
}

