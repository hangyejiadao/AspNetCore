using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class PostAccessDB : ApiPageConModel
    {

        public int TableType { get; set; }//表类型
        public string OrganID { get; set; }//试验室
        public string TypeCode { get; set; }//类型代码
        public string StartDate { get; set; }//开始日期
        public string EndDate { get; set; }//结束日期
        public string SampleNum { get; set; }//样品编号 
        public string PlacePurpose { get; set; }//工程部位用途  
        public string StrengthGrade { get; set; }//强度等级  
        public string AgeDays { get; set; }//龄期(天)
        public string MarkNum { get; set; }//牌号  
        //public string FilterText { get; set; }

    }
}
