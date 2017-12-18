using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dos.ORM.WebPC.Models
{
    public class TreeNode
    {
        //绑定节点的父节点。
        public object _parentId { set; get; }        
        //绑定节点的标识值。
        public object id { set; get; }
        //显示的节点值。
        public object value { set; get; }
        //显示的节点文本。
        public string text { set; get; }
        //该节点是否被选中。
        public bool selected { set; get; }
        public bool @checked { set; get; }
        //节点状态，'open' 或 'closed'。
        public string state { set; get; }
        //分类。
        public string type { set; get; } 
    }
}