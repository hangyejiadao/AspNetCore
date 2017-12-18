using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.WebPC.App_Common.Auth;
using Dos.ORM.WebPC.Controllers.Base;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class CommonController : SubBaseController
    {
      

        #region Action

        #region 404 500 Error Page
        /// <summary>
        /// 500 Error Page
        /// </summary>
        /// <returns></returns>
        public ActionResult PageError()
        {
            return View();
        }

        /// <summary>
        /// 404 Error Page
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }
        #endregion

        #region 登录过期
        /// <summary>
        /// 登录过期
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginTimeout()
        {
            return View();
        }
        #endregion

        #region 选择图标（FontAwesome和EasyUI）
        /// <summary>
        /// 选择图标（FontAwesome fa fa-*）
        /// </summary>
        /// <returns></returns>
        public ActionResult ChooseIconFontAwesome()
        {
            return View();
        }

        /// <summary>
        /// 选择图标（EasyUI icon-*）
        /// </summary>
        /// <returns></returns>
        public ActionResult ChooseIconEasyUi()
        {
            return View();
        }
        #endregion

        #region 上传图片或文件
        public ActionResult UploadImg()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }
        #endregion

        #endregion

        #region 方法       

        /// <summary>
        /// 获取系统管理员信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMsSysUser()
        {
            var msSysUser = LoginUserAuth.Get();
            var msSysUserIsNotNull = msSysUser != null && msSysUser.User != null;

            var operRet = new OperateModel
            {
                Result = msSysUserIsNotNull ? OperateRetType.Success : OperateRetType.Fail,
                Msg = !msSysUserIsNotNull ? "登录已过期，请重新登陆！" : "",
                Data = msSysUserIsNotNull ? msSysUser.User : null
            };

            return Json(operRet, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取Guid
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetGuid()
        {
            var ret = new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "",
                Data = Guid.NewGuid()
            };

            return JsonSubmit(ret);
        }
               
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadImgMethod(HttpPostedFileBase fileDataObj)
        {
            try
            {
                string
                    //是否生成缩略图（暂时生成1张缩略图，1：生成、0：不生成）
                    isCutPic = string.IsNullOrWhiteSpace(Request["isCut"]) ? "0" : Request["isCut"],
                    //缩略图宽度
                    cutWidth = string.IsNullOrWhiteSpace(Request["cutWidth"]) ? "100" : Request["cutWidth"],
                    //缩略图高度
                    cutHeight = string.IsNullOrWhiteSpace(Request["cutHeight"]) ? "100" : Request["cutHeight"];

                string uploadPath = Request["path"] + DateTime.Now.ToString("yyyyMMdd/");
                string uploadPathOld = uploadPath;
                uploadPath = Server.MapPath(uploadPath);

                if (fileDataObj != null)
                {
                    //创建文件夹
                    FileHelper.CreateDir(uploadPathOld);
                    //文件名称
                    string fileName = StringHelper.GetRandomStr(20) + FileHelper.GetFileExtension(fileDataObj.FileName);

                    string[] fileDiff = { "b_", "s_" };

                    //保存源文件
                    fileDataObj.SaveAs(uploadPath + fileDiff[0] + fileName);

                    //保存缩略图
                    if (isCutPic == "1")
                        ImageHelper.CutImage(uploadPath + fileDiff[0] + fileName, uploadPath + fileDiff[1] + fileName, Convert.ToInt32(cutWidth), Convert.ToInt32(cutHeight));

                    //是否删除原图片
                    string isDelOldImg = string.IsNullOrEmpty(Request["isDelOldImg"]) ? "0" : Request["isDelOldImg"];
                    if (isDelOldImg == "1" && !string.IsNullOrEmpty(Request["oldPath"]))
                    {
                        string[] allDelImgPath = GetAllImagePath(Request["oldPath"]);
                        FileHelper.DeleteFile(allDelImgPath[0]);
                        FileHelper.DeleteFile(allDelImgPath[1]);
                    }

                    //返回缩略图的名称，以便存入数据库
                    return Json(new { status = true, info = uploadPathOld + (isCutPic == "1" ? fileDiff[1] : fileDiff[0]) + fileName }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { status = false, info = "上传失败（图片为空），请检查！" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = false, info = "图片上传异常，请检查！" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 获取需要删除图片的其他地址
        /// </summary>
        /// <param name="imageSource">其中一张图片的地址</param>
        /// <returns></returns>
        private string[] GetAllImagePath(string imageSource)
        {
            string thisFrontPath = imageSource.Substring(0, imageSource.LastIndexOf("/", StringComparison.Ordinal) + 1),
                      thisBackPath = imageSource.Substring(imageSource.LastIndexOf("/", StringComparison.Ordinal) + 1, imageSource.Length - imageSource.LastIndexOf("/", StringComparison.Ordinal) - 1);
            string thisOtherPath = thisBackPath.Contains("s_") ? thisBackPath.Replace("s_", "b_") : thisBackPath.Replace("b_", "s_");

            string[] thisResut = { imageSource, thisFrontPath + thisOtherPath };
            return thisResut;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult DownFile(string filePath, string fileName)
        {
            filePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["AttachmentPath"] + filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fileName));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }
        #endregion
    }
}