using System;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsBus.Controllers
{
    public class IntroductionController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_IntroductionData BusIntroduction { get; set; }

        /// <summary>
        /// 100：关于我们（公司介绍）
        /// 200：联系我们
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            bool isExist = BusIntroduction.IsExistEntity(m => m.IntId == id);
            if (!isExist)
            {
                var model = new BUS_Introduction { IntId = id };
                if (!MsSysUserModel.IsSuperAdmin) model.CompanyId = MsSysUserModel.CompanyId;
                model.DtlInfo = string.Empty;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                var ret = BusIntroduction.InsertModel(model);
            }
            ViewBag.keyId = id;

            return View(BusIntroduction.GetModel(m => m.IntId == id));
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(BUS_Introduction model)
        {
            var updateExp = ExpHelper.Create<BUS_Introduction>(m => m.IntId == Convert.ToInt32(KeyId));
            var oldModel = BusIntroduction.GetModel(updateExp);

            if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;
            oldModel.Summary = model.Summary;
            oldModel.DtlInfo = model.DtlInfo;

            oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
            oldModel.ModTime = DateTime.Now;

            var ret = BusIntroduction.UpdateModel(oldModel, updateExp);
            return JsonSubmit(ret);
        }
    }
}