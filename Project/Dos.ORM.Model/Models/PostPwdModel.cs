using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Models
{
    public class PostPwdModel
    {

        public Guid userId { get; set; }

        public string oldPwd { get; set; }

        public string newPwd { get; set; }


    }
}
