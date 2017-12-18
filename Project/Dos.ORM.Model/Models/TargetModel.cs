using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Models
{
    public class TargetModel
    {
        public Guid TargetId { get; set; }
        public String TargetName { get; set; }
        public Guid? ParentID { get; set; }
        public int TheLevel { get; set; }

    }
}
