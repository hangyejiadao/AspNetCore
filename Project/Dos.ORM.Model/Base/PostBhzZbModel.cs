using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class PostBhzZbModel : ApiPageConModel
    {     
        public string OrganID { get; set; }//试验室
        public string SCRWBH { get; set; }//生产任务单
        public string GCMC { get; set; }//工程名称
        public string GCBW { get; set; }//工程部位
        public string SCSJStart { get; set; }//开始日期_生产时间
        public string SCSJEnd { get; set; }//结束日期_生产时间
        public string QDDJ { get; set; }//强度等级 


        public string SqlConn { get; set; }//连接字符串 
        

    }
}
