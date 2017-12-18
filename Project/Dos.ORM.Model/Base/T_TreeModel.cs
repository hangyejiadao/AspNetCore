using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class T_TreeModel
    {

        public object extraData { get; set; }

        /// <summary>
        /// 节点Id
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public Guid? pId { get; set; }
        /// <summary>
        /// 节点代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 操作页面地址
        /// </summary>
        public string src { get; set; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string iconCls { get; set; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string iconCss { get; set; }

        public List<T_TreeModel> children { get; set; }

    }

}
