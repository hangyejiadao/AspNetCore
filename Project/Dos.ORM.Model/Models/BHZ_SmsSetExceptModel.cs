using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Models
{
    public class BHZ_SmsSetExceptModel
    {

        //treegrid父节点Id    
        public Nullable<Guid> _parentId
        {
            get { return ParentID; }
        }
        public Guid ID { get; set; }        
        public Guid OrganID { get; set; }
        public Guid? ParentID { get; set; }   
        public string BlendNO { get; set; }       
        public string BlendName { get; set; }
        public int? IsOnline { get; set; }
        public int? IsLinkDev { get; set; }
        public string Memo { get; set; }
        public bool? Status { get; set; }


        public int? UnUpDay { get; set; }
        public string AdminName { get; set; }
        public string AdminPhone { get; set; }
        public string NoticePhone { get; set; }                
        public bool? IsEnable { get; set; }
              
        public DateTime? SCTIME { get; set; }
        public int? LastDay { get; set; }        

    }
}
