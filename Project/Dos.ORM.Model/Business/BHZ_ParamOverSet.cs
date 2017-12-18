/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_ParamOverSet
 * 创建时间：2017-08-23 17:31:23
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
    /// 实体类BHZ_ParamOverSet 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_ParamOverSet")]
    public partial class BHZ_ParamOverSet : Entity
    {
        #region Model
        private Guid _ID;
        private Guid _OrganID;
        private decimal? _One_S;
        private decimal? _One_SN;
        private decimal? _One_GL;
        private decimal? _One_FMH;
        private decimal? _One_KF;
        private decimal? _One_WJJ;
        private decimal? _One_FL;
        private decimal? _Two_S;
        private decimal? _Two_SN;
        private decimal? _Two_GL;
        private decimal? _Two_FMH;
        private decimal? _Two_KF;
        private decimal? _Two_WJJ;
        private decimal? _Two_FL;
        private decimal? _Three_S;
        private decimal? _Three_SN;
        private decimal? _Three_GL;
        private decimal? _Three_FMH;
        private decimal? _Three_KF;
        private decimal? _Three_WJJ;
        private decimal? _Three_FL;
        private decimal? _Four_S;
        private decimal? _Four_SN;
        private decimal? _Four_GL;
        private decimal? _Four_FMH;
        private decimal? _Four_KF;
        private decimal? _Four_WJJ;
        private decimal? _Four_FL;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid OrganID
        {
            get { return _OrganID; }
            set
            {
                this.OnPropertyValueChange(_.OrganID, _OrganID, value);
                this._OrganID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_S
        {
            get { return _One_S; }
            set
            {
                this.OnPropertyValueChange(_.One_S, _One_S, value);
                this._One_S = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_SN
        {
            get { return _One_SN; }
            set
            {
                this.OnPropertyValueChange(_.One_SN, _One_SN, value);
                this._One_SN = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_GL
        {
            get { return _One_GL; }
            set
            {
                this.OnPropertyValueChange(_.One_GL, _One_GL, value);
                this._One_GL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_FMH
        {
            get { return _One_FMH; }
            set
            {
                this.OnPropertyValueChange(_.One_FMH, _One_FMH, value);
                this._One_FMH = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_KF
        {
            get { return _One_KF; }
            set
            {
                this.OnPropertyValueChange(_.One_KF, _One_KF, value);
                this._One_KF = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_WJJ
        {
            get { return _One_WJJ; }
            set
            {
                this.OnPropertyValueChange(_.One_WJJ, _One_WJJ, value);
                this._One_WJJ = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? One_FL
        {
            get { return _One_FL; }
            set
            {
                this.OnPropertyValueChange(_.One_FL, _One_FL, value);
                this._One_FL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_S
        {
            get { return _Two_S; }
            set
            {
                this.OnPropertyValueChange(_.Two_S, _Two_S, value);
                this._Two_S = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_SN
        {
            get { return _Two_SN; }
            set
            {
                this.OnPropertyValueChange(_.Two_SN, _Two_SN, value);
                this._Two_SN = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_GL
        {
            get { return _Two_GL; }
            set
            {
                this.OnPropertyValueChange(_.Two_GL, _Two_GL, value);
                this._Two_GL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_FMH
        {
            get { return _Two_FMH; }
            set
            {
                this.OnPropertyValueChange(_.Two_FMH, _Two_FMH, value);
                this._Two_FMH = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_KF
        {
            get { return _Two_KF; }
            set
            {
                this.OnPropertyValueChange(_.Two_KF, _Two_KF, value);
                this._Two_KF = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_WJJ
        {
            get { return _Two_WJJ; }
            set
            {
                this.OnPropertyValueChange(_.Two_WJJ, _Two_WJJ, value);
                this._Two_WJJ = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Two_FL
        {
            get { return _Two_FL; }
            set
            {
                this.OnPropertyValueChange(_.Two_FL, _Two_FL, value);
                this._Two_FL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_S
        {
            get { return _Three_S; }
            set
            {
                this.OnPropertyValueChange(_.Three_S, _Three_S, value);
                this._Three_S = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_SN
        {
            get { return _Three_SN; }
            set
            {
                this.OnPropertyValueChange(_.Three_SN, _Three_SN, value);
                this._Three_SN = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_GL
        {
            get { return _Three_GL; }
            set
            {
                this.OnPropertyValueChange(_.Three_GL, _Three_GL, value);
                this._Three_GL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_FMH
        {
            get { return _Three_FMH; }
            set
            {
                this.OnPropertyValueChange(_.Three_FMH, _Three_FMH, value);
                this._Three_FMH = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_KF
        {
            get { return _Three_KF; }
            set
            {
                this.OnPropertyValueChange(_.Three_KF, _Three_KF, value);
                this._Three_KF = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_WJJ
        {
            get { return _Three_WJJ; }
            set
            {
                this.OnPropertyValueChange(_.Three_WJJ, _Three_WJJ, value);
                this._Three_WJJ = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Three_FL
        {
            get { return _Three_FL; }
            set
            {
                this.OnPropertyValueChange(_.Three_FL, _Three_FL, value);
                this._Three_FL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_S
        {
            get { return _Four_S; }
            set
            {
                this.OnPropertyValueChange(_.Four_S, _Four_S, value);
                this._Four_S = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_SN
        {
            get { return _Four_SN; }
            set
            {
                this.OnPropertyValueChange(_.Four_SN, _Four_SN, value);
                this._Four_SN = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_GL
        {
            get { return _Four_GL; }
            set
            {
                this.OnPropertyValueChange(_.Four_GL, _Four_GL, value);
                this._Four_GL = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_FMH
        {
            get { return _Four_FMH; }
            set
            {
                this.OnPropertyValueChange(_.Four_FMH, _Four_FMH, value);
                this._Four_FMH = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_KF
        {
            get { return _Four_KF; }
            set
            {
                this.OnPropertyValueChange(_.Four_KF, _Four_KF, value);
                this._Four_KF = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_WJJ
        {
            get { return _Four_WJJ; }
            set
            {
                this.OnPropertyValueChange(_.Four_WJJ, _Four_WJJ, value);
                this._Four_WJJ = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Four_FL
        {
            get { return _Four_FL; }
            set
            {
                this.OnPropertyValueChange(_.Four_FL, _Four_FL, value);
                this._Four_FL = value;
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
				_.ID};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.OrganID,
				_.One_S,
				_.One_SN,
				_.One_GL,
				_.One_FMH,
				_.One_KF,
				_.One_WJJ,
				_.One_FL,
				_.Two_S,
				_.Two_SN,
				_.Two_GL,
				_.Two_FMH,
				_.Two_KF,
				_.Two_WJJ,
				_.Two_FL,
				_.Three_S,
				_.Three_SN,
				_.Three_GL,
				_.Three_FMH,
				_.Three_KF,
				_.Three_WJJ,
				_.Three_FL,
				_.Four_S,
				_.Four_SN,
				_.Four_GL,
				_.Four_FMH,
				_.Four_KF,
				_.Four_WJJ,
				_.Four_FL};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._OrganID,
				this._One_S,
				this._One_SN,
				this._One_GL,
				this._One_FMH,
				this._One_KF,
				this._One_WJJ,
				this._One_FL,
				this._Two_S,
				this._Two_SN,
				this._Two_GL,
				this._Two_FMH,
				this._Two_KF,
				this._Two_WJJ,
				this._Two_FL,
				this._Three_S,
				this._Three_SN,
				this._Three_GL,
				this._Three_FMH,
				this._Three_KF,
				this._Three_WJJ,
				this._Three_FL,
				this._Four_S,
				this._Four_SN,
				this._Four_GL,
				this._Four_FMH,
				this._Four_KF,
				this._Four_WJJ,
				this._Four_FL};
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
            public readonly static Field All = new Field("*", "BHZ_ParamOverSet");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_ParamOverSet", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BHZ_ParamOverSet", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_S = new Field("One_S", "BHZ_ParamOverSet", "One_S");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_SN = new Field("One_SN", "BHZ_ParamOverSet", "One_SN");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_GL = new Field("One_GL", "BHZ_ParamOverSet", "One_GL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_FMH = new Field("One_FMH", "BHZ_ParamOverSet", "One_FMH");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_KF = new Field("One_KF", "BHZ_ParamOverSet", "One_KF");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_WJJ = new Field("One_WJJ", "BHZ_ParamOverSet", "One_WJJ");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field One_FL = new Field("One_FL", "BHZ_ParamOverSet", "One_FL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_S = new Field("Two_S", "BHZ_ParamOverSet", "Two_S");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_SN = new Field("Two_SN", "BHZ_ParamOverSet", "Two_SN");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_GL = new Field("Two_GL", "BHZ_ParamOverSet", "Two_GL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_FMH = new Field("Two_FMH", "BHZ_ParamOverSet", "Two_FMH");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_KF = new Field("Two_KF", "BHZ_ParamOverSet", "Two_KF");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_WJJ = new Field("Two_WJJ", "BHZ_ParamOverSet", "Two_WJJ");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Two_FL = new Field("Two_FL", "BHZ_ParamOverSet", "Two_FL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_S = new Field("Three_S", "BHZ_ParamOverSet", "Three_S");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_SN = new Field("Three_SN", "BHZ_ParamOverSet", "Three_SN");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_GL = new Field("Three_GL", "BHZ_ParamOverSet", "Three_GL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_FMH = new Field("Three_FMH", "BHZ_ParamOverSet", "Three_FMH");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_KF = new Field("Three_KF", "BHZ_ParamOverSet", "Three_KF");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_WJJ = new Field("Three_WJJ", "BHZ_ParamOverSet", "Three_WJJ");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Three_FL = new Field("Three_FL", "BHZ_ParamOverSet", "Three_FL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_S = new Field("Four_S", "BHZ_ParamOverSet", "Four_S");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_SN = new Field("Four_SN", "BHZ_ParamOverSet", "Four_SN");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_GL = new Field("Four_GL", "BHZ_ParamOverSet", "Four_GL");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_FMH = new Field("Four_FMH", "BHZ_ParamOverSet", "Four_FMH");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_KF = new Field("Four_KF", "BHZ_ParamOverSet", "Four_KF");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_WJJ = new Field("Four_WJJ", "BHZ_ParamOverSet", "Four_WJJ");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Four_FL = new Field("Four_FL", "BHZ_ParamOverSet", "Four_FL");
        }
        #endregion

    }
}

