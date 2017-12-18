using System;
using System.Linq;
using System.Collections.Generic;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Model.Base
{
    public class XmLabTree
    {
        public List<BUS_UserLaboratory> XmLab { private get; set; }

        public List<T_TreeModel> Trees { get; private set; }

        public void Init()
        {

            //生成菜单
            if (XmLab != null && XmLab.Count > 0)
            {
                Trees = initTrees(null);
            }

            //if (XmLab != null && XmLab.Count > 0)
            //{
            //    Trees = new List<T_TreeModel>();
            //    var xmList = XmLab.Where(s => s.ParentId == null);

            //    foreach (var onelist in xmList)
            //    {
            //        List<T_TreeModel> children = new List<T_TreeModel>();
            //        var labList = XmLab.Where(s => s.ParentId == onelist.TargetId);
            //        foreach (var twolist in labList)
            //        {
            //            var twomenu = new T_TreeModel()
            //            {
            //                id = twolist.TargetId,
            //                pId = twolist.ParentId,
            //                name = twolist.TargetName,
            //                iconCls = null
            //            };
            //            children.Add(twomenu);
            //        }

            //        var onemenu = new T_TreeModel()
            //        {
            //            id = onelist.TargetId,
            //            pId = onelist.ParentId,
            //            name = onelist.TargetName,
            //            iconCls = null,
            //            children = children
            //        };
            //        Trees.Add(onemenu);

            //    }

            //}
        }


        //生成菜单
        private List<T_TreeModel> initTrees(Guid? ParentID)
        {
            if (ParentID == Guid.Empty) return null;

            var trees = new List<T_TreeModel>();

            var supers = XmLab.Where(s => s.ParentId == ParentID).ToList();
            if (supers != null && supers.Count > 0)
            {
                foreach (var super in supers)
                {                    
                    var ExtraData = super.BhzApi;
                  
                    var children = initTrees(super.TargetId);
                    var onemenu = new T_TreeModel()
                    {
                        id = super.TargetId,
                        pId = super.ParentId,
                        code = null,
                        name = super.TargetName,
                        iconCls = null,
                        extraData = ExtraData,
                        children = children

                    };
                    trees.Add(onemenu);
                }
            }

            return trees;

        }


    }
}
