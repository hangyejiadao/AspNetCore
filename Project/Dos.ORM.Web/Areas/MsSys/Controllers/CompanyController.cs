using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class CompanyController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_CompanyData SysCompany { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Search)]
        public JsonResult GetList(DgConModel dgCon)
        {
            var keyName = Request["keyName"] ?? "";
            var conMan = Request["conMan"] ?? "";

            var exp = ExpHelper.Create<SYS_Company>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.CompanyName.Contains(keyName));
            if (!string.IsNullOrWhiteSpace(conMan)) exp = exp.And(m => m.ConMan.Contains(conMan));
            if (MsSysUserModel.AccountType > 1) exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysCompany.GetPagesForDg(dgCon, "CrtTime", exp);
            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Company() :
                SysCompany.GetModel(m => m.CompanyId == gKeyId);

            return View(dtlModel);
        }

        /// <summary>
        /// 获取所有公司数据（For EasyUI Combobox）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetCompanyList()
        {
            var curComId = string.IsNullOrWhiteSpace(Request["curComId"]) ? Guid.Empty : Guid.Parse(Request["curComId"]);
            var comData = Request["haveComId"] == "1" ? SysCompany.GetModels(m => m.Status == 1) :
                SysCompany.GetModels(m => m.Status == 1 && (m.CompanyId != curComId));

            var comList = GetComboboxItem(comData, "CompanyName", "CompanyId");
            return Json(comList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Company> list)
        {
            //TODO...删除对应的Logo物理文件

            var ret = SysCompany.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(SYS_Company model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var exp = OType == "add" ?
                ExpHelper.Create<SYS_Company>(m => m.CompanyName == model.CompanyName) :
                ExpHelper.Create<SYS_Company>(m => m.CompanyId != gKeyId && m.CompanyName == model.CompanyName);
            var isExist = SysCompany.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "公司名称已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.CompanyId = gKeyId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = SysCompany.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_Company>(m => m.CompanyId == gKeyId);
                var oldModel = SysCompany.GetModel(updateExp);

                if (MsSysUserModel.AccountType == 1) oldModel.ParentId = model.ParentId;

                oldModel.CompanyName = model.CompanyName;
                oldModel.ConMan = model.ConMan;
                oldModel.Mobile = model.Mobile;
                oldModel.Tel = model.Tel;
                oldModel.Email = model.Email;
                oldModel.WeChat = model.WeChat;
                oldModel.Microblog = model.Microblog;
                oldModel.LogoWidth = model.LogoWidth;
                oldModel.LogoHeight = model.LogoHeight;
                oldModel.LogoPath = model.LogoPath;
                oldModel.ProvinceId = model.ProvinceId;
                oldModel.CityId = model.CityId;
                oldModel.CountyId = model.CountyId;
                oldModel.TownId = model.TownId;
                oldModel.Address = model.Address;
                oldModel.Lng = model.Lng;
                oldModel.Lat = model.Lat;
                oldModel.DtlInfo = model.DtlInfo;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = SysCompany.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }

        public ActionResult Coor()
        {
            return View();
        }

        /// <summary>
        /// 选择公司
        /// </summary>
        /// <returns></returns>
        public ActionResult ChooseCompany()
        {
            return View();
        }

        #region 获取已有公司
        /// <summary>
        /// 获取已有公司
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetChooseCompanys()
        {
            //1：其他模块所需，2：公司管理模块所需
            var type = Request["type"];

            var firstText = string.IsNullOrWhiteSpace(Request["firstText"]) ? "所有公司" : Request["firstText"];

            var queryExp = ExpHelper.Create<SYS_Company>(m => m.Status == 1);
            if (type == "2") queryExp = queryExp.And(m => m.CompanyId != Guid.Parse(KeyId));

            var comData = SysCompany.GetModels(queryExp);

            var retList = GetChooseCompanysForComboTree(firstText, comData, type == "2");

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取一级公司
        /// </summary>
        /// <param name="firstText">默认第一项的文本</param>
        /// <param name="comList"></param>
        /// <param name="isCompanyModule">是否为公司管理模块所需</param>
        /// <returns></returns>
        private List<ComboTree> GetChooseCompanysForComboTree(string firstText, List<SYS_Company> comList, bool isCompanyModule = false)
        {
            var retList = new List<ComboTree>();

            if (!isCompanyModule)
            {
                retList.Add(new ComboTree
                {
                    id = "",
                    text = firstText,
                    state = "open",
                    iconCls = "icon-piesd"
                });
            }

            var oneLevel = comList.Where(m => m.ParentId == null || m.ParentId == Guid.Empty).ToList();
            var othLevel = comList.Where(m => m.ParentId != null && m.ParentId != Guid.Empty).ToList();

            foreach (var com in oneLevel)
            {
                var childs = GetChooseCompanysForComboTreeOth(com.CompanyId, othLevel);
                var existChilds = childs != null && childs.Count > 0;

                retList.Add(new ComboTree
                {
                    id = com.CompanyId,
                    text = com.CompanyName,
                    state = "open",
                    //iconCls = existChilds ? "icon-usergroup" : "icon-user1",
                    iconCls = "icon-piesd",
                    children = childs
                });
            }

            return retList;
        }
        /// <summary>
        /// 获取二级及以下的公司
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="comList"></param>
        /// <returns></returns>
        private List<ComboTree> GetChooseCompanysForComboTreeOth(Guid parentId, List<SYS_Company> comList)
        {
            var retList = new List<ComboTree>();

            var childs = comList.Where(m => m.ParentId == parentId).ToList();
            var childsOth = comList.Where(m => m.ParentId != parentId).ToList();
            bool existChilds = childs.Count > 0;

            foreach (var com in childs)
            {
                var childsOthList = childsOth.Where(m => m.ParentId == com.CompanyId).ToList();
                var existChildsOth = childsOthList.Count > 0;

                retList.Add(new ComboTree
                {
                    id = com.CompanyId,
                    text = com.CompanyName,
                    //iconCls = existChildsOth ? "icon-usergroup" : "icon-user1",
                    iconCls = "icon-piesd",
                    children = existChilds ?
                        GetChooseCompanysForComboTreeOth(com.CompanyId, childsOth) :
                        new List<ComboTree>()
                });
            }

            return retList;
        }
        #endregion
    }
}