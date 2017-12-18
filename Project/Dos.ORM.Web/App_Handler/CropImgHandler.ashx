<%@ WebHandler Language="C#" Class="CropImgHandler" %>

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Dos.ORM.Common.Helpers;

public class CropImgHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string xPoint = context.Request["xPoint"],
                yPoint = context.Request["yPoint"],
                width = context.Request["width"],
                height = context.Request["height"];
        string sourceFile = context.Server.MapPath(context.Request["imgPath"]);
        string saveDir = context.Request["uploadPath"] + DateTime.Now.ToString("yyyyMMdd/"),
                 savePath = saveDir + StringHelper.GetRandomStr(20, true, true, true) + ".jpg";
        try
        {
            //创建文件夹
            FileHelper.CreateDir(saveDir);
            System.Drawing.Bitmap cuted = ImageHelper.CropImage(new System.Drawing.Bitmap(sourceFile), Convert.ToInt32(xPoint), Convert.ToInt32(yPoint), Convert.ToInt32(width), Convert.ToInt32(height));
            string cutPath = context.Server.MapPath(savePath);
            cuted.Save(cutPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            context.Response.Write("{\"state\":true,\"info\":\"" + savePath + "\"}");
        }
        catch
        {
            context.Response.Write("{\"state\":false,\"info\":\"图片保存异常，请稍后再试！\"}");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}