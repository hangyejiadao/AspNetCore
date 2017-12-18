/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：TW_SYJZB
 * 创建时间：2017-10-17 10:47:39
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
	/// 实体类TW_SYJZB 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("TW_SYJZB")]
	public partial class TW_SYJZB : Entity 
	{
		#region Model
		private string _SYJID;
		private string _SBBH;
		private string _SYLX;
		private string _WTBH;
		private string _SJBH;
		private string _ZZRQ;
		private string _SYRQ;
		private DateTime? _SYWCSJ;
		private string _SJSCSJ;
		private int? _LQ;
		private string _SJCC;
		private string _SJMJ;
		private string _CLPZ;
		private string _SJQD;
		private string _ZSXS;
		private string _QDDBZ;
		private string _PDJG;
		private string _QDBFB;
		private string _CZRY;
		private string _CJMC;
		private string _PZBM;
		private string _JTDJ;
		private string _JTLDZT;
		private string _WQJG;
		private string _GCZJ;
		private string _AREA;
		private string _SJSL;
		private string _JSYQ1;
		private string _JSYQ2;
		private string _JSYQ3;
		private string _JSYQ4;
		private string _JSYQ5;
		private string _JSYQ6;
		private DateTime? _UpdatedIdentification;
		private bool? _Is_Send;
		private string _YPID;
		private DateTime? _SYDate;
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
		public string SBBH
		{
			get{ return _SBBH; }
			set
			{
				this.OnPropertyValueChange(_.SBBH,_SBBH,value);
				this._SBBH=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYLX
		{
			get{ return _SYLX; }
			set
			{
				this.OnPropertyValueChange(_.SYLX,_SYLX,value);
				this._SYLX=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WTBH
		{
			get{ return _WTBH; }
			set
			{
				this.OnPropertyValueChange(_.WTBH,_WTBH,value);
				this._WTBH=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJBH
		{
			get{ return _SJBH; }
			set
			{
				this.OnPropertyValueChange(_.SJBH,_SJBH,value);
				this._SJBH=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZZRQ
		{
			get{ return _ZZRQ; }
			set
			{
				this.OnPropertyValueChange(_.ZZRQ,_ZZRQ,value);
				this._ZZRQ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYRQ
		{
			get{ return _SYRQ; }
			set
			{
				this.OnPropertyValueChange(_.SYRQ,_SYRQ,value);
				this._SYRQ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SYWCSJ
		{
			get{ return _SYWCSJ; }
			set
			{
				this.OnPropertyValueChange(_.SYWCSJ,_SYWCSJ,value);
				this._SYWCSJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJSCSJ
		{
			get{ return _SJSCSJ; }
			set
			{
				this.OnPropertyValueChange(_.SJSCSJ,_SJSCSJ,value);
				this._SJSCSJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LQ
		{
			get{ return _LQ; }
			set
			{
				this.OnPropertyValueChange(_.LQ,_LQ,value);
				this._LQ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJCC
		{
			get{ return _SJCC; }
			set
			{
				this.OnPropertyValueChange(_.SJCC,_SJCC,value);
				this._SJCC=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJMJ
		{
			get{ return _SJMJ; }
			set
			{
				this.OnPropertyValueChange(_.SJMJ,_SJMJ,value);
				this._SJMJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CLPZ
		{
			get{ return _CLPZ; }
			set
			{
				this.OnPropertyValueChange(_.CLPZ,_CLPZ,value);
				this._CLPZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJQD
		{
			get{ return _SJQD; }
			set
			{
				this.OnPropertyValueChange(_.SJQD,_SJQD,value);
				this._SJQD=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZSXS
		{
			get{ return _ZSXS; }
			set
			{
				this.OnPropertyValueChange(_.ZSXS,_ZSXS,value);
				this._ZSXS=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QDDBZ
		{
			get{ return _QDDBZ; }
			set
			{
				this.OnPropertyValueChange(_.QDDBZ,_QDDBZ,value);
				this._QDDBZ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PDJG
		{
			get{ return _PDJG; }
			set
			{
				this.OnPropertyValueChange(_.PDJG,_PDJG,value);
				this._PDJG=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QDBFB
		{
			get{ return _QDBFB; }
			set
			{
				this.OnPropertyValueChange(_.QDBFB,_QDBFB,value);
				this._QDBFB=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZRY
		{
			get{ return _CZRY; }
			set
			{
				this.OnPropertyValueChange(_.CZRY,_CZRY,value);
				this._CZRY=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CJMC
		{
			get{ return _CJMC; }
			set
			{
				this.OnPropertyValueChange(_.CJMC,_CJMC,value);
				this._CJMC=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PZBM
		{
			get{ return _PZBM; }
			set
			{
				this.OnPropertyValueChange(_.PZBM,_PZBM,value);
				this._PZBM=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JTDJ
		{
			get{ return _JTDJ; }
			set
			{
				this.OnPropertyValueChange(_.JTDJ,_JTDJ,value);
				this._JTDJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JTLDZT
		{
			get{ return _JTLDZT; }
			set
			{
				this.OnPropertyValueChange(_.JTLDZT,_JTLDZT,value);
				this._JTLDZT=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WQJG
		{
			get{ return _WQJG; }
			set
			{
				this.OnPropertyValueChange(_.WQJG,_WQJG,value);
				this._WQJG=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GCZJ
		{
			get{ return _GCZJ; }
			set
			{
				this.OnPropertyValueChange(_.GCZJ,_GCZJ,value);
				this._GCZJ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AREA
		{
			get{ return _AREA; }
			set
			{
				this.OnPropertyValueChange(_.AREA,_AREA,value);
				this._AREA=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJSL
		{
			get{ return _SJSL; }
			set
			{
				this.OnPropertyValueChange(_.SJSL,_SJSL,value);
				this._SJSL=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ1
		{
			get{ return _JSYQ1; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ1,_JSYQ1,value);
				this._JSYQ1=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ2
		{
			get{ return _JSYQ2; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ2,_JSYQ2,value);
				this._JSYQ2=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ3
		{
			get{ return _JSYQ3; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ3,_JSYQ3,value);
				this._JSYQ3=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ4
		{
			get{ return _JSYQ4; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ4,_JSYQ4,value);
				this._JSYQ4=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ5
		{
			get{ return _JSYQ5; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ5,_JSYQ5,value);
				this._JSYQ5=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSYQ6
		{
			get{ return _JSYQ6; }
			set
			{
				this.OnPropertyValueChange(_.JSYQ6,_JSYQ6,value);
				this._JSYQ6=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdatedIdentification
		{
			get{ return _UpdatedIdentification; }
			set
			{
				this.OnPropertyValueChange(_.UpdatedIdentification,_UpdatedIdentification,value);
				this._UpdatedIdentification=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Is_Send
		{
			get{ return _Is_Send; }
			set
			{
				this.OnPropertyValueChange(_.Is_Send,_Is_Send,value);
				this._Is_Send=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YPID
		{
			get{ return _YPID; }
			set
			{
				this.OnPropertyValueChange(_.YPID,_YPID,value);
				this._YPID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SYDate
		{
			get{ return _SYDate; }
			set
			{
				this.OnPropertyValueChange(_.SYDate,_SYDate,value);
				this._SYDate=value;
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
				_.SYJID,
				_.SBBH,
				_.SYLX,
				_.WTBH,
				_.SJBH,
				_.ZZRQ,
				_.SYRQ,
				_.SYWCSJ,
				_.SJSCSJ,
				_.LQ,
				_.SJCC,
				_.SJMJ,
				_.CLPZ,
				_.SJQD,
				_.ZSXS,
				_.QDDBZ,
				_.PDJG,
				_.QDBFB,
				_.CZRY,
				_.CJMC,
				_.PZBM,
				_.JTDJ,
				_.JTLDZT,
				_.WQJG,
				_.GCZJ,
				_.AREA,
				_.SJSL,
				_.JSYQ1,
				_.JSYQ2,
				_.JSYQ3,
				_.JSYQ4,
				_.JSYQ5,
				_.JSYQ6,
				_.UpdatedIdentification,
				_.Is_Send,
				_.YPID,
				_.SYDate};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._SYJID,
				this._SBBH,
				this._SYLX,
				this._WTBH,
				this._SJBH,
				this._ZZRQ,
				this._SYRQ,
				this._SYWCSJ,
				this._SJSCSJ,
				this._LQ,
				this._SJCC,
				this._SJMJ,
				this._CLPZ,
				this._SJQD,
				this._ZSXS,
				this._QDDBZ,
				this._PDJG,
				this._QDBFB,
				this._CZRY,
				this._CJMC,
				this._PZBM,
				this._JTDJ,
				this._JTLDZT,
				this._WQJG,
				this._GCZJ,
				this._AREA,
				this._SJSL,
				this._JSYQ1,
				this._JSYQ2,
				this._JSYQ3,
				this._JSYQ4,
				this._JSYQ5,
				this._JSYQ6,
				this._UpdatedIdentification,
				this._Is_Send,
				this._YPID,
				this._SYDate};
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
			public readonly static Field All = new Field("*","TW_SYJZB");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYJID = new Field("SYJID","TW_SYJZB","SYJID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SBBH = new Field("SBBH","TW_SYJZB","SBBH");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYLX = new Field("SYLX","TW_SYJZB","SYLX");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WTBH = new Field("WTBH","TW_SYJZB","WTBH");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJBH = new Field("SJBH","TW_SYJZB","SJBH");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ZZRQ = new Field("ZZRQ","TW_SYJZB","ZZRQ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYRQ = new Field("SYRQ","TW_SYJZB","SYRQ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYWCSJ = new Field("SYWCSJ","TW_SYJZB","SYWCSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJSCSJ = new Field("SJSCSJ","TW_SYJZB","SJSCSJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LQ = new Field("LQ","TW_SYJZB","LQ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJCC = new Field("SJCC","TW_SYJZB","SJCC");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJMJ = new Field("SJMJ","TW_SYJZB","SJMJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CLPZ = new Field("CLPZ","TW_SYJZB","CLPZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJQD = new Field("SJQD","TW_SYJZB","SJQD");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ZSXS = new Field("ZSXS","TW_SYJZB","ZSXS");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QDDBZ = new Field("QDDBZ","TW_SYJZB","QDDBZ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PDJG = new Field("PDJG","TW_SYJZB","PDJG");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QDBFB = new Field("QDBFB","TW_SYJZB","QDBFB");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CZRY = new Field("CZRY","TW_SYJZB","CZRY");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CJMC = new Field("CJMC","TW_SYJZB","CJMC");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PZBM = new Field("PZBM","TW_SYJZB","PZBM");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JTDJ = new Field("JTDJ","TW_SYJZB","JTDJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JTLDZT = new Field("JTLDZT","TW_SYJZB","JTLDZT");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WQJG = new Field("WQJG","TW_SYJZB","WQJG");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field GCZJ = new Field("GCZJ","TW_SYJZB","GCZJ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AREA = new Field("AREA","TW_SYJZB","AREA");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SJSL = new Field("SJSL","TW_SYJZB","SJSL");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ1 = new Field("JSYQ1","TW_SYJZB","JSYQ1");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ2 = new Field("JSYQ2","TW_SYJZB","JSYQ2");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ3 = new Field("JSYQ3","TW_SYJZB","JSYQ3");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ4 = new Field("JSYQ4","TW_SYJZB","JSYQ4");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ5 = new Field("JSYQ5","TW_SYJZB","JSYQ5");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field JSYQ6 = new Field("JSYQ6","TW_SYJZB","JSYQ6");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UpdatedIdentification = new Field("UpdatedIdentification","TW_SYJZB","UpdatedIdentification");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Is_Send = new Field("Is_Send","TW_SYJZB","Is_Send");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field YPID = new Field("YPID","TW_SYJZB","YPID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SYDate = new Field("SYDate","TW_SYJZB","SYDate");
		}
		#endregion

	}
}

