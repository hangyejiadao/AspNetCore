/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_NewsInfo
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
	/// 实体类BUS_NewsInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_NewsInfo")]
	[Serializable]
	public partial class BUS_NewsInfo : Entity 
	{
		#region Model
		private Guid _NewsInfoId;
		private Guid? _NewsTypeId;
		private Guid? _CompanyId;
		private string _Title;
		private string _TitleColor;
		private int? _TitleFont;
		private string _Subtitle;
		private string _Source;
		private string _SourceLink;
		private string _Author;
		private string _Keyword;
		private string _Summary;
		private int? _ImgWidth;
		private int? _ImgHeight;
		private string _ImgPath;
		private int? _ViewCount;
		private int? _IsTop=0;
		private int _IsEnable=1;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid NewsInfoId
		{
			get{ return _NewsInfoId; }
			set
			{
				this.OnPropertyValueChange(_.NewsInfoId,_NewsInfoId,value);
				this._NewsInfoId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? NewsTypeId
		{
			get{ return _NewsTypeId; }
			set
			{
				this.OnPropertyValueChange(_.NewsTypeId,_NewsTypeId,value);
				this._NewsTypeId=value;
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
		/// 
		/// </summary>
		public string Title
		{
			get{ return _Title; }
			set
			{
				this.OnPropertyValueChange(_.Title,_Title,value);
				this._Title=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TitleColor
		{
			get{ return _TitleColor; }
			set
			{
				this.OnPropertyValueChange(_.TitleColor,_TitleColor,value);
				this._TitleColor=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TitleFont
		{
			get{ return _TitleFont; }
			set
			{
				this.OnPropertyValueChange(_.TitleFont,_TitleFont,value);
				this._TitleFont=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subtitle
		{
			get{ return _Subtitle; }
			set
			{
				this.OnPropertyValueChange(_.Subtitle,_Subtitle,value);
				this._Subtitle=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			get{ return _Source; }
			set
			{
				this.OnPropertyValueChange(_.Source,_Source,value);
				this._Source=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SourceLink
		{
			get{ return _SourceLink; }
			set
			{
				this.OnPropertyValueChange(_.SourceLink,_SourceLink,value);
				this._SourceLink=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			get{ return _Author; }
			set
			{
				this.OnPropertyValueChange(_.Author,_Author,value);
				this._Author=value;
			}
		}
		/// <summary>
		/// 多个关键字使用逗号分隔
		/// </summary>
		public string Keyword
		{
			get{ return _Keyword; }
			set
			{
				this.OnPropertyValueChange(_.Keyword,_Keyword,value);
				this._Keyword=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			get{ return _Summary; }
			set
			{
				this.OnPropertyValueChange(_.Summary,_Summary,value);
				this._Summary=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ImgWidth
		{
			get{ return _ImgWidth; }
			set
			{
				this.OnPropertyValueChange(_.ImgWidth,_ImgWidth,value);
				this._ImgWidth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ImgHeight
		{
			get{ return _ImgHeight; }
			set
			{
				this.OnPropertyValueChange(_.ImgHeight,_ImgHeight,value);
				this._ImgHeight=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgPath
		{
			get{ return _ImgPath; }
			set
			{
				this.OnPropertyValueChange(_.ImgPath,_ImgPath,value);
				this._ImgPath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ViewCount
		{
			get{ return _ViewCount; }
			set
			{
				this.OnPropertyValueChange(_.ViewCount,_ViewCount,value);
				this._ViewCount=value;
			}
		}
		/// <summary>
		/// _1：是     0：否（默认）
		/// </summary>
		public int? IsTop
		{
			get{ return _IsTop; }
			set
			{
				this.OnPropertyValueChange(_.IsTop,_IsTop,value);
				this._IsTop=value;
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
				_.NewsInfoId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.NewsInfoId,
				_.NewsTypeId,
				_.CompanyId,
				_.Title,
				_.TitleColor,
				_.TitleFont,
				_.Subtitle,
				_.Source,
				_.SourceLink,
				_.Author,
				_.Keyword,
				_.Summary,
				_.ImgWidth,
				_.ImgHeight,
				_.ImgPath,
				_.ViewCount,
				_.IsTop,
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
				this._NewsInfoId,
				this._NewsTypeId,
				this._CompanyId,
				this._Title,
				this._TitleColor,
				this._TitleFont,
				this._Subtitle,
				this._Source,
				this._SourceLink,
				this._Author,
				this._Keyword,
				this._Summary,
				this._ImgWidth,
				this._ImgHeight,
				this._ImgPath,
				this._ViewCount,
				this._IsTop,
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
			public readonly static Field All = new Field("*","BUS_NewsInfo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NewsInfoId = new Field("NewsInfoId","BUS_NewsInfo","NewsInfoId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NewsTypeId = new Field("NewsTypeId","BUS_NewsInfo","NewsTypeId");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","BUS_NewsInfo","公司Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Title = new Field("Title","BUS_NewsInfo","Title");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TitleColor = new Field("TitleColor","BUS_NewsInfo","TitleColor");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TitleFont = new Field("TitleFont","BUS_NewsInfo","TitleFont");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Subtitle = new Field("Subtitle","BUS_NewsInfo","Subtitle");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Source = new Field("Source","BUS_NewsInfo","Source");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SourceLink = new Field("SourceLink","BUS_NewsInfo","SourceLink");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Author = new Field("Author","BUS_NewsInfo","Author");
			/// <summary>
			/// 多个关键字使用逗号分隔
			/// </summary>
			public readonly static Field Keyword = new Field("Keyword","BUS_NewsInfo","多个关键字使用逗号分隔");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Summary = new Field("Summary","BUS_NewsInfo","Summary");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgWidth = new Field("ImgWidth","BUS_NewsInfo","ImgWidth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgHeight = new Field("ImgHeight","BUS_NewsInfo","ImgHeight");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgPath = new Field("ImgPath","BUS_NewsInfo","ImgPath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ViewCount = new Field("ViewCount","BUS_NewsInfo","ViewCount");
			/// <summary>
			/// _1：是     0：否（默认）
			/// </summary>
			public readonly static Field IsTop = new Field("IsTop","BUS_NewsInfo","_1：是     0：否（默认）");
			/// <summary>
			/// _1：是（默认）     0：否
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","BUS_NewsInfo","_1：是（默认）     0：否");
			/// <summary>
			/// 详细信息
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","BUS_NewsInfo","详细信息");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","BUS_NewsInfo","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","BUS_NewsInfo","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","BUS_NewsInfo","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","BUS_NewsInfo","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","BUS_NewsInfo","修改人");
		}
		#endregion

	}
}

