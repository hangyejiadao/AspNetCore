<%@ WebHandler Language="C#" Class="UploadImgHandler" %>

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Dos.ORM.Common.Helpers;

public class UploadImgHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            HttpPostedFile file = context.Request.Files["fileDataObj"];

            string saveUploadPath = context.Request["uploadPath"],
                    //是否创建时间路径
                    isCreateDatePath = "1",//Request["isCreateDatePath"],
                    //是否生成缩略图（暂时生成1张缩略图，1：生成、0：不生成）
                    isCutPic = string.IsNullOrWhiteSpace(context.Request["isCutPic"]) ? "0" : context.Request["isCutPic"],
                    strDate = DateTime.Now.ToString("yyyyMMdd/"),
                    //缩略图宽度
                    imgWidth = string.IsNullOrWhiteSpace(context.Request["imgWidth"]) ? "100" : context.Request["imgWidth"],
                    //缩略图高度
                    imgHeight = string.IsNullOrWhiteSpace(context.Request["imgHeight"]) ? "100" : context.Request["imgHeight"];

            string uploadPath = saveUploadPath + (isCreateDatePath == "1" ? strDate : "");
            string uploadPathOld = uploadPath;
            uploadPath = context.Server.MapPath(uploadPath);

            if (file != null)
            {
                //创建文件夹
                FileHelper.CreateDir(uploadPathOld);
                //文件名称
                string fileName = StringHelper.GetRandomStr(20, true, true, true) + FileHelper.GetFileExtension(file.FileName);

                string[] fileDiff = { "b_", "s_" };

                //保存源文件
                file.SaveAs(uploadPath + fileDiff[0] + fileName);

                //保存缩略图
                if (isCutPic == "1")
                {
                    ImageHelper.CutImage(uploadPath + fileDiff[0] + fileName, uploadPath + fileDiff[1] + fileName, Convert.ToInt32(imgWidth), Convert.ToInt32(imgHeight));
                }

                //是否删除原图片
                string isDeleteImage = string.IsNullOrEmpty(context.Request["isDeleteImage"]) ? "0" : context.Request["isDeleteImage"];
                if (isDeleteImage == "1" && !string.IsNullOrEmpty(context.Request["oldImagePath"]))
                {
                    string[] allDelImgPath = GetAllImagePath(context.Request["oldImagePath"]);
                    FileHelper.DeleteFile(allDelImgPath[0]);
                    FileHelper.DeleteFile(allDelImgPath[1]);
                }

                //返回缩略图的名称，以便存入数据库
                context.Response.Write("{\"state\":true,\"info\":\"" + uploadPathOld + (isCutPic == "1" ? fileDiff[1] : fileDiff[0]) + fileName + "\"}");
            }
            else
            {
                context.Response.Write("{\"state\":false,\"info\":\"上传失败（图片为空），请检查！\"}");
            }
        }
        catch (Exception)
        {
            context.Response.Write("{\"state\":false,\"info\":\"图片上传异常，请检查！\"}");
        }
    }

    /// <summary>
    /// 获取需要删除图片的其他地址
    /// </summary>
    /// <param name="imageSource">其中一张图片的地址</param>
    /// <returns></returns>
    protected string[] GetAllImagePath(string imageSource)
    {
        string thisFrontPath = imageSource.Substring(0, imageSource.LastIndexOf("/", StringComparison.Ordinal) + 1),
                  thisBackPath = imageSource.Substring(imageSource.LastIndexOf("/", StringComparison.Ordinal) + 1, imageSource.Length - imageSource.LastIndexOf("/", StringComparison.Ordinal) - 1);
        string thisOtherPath = thisBackPath.Contains("s_") ? thisBackPath.Replace("s_", "b_") : thisBackPath.Replace("b_", "s_");

        string[] thisResut = { imageSource, thisFrontPath + thisOtherPath };
        return thisResut;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}