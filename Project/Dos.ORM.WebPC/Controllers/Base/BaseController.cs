using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.WebPC.App_Common.Mvc;
using Dos.ORM.WebPC.App_Common.Auth;

namespace Dos.ORM.WebPC.Controllers.Base
{
    /// <summary>
    /// 其他控制器都继承自该控制器
    /// </summary>
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {           
            base.OnAuthorization(filterContext);           
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {          
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        /// <summary>
        /// 重写JsonResult
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="contentType">内容类型</param>
        /// <param name="contentEncoding">内容编码</param>
        /// <param name="behavior">行为</param>
        /// <returns>JsonReuslt</returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResultOverride
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 自定义JsonResult（for easyui form ajax submit）
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="behavior">行为</param>
        /// <returns>JsonReuslt</returns>
        protected JsonResult JsonSubmit(object data, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return new JsonResultOverride
            {
                Data = data,
                ContentType = "text/html",
                //ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 自定义JsonResult返回格式
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="format">时间格式化格式（默认为yyyy-MM-dd HH:mm:ss）</param>
        /// <returns></returns>
        protected JsonResult Json(object data, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return new JsonResultOverride
            {
                Data = data,
                FormateStr = format
            };
        }

        /// <summary>
        /// 自定义JsonResult返回格式
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="behavior">行为</param>
        /// <param name="format">时间格式化格式（默认为yyyy-MM-dd HH:mm:ss）</param>
        /// <returns></returns>
        protected JsonResult Json(object data, JsonRequestBehavior behavior, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return new JsonResultOverride
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    base.OnException(filterContext);

        //    LogHelper.LogException("异常信息", filterContext.Exception);
        //}

        /// <summary>
        /// 根据key获取枚举的某文本
        /// </summary>
        /// <typeparam name="T">枚举类</typeparam>
        /// <param name="keyId">值Id</param>
        /// <returns></returns>
        public string GetEnumText<T>(int keyId) where T : struct
        {
            string enumText = string.Empty;
            foreach (var item in EnumHelper.GetItemValueList<T>().Where(item => item.Key == keyId))
            {
                enumText = item.Value;
                break;
            }
            return enumText;
        }

        /// <summary>
        /// 将枚举转换为字典集合
        /// 供@Html.ExtDropDown或@Html.ExtDropDownFor扩展使用
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="firstItem">是否包含默认的第一项</param>
        /// <param name="firstItemVal">默认第一项的值</param>
        /// <param name="firstItemTip">默认第一项提示信息</param>
        /// <returns></returns>
        public Dictionary<object, string> GetEnumDicList<T>(bool firstItem = true, object firstItemVal = null, string firstItemTip = "请选择...") where T : struct
        {
            var ret = new Dictionary<object, string>();
            if (firstItem) ret.Add(firstItemVal ?? "", firstItemTip);
            foreach (var item in EnumHelper.GetItemValueList<T>())
            {
                ret.Add(item.Key, item.Value);
            }
            return ret;
        }

        /// <summary>
        /// 将List对象转换为SelectListItem
        /// </summary>
        /// <param name="listObj">实体数据集对象</param>
        /// <param name="strTextName">文本字段名称</param>
        /// <param name="strValueName">值字段名称</param>
        /// <returns></returns>
        public List<SelectListItem> GetSelectListItem(object listObj, string strTextName, string strValueName)
        {
            var resultList = new List<SelectListItem>
            {
                new SelectListItem {Text = "请选择...", Selected = true, Value = ""}
            };
            foreach (var objModel in (IEnumerable)listObj)
            {
                string strText = string.Empty,
                          strValue = string.Empty;
                PropertyInfo[] piInfos = objModel.GetType().GetProperties();
                foreach (PropertyInfo pi in piInfos)
                {
                    if (pi.Name == strTextName)
                    {
                        strText = pi.GetValue(objModel, null).ToString();
                    }
                    if (pi.Name == strValueName)
                    {
                        strValue = pi.GetValue(objModel, null).ToString();
                    }
                    if (strText.Length <= 0 || strValue.Length <= 0) continue;
                    resultList.Add(new SelectListItem
                    {
                        Text = strText,
                        //Selected = true,
                        Value = strValue
                    });
                    break;
                }
            }
            return resultList;
        }

        /// <summary>
        /// 将List对象转换为SelectListItem
        /// </summary>
        /// <param name="listObj">实体数据集对象</param>
        /// <param name="strTextName">文本字段名称</param>
        /// <param name="strValueName">值字段名称</param>
        /// <returns></returns>
        public List<Combobox> GetComboboxItem(object listObj, string strTextName, string strValueName)
        {
            var resultList = new List<Combobox>
            {
                new Combobox {text = "请选择...", id = ""}
            };
            foreach (var objModel in (IEnumerable)listObj)
            {
                string strText = string.Empty,
                          strValue = string.Empty;
                PropertyInfo[] piInfos = objModel.GetType().GetProperties();
                foreach (PropertyInfo pi in piInfos)
                {
                    if (pi.Name == strTextName)
                    {
                        strText = pi.GetValue(objModel, null).ToString();
                    }
                    if (pi.Name == strValueName)
                    {
                        strValue = pi.GetValue(objModel, null).ToString();
                    }
                    if (strText.Length <= 0 || strValue.Length <= 0) continue;
                    resultList.Add(new Combobox
                    {
                        text = strText,
                        //selected = true,
                        id = strValue
                    });
                    break;
                }
            }
            return resultList;
        }
    }
}