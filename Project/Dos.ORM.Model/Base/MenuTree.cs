using System;
using System.Linq;
using System.Collections.Generic;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Model.Base
{
    public class ModuleTree
    {
        public List<BUS_Module> Modules { private get; set; }

        public List<T_TreeModel> Menus { get; private set; }

        public void Init()
        {
            if (Modules != null && Modules.Count > 0)
            {

                Menus = new List<T_TreeModel>();

                var OneList = Modules.Where(s => s.ParentID == null);

                foreach (var onelist in OneList)
                {
                    List<T_TreeModel> children = new List<T_TreeModel>();
                    var TwoList = Modules.Where(s => s.ParentID == onelist.ID);
                    foreach (var twolist in TwoList)
                    {
                        var twomenu = new T_TreeModel()
                        {
                            id = twolist.ID,
                            pId = twolist.ParentID,
                            code=twolist.ModuleCode,
                            name = twolist.ModuleName,
                            src=twolist.PathURL,
                            iconCls = twolist.PicCss,
                            iconCss = twolist.PicUrl
                        };
                        children.Add(twomenu);
                    }

                    var onemenu = new T_TreeModel()
                    {
                        id = onelist.ID,
                        pId = onelist.ParentID,
                        code = onelist.ModuleCode,
                        name = onelist.ModuleName,
                        src = onelist.PathURL,
                        iconCls = onelist.PicCss,
                        iconCss = onelist.PicUrl,
                        children = children
                    };
                    Menus.Add(onemenu);

                }

            }
        }

    }
}
