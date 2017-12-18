using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Models
{

     [Serializable]
    public class BHZ_BHZBHJModel
    {
        //操作类型
        public String OperType { get; set; }

        //空Guid
        public Guid EmptyGuid { get; private set; }

        //是否选择上级上当
        public bool SuperDisable { get; set; }

        //主表
        public BHZ_BHZBHJ BhzModel { get; set; }

        //拌合站       
        public List<BHZ_BHZBHJ> Supers { get; set; }

        //试验室       
        public List<BUS_Laboratory> Labs { get; set; }

        public List<DropDownGrupModel> Labs_DP { get; set; }

        public void Init()
        {
            EmptyGuid = Guid.Empty;

            #region 软件分类

            if (OperType == "add")
            {
                SuperDisable = false;
            }
            else
            {
                SuperDisable = (BhzModel.ParentID == null);
            }
            
            #endregion

        }

    }
    
     public class DropDownGrupModel
     {
         public String _parentId { get; set; }
         public String id { get; set; }
         public String value { get; set; }
         public String text { get; set; }
         public String type { get; set; }
     }


}
