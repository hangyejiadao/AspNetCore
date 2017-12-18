/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：TW_WNJ
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
	/// 实体类TW_WNJ 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("TW_WNJ")]
	public partial class TW_WNJ : Entity 
	{
		#region Model
		private string _F_GUID;
		private string _SJXH;
		private string _SYJID;
		private string _WSBZ;
		private string _DHBZ;
		private string _DHBZ2;
		private string _LZ;
		private string _LZQD;
		private string _WY;
		private string _LZGC;
		private string _SJGC;
		private string _QFLZ;
		private string _QFQD;
		private string _SCL;
		private string _SYSJ;
		private string _WCSJ;
		private int? _STATUS;
		private string _ZDLZSCL;
		private string _LDCMS;
		private string _DKWZ;
		private int? _id;
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
		public string WSBZ
		{
			get{ return _WSBZ; }
			set
			{
				this.OnPropertyValueChange(_.WSBZ,_WSBZ,value);
				this._WSBZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DHBZ
		{
			get{ return _DHBZ; }
			set
			{
				this.OnPropertyValueChange(_.DHBZ,_DHBZ,value);
				this._DHBZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DHBZ2
		{
			get{ return _DHBZ2; }
			set
			{
				this.OnPropertyValueChange(_.DHBZ2,_DHBZ2,value);
				this._DHBZ2=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LZ
		{
			get{ return _LZ; }
			set
			{
				this.OnPropertyValueChange(_.LZ,_LZ,value);
				this._LZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LZQD
		{
			get{ return _LZQD; }
			set
			{
				this.OnPropertyValueChange(_.LZQD,_LZQD,value);
				this._LZQD=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WY
		{
			get{ return _WY; }
			set
			{
				this.OnPropertyValueChange(_.WY,_WY,value);
				this._WY=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LZGC
		{
			get{ return _LZGC; }
			set
			{
				this.OnPropertyValueChange(_.LZGC,_LZGC,value);
				this._LZGC=value;
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
		public string QFLZ
		{
			get{ return _QFLZ; }
			set
			{
				this.OnPropertyValueChange(_.QFLZ,_QFLZ,value);
				this._QFLZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QFQD
		{
			get{ return _QFQD; }
			set
			{
				this.OnPropertyValueChange(_.QFQD,_QFQD,value);
				this._QFQD=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCL
		{
			get{ return _SCL; }
			set
			{
				this.OnPropertyValueChange(_.SCL,_SCL,value);
				this._SCL=value;
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
		public string ZDLZSCL
		{
			get{ return _ZDLZSCL; }
			set
			{
				this.OnPropertyValueChange(_.ZDLZSCL,_ZDLZSCL,value);
				this._ZDLZSCL=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LDCMS
		{
			get{ return _LDCMS; }
			set
			{
				this.OnPropertyValueChange(_.LDCMS,_LDCMS,value);
				this._LDCMS=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DKWZ
		{
			get{ return _DKWZ; }
			set
			{
				this.OnPropertyValueChange(_.DKWZ,_DKWZ,value);
				this._DKWZ=value;
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
				_.WSBZ,
				_.DHBZ,
				_.DHBZ2,
				_.LZ,
				_.LZQD,
				_.WY,
				_.LZGC,
				_.SJGC,
				_.QFLZ,
				_.QFQD,
				_.SCL,
				_.SYSJ,
				_.WCSJ,
				_.STATUS,
				_.ZDLZSCL,
				_.LDCMS,
				_.DKWZ,
				_.id};
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
				this._WSBZ,
				this._DHBZ,
				this._DHBZ2,
				this._LZ,
				this._LZQD,
				this._WY,
				this._LZGC,
				this._SJGC,
				this._QFLZ,
				this._QFQD,
				this._SCL,
				this._SYSJ,
				this._WCSJ,
				this._STATUS,
				this._ZDLZSCL,
				this._LDCMS,
				this._DKWZ,
				this._id};
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
			public readonly static Field All = new Field("*","TW_WNJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field F_GUID = new Field("F_GUID","TW_WNJ","F_GUID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJXH = new Field("SJXH","TW_WNJ","SJXH");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYJID = new Field("SYJID","TW_WNJ","SYJID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WSBZ = new Field("WSBZ","TW_WNJ","WSBZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DHBZ = new Field("DHBZ","TW_WNJ","DHBZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DHBZ2 = new Field("DHBZ2","TW_WNJ","DHBZ2");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LZ = new Field("LZ","TW_WNJ","LZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LZQD = new Field("LZQD","TW_WNJ","LZQD");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WY = new Field("WY","TW_WNJ","WY");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LZGC = new Field("LZGC","TW_WNJ","LZGC");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJGC = new Field("SJGC","TW_WNJ","SJGC");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QFLZ = new Field("QFLZ","TW_WNJ","QFLZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QFQD = new Field("QFQD","TW_WNJ","QFQD");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SCL = new Field("SCL","TW_WNJ","SCL");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYSJ = new Field("SYSJ","TW_WNJ","SYSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WCSJ = new Field("WCSJ","TW_WNJ","WCSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field STATUS = new Field("STATUS","TW_WNJ","STATUS");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ZDLZSCL = new Field("ZDLZSCL","TW_WNJ","ZDLZSCL");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LDCMS = new Field("LDCMS","TW_WNJ","LDCMS");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DKWZ = new Field("DKWZ","TW_WNJ","DKWZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field id = new Field("id","TW_WNJ","id");
		}
		#endregion

	}
}

