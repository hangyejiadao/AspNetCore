/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_File
 * 创建时间：2017-02-16 16:02:06
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
	/// 实体类BUS_File 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_File")]
	public partial class BUS_File : Entity 
	{
		#region Model
		private Guid _FileInfoId;
		private Guid? _ProjectId;
		private Guid? _OrganId;
		private Guid? _ModuleDataId;
		private string _FileName;
		private string _FileSize;
		private string _Suffix;
		private string _FilePath;
		private string _CutPath;
		private DateTime? _CreateTime;
		/// <summary>
		/// 
		/// </summary>
		public Guid FileInfoId
		{
			get{ return _FileInfoId; }
			set
			{
				this.OnPropertyValueChange(_.FileInfoId,_FileInfoId,value);
				this._FileInfoId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ProjectId
		{
			get{ return _ProjectId; }
			set
			{
				this.OnPropertyValueChange(_.ProjectId,_ProjectId,value);
				this._ProjectId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? OrganId
		{
			get{ return _OrganId; }
			set
			{
				this.OnPropertyValueChange(_.OrganId,_OrganId,value);
				this._OrganId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ModuleDataId
		{
			get{ return _ModuleDataId; }
			set
			{
				this.OnPropertyValueChange(_.ModuleDataId,_ModuleDataId,value);
				this._ModuleDataId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			get{ return _FileName; }
			set
			{
				this.OnPropertyValueChange(_.FileName,_FileName,value);
				this._FileName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileSize
		{
			get{ return _FileSize; }
			set
			{
				this.OnPropertyValueChange(_.FileSize,_FileSize,value);
				this._FileSize=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Suffix
		{
			get{ return _Suffix; }
			set
			{
				this.OnPropertyValueChange(_.Suffix,_Suffix,value);
				this._Suffix=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilePath
		{
			get{ return _FilePath; }
			set
			{
				this.OnPropertyValueChange(_.FilePath,_FilePath,value);
				this._FilePath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CutPath
		{
			get{ return _CutPath; }
			set
			{
				this.OnPropertyValueChange(_.CutPath,_CutPath,value);
				this._CutPath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			get{ return _CreateTime; }
			set
			{
				this.OnPropertyValueChange(_.CreateTime,_CreateTime,value);
				this._CreateTime=value;
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
				_.FileInfoId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.FileInfoId,
				_.ProjectId,
				_.OrganId,
				_.ModuleDataId,
				_.FileName,
				_.FileSize,
				_.Suffix,
				_.FilePath,
				_.CutPath,
				_.CreateTime};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._FileInfoId,
				this._ProjectId,
				this._OrganId,
				this._ModuleDataId,
				this._FileName,
				this._FileSize,
				this._Suffix,
				this._FilePath,
				this._CutPath,
				this._CreateTime};
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
			public readonly static Field All = new Field("*","BUS_File");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field FileInfoId = new Field("FileInfoId","BUS_File","FileInfoId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectId = new Field("ProjectId","BUS_File","ProjectId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganId = new Field("OrganId","BUS_File","OrganId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleDataId = new Field("ModuleDataId","BUS_File","ModuleDataId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field FileName = new Field("FileName","BUS_File","FileName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field FileSize = new Field("FileSize","BUS_File","FileSize");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Suffix = new Field("Suffix","BUS_File","Suffix");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field FilePath = new Field("FilePath","BUS_File","FilePath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CutPath = new Field("CutPath","BUS_File","CutPath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CreateTime = new Field("CreateTime","BUS_File","CreateTime");
		}
		#endregion

	}
}

