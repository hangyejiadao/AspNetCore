using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using Dos.ORM.Model.Models;
using Dos.ORM.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dos.ORM.Web.Areas.MsManage.Controllers
{
    public class SharedController : BaseController
    {

        [Ninject.Inject]
        private IBUS_LaboratoryData BUSLaboratory { get; set; }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectTarget(int OperType=1,int IsMulti = 1)
        {
            ViewBag.OperType = OperType;
            ViewBag.IsMulti = IsMulti;            
            return View();
        }


        //选择试验室
        [HttpPost]
        public JsonResult GetTargetList()
        {

            var Exec_SQL = @"SELECT ProjectID TargetId, ProjectShorName TargetName,NULL ParentID,0 TheLevel FROM BUS_Project WITH(NOLOCK) 
                                    UNION ALL 
                             SELECT A.OrganID TargetId,A.OrganShorName TargetName,B.ProjectID ParentID,1 TheLevel
                               FROM BUS_Laboratory A WITH(NOLOCK) LEFT JOIN  BUS_ProjectLaboratory B WITH(NOLOCK)  ON A.OrganID=B.OrganID;";

            var Model = DB.DbCont.FromSql(Exec_SQL).ToList<TargetModel>();         
           
            return Json(Model, JsonRequestBehavior.AllowGet);


        }
        
    }
}