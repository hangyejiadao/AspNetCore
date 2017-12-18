/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：TW_YLJ
 * 创建时间：2017-10-13 17:07:21
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
	/// 实体类TW_YLJ 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("TW_YLJ")]
	public partial class TW_YLJ : Entity 
	{
		#region Model
		private string _F_GUID;
		private string _SJXH;
		private string _SYJID;
		private string _ZZJJ;
		private string _KYLZ;
		private string _KYQD;
		private string _SYSJ;
		private string _WCSJ;
		private string _YSKYLZ;
		private string _SJGC;
		private int? _STATUS;
		private int? _id;
		private int? _version;
		/// <summary>
		/// 
		/// </summary>
		public string F_GUID
		{
			get{ return _F_GUID; }
			set
			{
				this.OnPropertyValueChange(_.F_GUID,_F_GUID,value);
				this._F_GUID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJXH
		{
			get{ return _SJXH; }
			set
			{
				this.OnPropertyValueChange(_.SJXH,_SJXH,value);
				this._SJXH=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYJID
		{
			get{ return _SYJID; }
			set
			{
				this.OnPropertyValueChange(_.SYJID,_SYJID,value);
				this._SYJID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZZJJ
		{
			get{ return _ZZJJ; }
			set
			{
				this.OnPropertyValueChange(_.ZZJJ,_ZZJJ,value);
				this._ZZJJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KYLZ
		{
			get{ return _KYLZ; }
			set
			{
				this.OnPropertyValueChange(_.KYLZ,_KYLZ,value);
				this._KYLZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KYQD
		{
			get{ return _KYQD; }
			set
			{
				this.OnPropertyValueChange(_.KYQD,_KYQD,value);
				this._KYQD=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYSJ
		{
			get{ return _SYSJ; }
			set
			{
				this.OnPropertyValueChange(_.SYSJ,_SYSJ,value);
				this._SYSJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WCSJ
		{
			get{ return _WCSJ; }
			set
			{
				this.OnPropertyValueChange(_.WCSJ,_WCSJ,value);
				this._WCSJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YSKYLZ
		{
			get{ return _YSKYLZ; }
			set
			{
				this.OnPropertyValueChange(_.YSKYLZ,_YSKYLZ,value);
				this._YSKYLZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJGC
		{
			get{ return _SJGC; }
			set
			{
				this.OnPropertyValueChange(_.SJGC,_SJGC,value);
				this._SJGC=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? STATUS
		{
			get{ return _STATUS; }
			set
			{
				this.OnPropertyValueChange(_.STATUS,_STATUS,value);
				this._STATUS=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			get{ return _id; }
			set
			{
				this.OnPropertyValueChange(_.id,_id,value);
				this._id=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? version
		{
			get{ return _version; }
			set
			{
				this.OnPropertyValueChange(_.version,_version,value);
				this._version=value;
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
				_.F_GUID,
				_.SJXH,
				_.SYJID,
				_.ZZJJ,
				_.KYLZ,
				_.KYQD,
				_.SYSJ,
				_.WCSJ,
				_.YSKYLZ,
				_.SJGC,
				_.STATUS,
				_.id,
				_.version};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._F_GUID,
				this._SJXH,
				this._SYJID,
				this._ZZJJ,
				this._KYLZ,
				this._KYQD,
				this._SYSJ,
				this._WCSJ,
				this._YSKYLZ,
				this._SJGC,
				this._STATUS,
				this._id,
				this._version};
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
			public readonly static Field All = new Field("*","TW_YLJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field F_GUID = new Field("F_GUID","TW_YLJ","F_GUID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJXH = new Field("SJXH","TW_YLJ","SJXH");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYJID = new Field("SYJID","TW_YLJ","SYJID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ZZJJ = new Field("ZZJJ","TW_YLJ","ZZJJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field KYLZ = new Field("KYLZ","TW_YLJ","KYLZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field KYQD = new Field("KYQD","TW_YLJ","KYQD");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYSJ = new Field("SYSJ","TW_YLJ","SYSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WCSJ = new Field("WCSJ","TW_YLJ","WCSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field YSKYLZ = new Field("YSKYLZ","TW_YLJ","YSKYLZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJGC = new Field("SJGC","TW_YLJ","SJGC");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field STATUS = new Field("STATUS","TW_YLJ","STATUS");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field id = new Field("id","TW_YLJ","id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field version = new Field("version","TW_YLJ","version");
		}
		#endregion

	}
}

