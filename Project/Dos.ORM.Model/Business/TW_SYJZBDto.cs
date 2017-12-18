using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dos.ORM.Common.Helpers; 

namespace Dos.ORM.Model.Business
{




    public class TW_SYJZBDto : TW_SYJZB
    {

        /// <summary>
        /// 打印展示页面
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Chart数据来源网址
        /// </summary>
        public string SoftUrl { get; set; }
        /// <summary>
        /// 压力机集合
        /// </summary>
        public List<TW_YLJDto> Yljs { get; set; }
        /// <summary>
        /// 万能机集合
        /// </summary>
        public List<TW_WNJDto> Wnjs { get; set; }

    }
}
