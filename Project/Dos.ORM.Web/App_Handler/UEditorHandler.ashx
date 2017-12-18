<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System.Web;
using Dos.ORM.Web.App_Common.Editor;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        UeHandler action = null;
        switch (context.Request["action"])
        {
            case "config":
                action = new UeConfigHandler(context);
                break;
            case "uploadimage":
                action = new UeUploadHandler(context, new UeUploadConfig()
                {
                    AllowExtensions = UeConfig.GetStringList("imageAllowFiles"),
                    PathFormat = UeConfig.GetString("imagePathFormat"),
                    SizeLimit = UeConfig.GetInt("imageMaxSize"),
                    UploadFieldName = UeConfig.GetString("imageFieldName")
                });
                break;
            case "uploadscrawl":
                action = new UeUploadHandler(context, new UeUploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = UeConfig.GetString("scrawlPathFormat"),
                    SizeLimit = UeConfig.GetInt("scrawlMaxSize"),
                    UploadFieldName = UeConfig.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo":
                action = new UeUploadHandler(context, new UeUploadConfig()
                {
                    AllowExtensions = UeConfig.GetStringList("videoAllowFiles"),
                    PathFormat = UeConfig.GetString("videoPathFormat"),
                    SizeLimit = UeConfig.GetInt("videoMaxSize"),
                    UploadFieldName = UeConfig.GetString("videoFieldName")
                });
                break;
            case "uploadfile":
                action = new UeUploadHandler(context, new UeUploadConfig()
                {
                    AllowExtensions = UeConfig.GetStringList("fileAllowFiles"),
                    PathFormat = UeConfig.GetString("filePathFormat"),
                    SizeLimit = UeConfig.GetInt("fileMaxSize"),
                    UploadFieldName = UeConfig.GetString("fileFieldName")
                });
                break;
            case "listimage":
                action = new UeListFileManager(context, UeConfig.GetString("imageManagerListPath"), UeConfig.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile":
                action = new UeListFileManager(context, UeConfig.GetString("fileManagerListPath"), UeConfig.GetStringList("fileManagerAllowFiles"));
                break;
            case "catchimage":
                action = new UeCrawlerHandler(context);
                break;
            default:
                action = new UeNotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}