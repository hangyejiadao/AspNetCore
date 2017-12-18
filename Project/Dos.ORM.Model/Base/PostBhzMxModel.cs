using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class PostBhzMxModel : ApiPageConModel
    {
        public string ZBID { get; set; }//主表ID
        public string BHJBH { get; set; }//拌合机编号
        public string SqlConn { get; set; }//连接字符串 
    }
}
