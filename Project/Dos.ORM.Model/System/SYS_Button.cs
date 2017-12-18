/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_Button
 * 创建时间：2016-11-04 15:07:57
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
	/// 实体类SYS_Button 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_Button")]
	[Serializable]
	public partial class SYS_Button : Entity 
	{
		#region Model
		private Guid _ButtonId;
		private int? _FwType;
		private int? _ButtonType;
		private string _ButtonName;
		private string _ButtonIdName;
		private string _MarkName;
		private string _IconName;
		private string _IconPath;
		private string _OnClick;
		private string _HrefClick;
		private int? _SortNo;
		private string _Desc;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// _1001：添加  1002：修改  1003：查询  1004：查看  1005：删除  1006：保存
		/// </summary>
		public Guid ButtonId
		{
			get{ return _ButtonId; }
			set
			{
				this.OnPropertyValueChange(_.ButtonId,_ButtonId,value);
				this._ButtonId=value;
			}
		}
		/// <summary>
		/// _1：EasyUI框架  2：AngularJS框架  3：原生框架
		/// </summary>
		public int? FwType
		{
			get{ return _FwType; }
			set
			{
				this.OnPropertyValueChange(_.FwType,_FwType,value);
				this._FwType=value;
			}
		}
		/// <summary>
		/// _100：列表常用  200：编辑常用  300：其他常用
		/// </summary>
		public int? ButtonType
		{
			get{ return _ButtonType; }
			set
			{
				this.OnPropertyValueChange(_.ButtonType,_ButtonType,value);
				this._ButtonType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ButtonName
		{
			get{ return _ButtonName; }
			set
			{
				this.OnPropertyValueChange(_.ButtonName,_ButtonName,value);
				this._ButtonName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ButtonIdName
		{
			get{ return _ButtonIdName; }
			set
			{
				this.OnPropertyValueChange(_.ButtonIdName,_ButtonIdName,value);
				this._ButtonIdName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MarkName
		{
			get{ return _MarkName; }
			set
			{
				this.OnPropertyValueChange(_.MarkName,_MarkName,value);
				this._MarkName=value;
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
		/// 主要是针对EasyUI的linkbutton扩展控件事件，如：onClick = "saveData"
		/// </summary>
		public string OnClick
		{
			get{ return _OnClick; }
			set
			{
				this.OnPropertyValueChange(_.OnClick,_OnClick,value);
				this._OnClick=value;
			}
		}
		/// <summary>
		/// 主要是针对EasyUI的linkbutton扩展控件事件，如：href = "javascript:QBO.frm.closeWin();"
		/// </summary>
		public string HrefClick
		{
			get{ return _HrefClick; }
			set
			{
				this.OnPropertyValueChange(_.HrefClick,_HrefClick,value);
				this._HrefClick=value;
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
				_.ButtonId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.ButtonId,
				_.FwType,
				_.ButtonType,
				_.ButtonName,
				_.ButtonIdName,
				_.MarkName,
				_.IconName,
				_.IconPath,
				_.OnClick,
				_.HrefClick,
				_.SortNo,
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
				this._ButtonId,
				this._FwType,
				this._ButtonType,
				this._ButtonName,
				this._ButtonIdName,
				this._MarkName,
				this._IconName,
				this._IconPath,
				this._OnClick,
				this._HrefClick,
				this._SortNo,
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
			public readonly static Field All = new Field("*","SYS_Button");
			/// <summary>
			/// _1001：添加  1002：修改  1003：查询  1004：查看  1005：删除  1006：保存
			/// </summary>
			public readonly static Field ButtonId = new Field("ButtonId","SYS_Button","_1001：添加  1002：修改  1003：查询  1004：查看  1005：删除  1006：保存");
			/// <summary>
			/// _1：EasyUI框架  2：AngularJS框架  3：原生框架
			/// </summary>
			public readonly static Field FwType = new Field("FwType","SYS_Button","_1：EasyUI框架  2：AngularJS框架  3：原生框架");
			/// <summary>
			/// _100：列表常用  200：编辑常用  300：其他常用
			/// </summary>
			public readonly static Field ButtonType = new Field("ButtonType","SYS_Button","_100：列表常用  200：编辑常用  300：其他常用");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ButtonName = new Field("ButtonName","SYS_Button","ButtonName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ButtonIdName = new Field("ButtonIdName","SYS_Button","ButtonIdName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MarkName = new Field("MarkName","SYS_Button","MarkName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IconName = new Field("IconName","SYS_Button","IconName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IconPath = new Field("IconPath","SYS_Button","IconPath");
			/// <summary>
			/// 主要是针对EasyUI的linkbutton扩展控件事件，如：onClick = "saveData"
			/// </summary>
			public readonly static Field OnClick = new Field("OnClick","SYS_Button","主要是针对EasyUI的linkbutton扩展控件事件，如：onClick = \"saveData\"");
			/// <summary>
			/// 主要是针对EasyUI的linkbutton扩展控件事件，如：href = "javascript:QBO.frm.closeWin();"
			/// </summary>
			public readonly static Field HrefClick = new Field("HrefClick","SYS_Button","主要是针对EasyUI的linkbutton扩展控件事件，如：href = \"javascript:QBO.frm.closeWin();\"");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SortNo = new Field("SortNo","SYS_Button","SortNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","SYS_Button","Desc");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","SYS_Button","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_Button","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_Button","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","SYS_Button","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","SYS_Button","修改人");
		}
		#endregion

	}
}

