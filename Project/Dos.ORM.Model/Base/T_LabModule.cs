using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class T_LabModule
    {

        public Guid? ModulePid { private get; set; }

        public string ModuleCode { get; set; }
        
        public List<BUS_Module> ModuleList { private get; set; }

        public List<BUS_UserLaboratory> XmLabList { private get; set; }

        public List<BUS_MixingPlan> UrlList { private get; set; }
        

        //项目实验室菜单
        public List<T_TreeModel> Trees { get; private set; }

        //模块列表
        public List<T_TreeModel> Modules { get; private set; }


        public void Init()
        {

            //生成模块
            if (ModuleList != null && ModuleList.Count > 0)
            {
                Modules = initModules(ModulePid);
            }

            //生成菜单
            if (XmLabList != null && XmLabList.Count > 0)
            {
                Trees = initTrees(null);
            }

        }


        //生成模块
        private List<T_TreeModel> initModules(Guid? ParentID)
        {
            if (ParentID == Guid.Empty) return null;

            var modules = new List<T_TreeModel>();

            var supers = ModuleList.Where(s => s.ParentID == ParentID).ToList();
            if (supers != null && supers.Count > 0)
            {
                foreach (var super in supers)
                {
                    var children = initModules(super.ID);
                    var item = new T_TreeModel()
                    {
                        id = super.ID,
                        pId = super.ParentID,
                        code = super.ModuleCode,
                        name = super.ModuleName,
                        src = super.PathURL,
                        iconCls = super.PicCss,
                        iconCss = super.PicUrl,
                        children = children
                    };
                    modules.Add(item);
                }
            }

            return modules;

        }

        //生成菜单
        private List<T_TreeModel> initTrees(Guid? ParentID)
        {
            if (ParentID == Guid.Empty) return null;

            var trees = new List<T_TreeModel>();

            var supers = XmLabList.Where(s => s.ParentId == ParentID).ToList();
            if (supers != null && supers.Count > 0)
            {
                foreach (var super in supers)
                {
                    object ExtraData = null;

                    if (ModuleCode == "03")
                    {
                        //03 拌合站数据监控系统 添加extraData数据
                        if (UrlList != null && UrlList.Count > 0)
                        {
                            ExtraData = UrlList.SingleOrDefault(s => s.OrganID == super.TargetId);
                        }
                    }
                    else if (ModuleCode == "04")
                    {
                        //04 拌合站接口 添加extraData数据
                        ExtraData = super.BhzApi;
                    }

                    else if (ModuleCode == "05")
                    {
                        //05 试验机接口 添加extraData数据
                        ExtraData = super.SyjApi;
                    }

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

        public void Init1()
        {
            if (XmLabList != null && XmLabList.Count > 0)
            {
                Trees = new List<T_TreeModel>();
                var xmList = XmLabList.Where(s => s.ParentId == null);

                foreach (var onelist in xmList)
                {
                    List<T_TreeModel> children = new List<T_TreeModel>();
                    var labList = XmLabList.Where(s => s.ParentId == onelist.TargetId);
                    foreach (var twolist in labList)
                    {

                        //03 拌合站数据监控系统 添加extraData数据
                        BUS_MixingPlan ExtraData = null;
                        if (UrlList != null && UrlList.Count > 0)
                        {
                            ExtraData = UrlList.SingleOrDefault(s => s.OrganID == twolist.TargetId);
                        }

                        var twomenu = new T_TreeModel()
                        {
                            id = twolist.TargetId,
                            pId = twolist.ParentId,
                            code = null,
                            name = twolist.TargetName,
                            iconCls = null,
                            extraData = ExtraData
                        };
                        children.Add(twomenu);
                    }

                    var onemenu = new T_TreeModel()
                    {
                        id = onelist.TargetId,
                        pId = onelist.ParentId,
                        code = null,
                        name = onelist.TargetName,
                        iconCls = null,
                        children = children
                    };
                    Trees.Add(onemenu);

                }       
            }


            if (ModuleList != null && ModuleList.Count > 0)
            {
                Modules = new List<T_TreeModel>();

                var moduleList = ModuleList.Where(s => s.ParentID == ModulePid);

                foreach (var onelist in moduleList)
                {
                    var onemenu = new T_TreeModel()
                    {
                        id = onelist.ID,
                        pId = onelist.ParentID,
                        code = onelist.ModuleCode,
                        name = onelist.ModuleName,
                        src = onelist.PathURL,
                        iconCls = onelist.PicCss,
                        iconCss = onelist.PicUrl,
                        children = null
                    };
                    Modules.Add(onemenu);

                }
            }

        }


    }
}
