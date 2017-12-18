using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dos.ORM.Web.Areas.MsManage.Controllers
{
    public class ProjectController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_ProjectData BusProj { get; set; }
        [Ninject.Inject]
        private IBUS_LaboratoryData BusLab { get; set; }
        [Ninject.Inject]
        private IBUS_ProjectLaboratoryData BusProjLabRelation { get; set; }

        //
        // GET: /MsManage/Proj/
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
            var projName = Request["ProjName"] ?? "";

            var allproj = this.BusProj.GetModels(null);
            var alllab = this.BusLab.GetModels(null).OrderBy(p => p.OrderNum).ThenBy(p => p.OrganShorName).ThenBy(p => p.OrganName).ToList();
            if (!string.IsNullOrWhiteSpace(projName))
            {
                allproj = allproj.Where(p => p.ProjectName.Contains(projName)).ToList();
            }
            List<ProjectModel> listProj = new List<ProjectModel>();

            for (int i = 0; i < allproj.Count; i++)
            {
                listProj.Add(new ProjectModel
                {
                    ID = (Guid)allproj[i].ProjectID,
                    Name = allproj[i].ProjectName,
                    IsEnabled = allproj[i].IsEnable,
                    _parentId = null
                });
            }

            for (int i = 0; i < alllab.Count; i++)
            {
                var projlab = this.BusProjLabRelation.GetModel(p => p.OrganID == alllab[i].OrganID);
                if (projlab != null && allproj.FirstOrDefault(p => p.ProjectID == projlab.ProjectID) != null)
                {
                    listProj.Add(new ProjectModel
                    {
                        ID = (Guid)alllab[i].OrganID,
                        Name = alllab[i].OrganShorName ?? alllab[i].OrganName,
                        OrderNum = alllab[i].OrderNum,
                        _parentId = (Guid)projlab.ProjectID
                    });
                }
            }


            return Json(new DgListModel(listProj, 0), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="isProj">项目还是试验室</param>
        /// <returns></returns>
        public ActionResult Detail(bool isProj)
        {
            if (isProj)
            {
                return RedirectToAction("DetailProj", new { oType = Request["oType"], keyId = Request["keyId"], optPageType = Request["optPageType"] });
            }
            else
            {
                return RedirectToAction("DetailLab", new { oType = Request["oType"], keyId = Request["keyId"], optPageType = Request["optPageType"] });
            }
        }

        /// <summary>
        /// 查看项目
        /// </summary>
        /// <returns></returns>
        public ActionResult DetailProj()
        {
            var gKeyId = Guid.Parse(KeyId);
            BUS_Project dtlModel = this.BusProj.GetModel(m => m.ProjectID == gKeyId);

            return View(dtlModel);
        }

        /// <summary>
        /// 查看试验室
        /// </summary>
        /// <returns></returns>
        public ActionResult DetailLab()
        {
            var gKeyId = Guid.Parse(KeyId);
            BUS_Laboratory dtlModel = this.BusLab.GetModel(m => m.OrganID == gKeyId);

            return View(dtlModel);
        }


        /// <summary>
        /// 保存项目的修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveProjData(BUS_Project model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret = new OperateModel();

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                var updateExp = ExpHelper.Create<BUS_Project>(m => m.ProjectID == gKeyId);
                var oldModel = this.BusProj.GetModel(updateExp);

                oldModel.ProjectID = model.ProjectID;
                oldModel.ProjectName = model.ProjectName;
                oldModel.ProjectShorName = model.ProjectShorName;
                oldModel.ProjectCode = model.ProjectCode;
                oldModel.是否启用 = model.是否启用;
                oldModel.Note = model.Note;
                oldModel.DataCollectionUrl = model.DataCollectionUrl;
                oldModel.SoftUrl = model.SoftUrl;
                oldModel.BhzApi = model.BhzApi;
                ret = this.BusProj.UpdateModel(oldModel, updateExp, trans);

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }


        /// <summary>
        /// 保存试验室的修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveLabData(BUS_Laboratory model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret = new OperateModel();

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                var updateExp = ExpHelper.Create<BUS_Laboratory>(m => m.OrganID == gKeyId);
                var oldModel = this.BusLab.GetModel(updateExp);

                oldModel.OrganID = model.OrganID;
                oldModel.OrganName = model.OrganName;
                oldModel.OrganShorName = model.OrganShorName;
                oldModel.CompanyName = model.CompanyName;
                oldModel.CompanyCertificate = model.CompanyCertificate;
                oldModel.LabCreateDate = model.LabCreateDate;
                oldModel.EngineerNumber = model.EngineerNumber;
                oldModel.TestNumber = model.TestNumber;
                oldModel.SeniorTitleNumber = model.SeniorTitleNumber;
                oldModel.DirectorCertificate = model.DirectorCertificate;
                oldModel.DirectorName = model.DirectorName;
                oldModel.Title = model.Title;
                oldModel.Mobile = model.Mobile;
                oldModel.Add = model.Add;
                oldModel.Tel = model.Tel;
                oldModel.Area = model.Area;
                oldModel.BusinessRange = model.BusinessRange;
                oldModel.Code = model.Code;
                oldModel.OrderNum = model.OrderNum;
                ret = this.BusLab.UpdateModel(oldModel, updateExp, trans);

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }
    }

    /// <summary>
    /// 用于展示项目和实验室树状结构的模型
    /// </summary>
    public class ProjectModel
    {
        /// <summary>
        /// 项目或试验室的ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 用于在列表中展示的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public Nullable<Boolean> IsEnabled { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? OrderNum { get; set; }
        /// <summary>
        /// treegrid父节点Id
        /// </summary>
        public Nullable<Guid> _parentId { get; set; }
    }
}