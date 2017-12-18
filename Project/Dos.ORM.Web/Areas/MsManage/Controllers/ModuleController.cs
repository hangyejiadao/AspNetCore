using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using Dos.ORM.Model.Models;

namespace Dos.ORM.Web.Areas.MsManage.Controllers
{
    public class ModuleController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_ModuleData BusModule { get; set; }
        [Ninject.Inject]
        private IBUS_RoleModuleData BusRoleModuleRelation { get; set; }
        [Ninject.Inject]
        private IBUS_RoleData BusRole { get; set; }

        [Ninject.Inject]
        private IBUS_LaboratoryData BUSLaboratory { get; set; }

        //
        // GET: /MsManage/Module/
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
            var moduleName = Request["ModuleName"] ?? "";

            var exp = ExpHelper.Create<BUS_Module>(m => m.ModuleName != "");
            if (!string.IsNullOrWhiteSpace(moduleName)) exp = exp.And(m => m.ModuleName.Contains(moduleName));

            var retList = BusModule.GetPagesForDg(dgCon, "ModuleCode", "asc", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            BUS_Module dtlModel;

            if (OType != "add")
            {
                dtlModel = this.BusModule.GetModel(m => m.ID == gKeyId);

                ViewBag.keyId = gKeyId;
                ViewBag.parentId = dtlModel == null ? Guid.Empty : dtlModel.ParentID ?? Guid.Empty;
            }
            else
            {
                ViewBag.keyId = Guid.Empty;
                ViewBag.parentId = Guid.Empty;
                dtlModel = new BUS_Module() { IsHide = false };
            }
            if (dtlModel.IsHide == null)
                dtlModel.IsHide = false;

            ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");
            ViewBag.OperatePageTypes = new SelectList(GetEnumDicList<OperatePageType>(), "Key", "Value");

            return View(dtlModel);
        }

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetModule(Guid parentId)
        {
            var gKeyId = Guid.Parse(KeyId);

            var moduleList = this.BusModule.GetModulesForModule(gKeyId, parentId);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(BUS_Module model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            model.ParentID = model.ParentID == Guid.Empty || model.ParentID == null ? null : model.ParentID;

            #region 检查数据是否存在
            var exp = OType == "add" ?
               ExpHelper.Create<BUS_Module>(m => m.ParentID == model.ParentID && (m.ModuleName == model.ModuleName || (m.PathURL == model.PathURL && model.PathURL != null))) :
               ExpHelper.Create<BUS_Module>(m => m.ID != gKeyId && m.ParentID == model.ParentID && (m.ModuleName == model.ModuleName || (m.PathURL == model.PathURL && model.PathURL != null)));

            var isExist = this.BusModule.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "该模块名称或模块路径已存在，不能保存！"
                });
            }
            #endregion

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                if (OType == "add")
                {
                    model.ID = Guid.NewGuid();

                    ret = this.BusModule.InsertModel(model, trans);
                }
                else
                {
                    var updateExp = ExpHelper.Create<BUS_Module>(m => m.ID == gKeyId);
                    var oldModel = this.BusModule.GetModel(updateExp);

                    oldModel.ParentID = model.ParentID;
                    oldModel.ModuleName = model.ModuleName;
                    oldModel.PicUrl = model.PicUrl;
                    oldModel.PathURL = model.PathURL;
                    oldModel.IsHide = model.IsHide;
                    oldModel.OrderNum = model.OrderNum;
                    oldModel.Note = model.Note;

                    ret = this.BusModule.UpdateModel(oldModel, updateExp, trans);
                }

                //提交事务
                trans.Commit();
            }

            return JsonSubmit(ret);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_Module> list)
        {
            OperateModel ret;

            #region 如果删除父模块则子模块也一并删除
            List<BUS_Module> children = new List<BUS_Module>();
            foreach (var item in list)
            {
                if (item.ParentID == null)
                {
                    children.AddRange(this.BusModule.GetModels(p => p.ParentID == item.ID));
                }
            }
            list.AddRange(children);
            #endregion
            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {

                #region 删除模块 角色关系
                var moduleIds = list.Select(p => p.ID).ToList();

                var retDelModBtn = this.BusRoleModuleRelation.DeleteModelOther<BUS_RoleModule>(m => m.ModuleID.In(moduleIds), trans);
                #endregion

                ret = this.BusModule.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }



        #region 拌合站管理


        //拌合站连接数据库
        string SqlConn_BHZ = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConn_BHZ"].ConnectionString;
                     

        public ActionResult BhzIndex()
        {
            var OrganCode = BUSLaboratory.GetModels();
            ViewBag.OrganCode = OrganCode;
            return View();
        }

        public ActionResult BhzDetail()
        {

            return View();
        }


        //查询软件分类  
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Search)]
        public JsonResult GetBhzList(DgConModel dgCon)
        {
            var TargetId = Request["OrganID"] ?? "";

            //var TargetId = Guid.Empty.ToString();

            var list = BusModule.GetZhzBhjData(TargetId, SqlConn_BHZ);

            var model = new DgListModel<BHZ_BHZBHJ>(list, 1000);

            return Json(model, JsonRequestBehavior.AllowGet);
        }



        //根据ID加载
        [HttpPost]
        public JsonResult GetBhzByID()
        {
            var iKeyId = Guid.Parse(KeyId);

            BHZ_BHZBHJ BhzModel = null;

            var db = new PetaPoco.Database(SqlConn_BHZ);

            if (OType == "add")
            {
                BhzModel = new BHZ_BHZBHJ
                {
                    ID=Guid.NewGuid(),
                    ParentID=null,                
                    Status = true
                };
            }
            else
            {               
                BhzModel = db.SingleOrDefault<BHZ_BHZBHJ>("SELECT * FROM BHZ_BHZBHJ A WITH(NOLOCK) WHERE A.ID=@0", iKeyId);
            }

            var Supers = db.Query<BHZ_BHZBHJ>("SELECT * FROM BHZ_BHZBHJ A WITH(NOLOCK) WHERE A.ParentID IS NULL ORDER BY BlendNO ASC").ToList();
            
            var Labs= BUSLaboratory.GetModels();            
          
            var Model = new BHZ_BHZBHJModel()
            {
                OperType = OType,
                BhzModel = BhzModel,
                Supers = Supers,
                Labs = Labs
            };

            Model.Init();

            return Json(Model, JsonRequestBehavior.AllowGet);
        }

        //保存
        [HttpPost]
        public JsonResult SaveBhzData(string ModelData)
        {
            OperateModel OperModel = null;
            try
            {
                var Model = JsonHelper.JsonToObject<BHZ_BHZBHJModel>(ModelData);

                if (Model == null)
                {
                    OperModel = new OperateModel
                    {
                        Result = OperateRetType.Fail,
                        Msg = "保存失败！"
                    };
                }
                else if (isExists(Model.BhzModel.ID, Model.BhzModel.BlendNO))
                {
                    OperModel = new OperateModel()
                    {
                        Result = OperateRetType.Fail,
                        Msg = "编号重复！"
                    };
                }   
                else
                {
                    var db = new PetaPoco.Database(SqlConn_BHZ);

                    var Bhz_Model = Model.BhzModel;

                    string Exec_SQL = string.Empty;
                    if (Model.OperType == "add")
                    {
                        //var obj=  db.Insert("BHZ_BHZBHJ", "ID", Bhz_Model);              
                        if (Model.SuperDisable) //拌合站
                        {
                            Exec_SQL = string.Format(@"INSERT INTO BHZ_BHZBHJ(ID,OrganID,BlendNO,BlendName,Memo) VALUES('{0}','{1}','{2}','{3}',{4})",                                        
                                Bhz_Model.ID, Bhz_Model.OrganID, Bhz_Model.BlendNO, Bhz_Model.BlendName, Bhz_Model.Memo);
                                                    
                        }
                        else//拌合机
                        {
                            Exec_SQL = string.Format(@"INSERT INTO BHZ_BHZBHJ(ID,ParentID,OrganID,BlendNO,BlendName,Memo) VALUES('{0}','{1}','{2}','{3}','{4}',{5})",
                                Bhz_Model.ID, Bhz_Model.ParentID, Bhz_Model.OrganID, Bhz_Model.BlendNO, Bhz_Model.BlendName,Bhz_Model.Memo);                             
                        }
                      
                    }
                    else
                    {
                        if (Model.SuperDisable) //拌合站
                        {
                            Exec_SQL = string.Format(@"UPDATE BHZ_BHZBHJ SET OrganID='{1}',BlendNO='{2}',BlendName='{3}',Memo='{4}',ParentID=NULL WHERE ID='{0}'",
                                Bhz_Model.ID, Bhz_Model.OrganID, Bhz_Model.BlendNO, Bhz_Model.BlendName, Bhz_Model.Memo);

                        }
                        else//拌合机
                        {
                            Exec_SQL = string.Format(@"UPDATE BHZ_BHZBHJ SET OrganID='{1}',BlendNO='{2}',BlendName='{3}',Memo='{4}',ParentID='{5}' WHERE ID='{0}'",
                                    Bhz_Model.ID, Bhz_Model.OrganID, Bhz_Model.BlendNO, Bhz_Model.BlendName, Bhz_Model.Memo, Bhz_Model.ParentID);
                        }

                    }

                    var sucess = db.Execute(Exec_SQL) == 1;
                    OperModel = new OperateModel
                    {
                        Result = (sucess ? OperateRetType.Success : OperateRetType.Fail),
                        Msg = sucess ? "保存成功！" : "保存失败！"
                    };

                }

            }
            catch (Exception ex)
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "保存失败！"
                };
            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }
             

        //删除-逻辑删除
        [HttpPost]
        public JsonResult BhzDelete(List<BHZ_BHZBHJ> list)
        {
            OperateModel OperModel;

            if (list != null || list.Count > 0)
            {

                StringBuilder sb_sql = new StringBuilder();
                
                foreach (var item in list)
                {
                    sb_sql.Append( string.Format(@"UPDATE BHZ_BHZBHJ SET Status=0 WHERE ID='{0}';", item.ID));
                }

                var db = new PetaPoco.Database(SqlConn_BHZ);
                var sucess = db.Execute(sb_sql.ToString()) >= 1;

                OperModel = new OperateModel
                {
                    Result = (sucess ? OperateRetType.Success : OperateRetType.Fail),
                    Msg = sucess ? "删除成功！" : "删除失败！"
                };

            }
            else
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "删除失败！"
                };              
            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }



        //判断重复
        private bool isExists(Guid tID, string mNO)
        {

            var db = new PetaPoco.Database(SqlConn_BHZ);

            string Exec_SQL = string.Empty;

            if (tID == Guid.Empty)
            {
                Exec_SQL = string.Format("SELECT * FROM BHZ_BHZBHJ WHERE BlendNO='{0}' AND Status=1;", mNO);
            }
            else
            {
                Exec_SQL = string.Format("SELECT * FROM BHZ_BHZBHJ WHERE BlendNO='{0}' AND ID!='{1}' AND Status=1;", mNO, tID);
            }

            var list = db.Query<BHZ_BHZBHJ>(Exec_SQL).ToList();

            var rt_val = (list != null && list.Count > 0) ? true : false;

            return rt_val;
        }


        //判断重复
        private bool isExists1(Guid tID,Guid oID, string mNO)
        {

            var db = new PetaPoco.Database(SqlConn_BHZ);

            string Exec_SQL = string.Empty;

            if (tID == Guid.Empty)
            {
                Exec_SQL = string.Format("SELECT * FROM BHZ_BHZBHJ WHERE OrganID='{0}' AND BlendNO='{1}' AND Status=1;", oID, mNO);
            }
            else
            {
                Exec_SQL = string.Format("SELECT * FROM BHZ_BHZBHJ WHERE OrganID='{0}' AND BlendNO='{1}' AND ID!='{2}' AND Status=1;", oID, mNO, tID);
            }
            
            var list = db.Query<BHZ_BHZBHJ>(Exec_SQL).ToList();

            var rt_val = (list != null && list.Count>0) ? true : false;

            return rt_val;
        }

        #endregion 

    }
}