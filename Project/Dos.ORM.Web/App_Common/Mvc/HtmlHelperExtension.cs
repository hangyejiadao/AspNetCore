/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Common.Mvc
 * 类名称：HtmlHelperExtension
 * 创建时间：2016-06-17 10:20:18
 * 创建人：Quber
 * 创建说明：HtmlHelper扩展控件
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Web.App_Common.Auth;
using EnumHelper = Dos.ORM.Common.Helpers.EnumHelper;

namespace Dos.ORM.Web.App_Common.Mvc
{
    /// <summary>
    /// HtmlHelper扩展控件
    /// </summary>
    public static class HtmlHelperExtension
    {
        #region 系统管理员操作按钮扩展
        /// <summary>
        /// 自定义按钮权限控件
        /// 用于控制当前操作员对某个页面的按钮权限
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ExtAuthBtn(this HtmlHelper htmlHelper)
        {
            var sbBtns = new StringBuilder();

            //管理员信息
            var msUser = MsSysUserAuth.Get();

            if (msUser == null || msUser.ButtonList == null) return new MvcHtmlString(sbBtns.ToString());

            //请求对象
            var request = HttpContext.Current.Request;
            //模块Id
            Guid moduleId;

            //操作类型（add：添加、modify：修改、view：查看、delete：删除）
            string oType = request["oType"];
            //optPageType（1：操作页面主页面，2：操作页面子页面）
            int optPageType = Convert.ToInt32(request["optPageType"]);
            if (optPageType == 1)
                moduleId = request["moduleId"] == null ? Guid.Empty : Guid.Parse(request["moduleId"]);
            else
            {
                var vSysModule = msUser.ModuleList.FirstOrDefault(c => c.ModulePath == request.FilePath);
                moduleId = vSysModule != null ? vSysModule.ModuleId : Guid.Empty;
            }

            foreach (var btn in msUser.ButtonList.OrderBy(m => m.SortNo).Where(btn => btn.ModuleId == moduleId))
            {
                if (oType == "view" && btn.ButtonType == (int)OperateBtnType.ForEdit && btn.ButtonName == EnumHelper.GetEnumTitle(OperateBtn.Save)) { }
                else
                {
                    /*
                     * 
                        1：EasyUI框架
                        2：AngularJS框架
                        3：原生框架
                     * 
                     */
                    if (btn.FwType == 1)
                    {
                        sbBtns.AppendFormat(
                            @"<a href=""{0}"" class=""{1}"" id=""{2}"" data-options=""iconCls:'{3}'{4},plain:true"">{5}</a>",
                            optPageType == 1 || (optPageType == 2 && string.IsNullOrWhiteSpace(btn.HrefClick)) ? "javascript:;" : btn.HrefClick,
                            "easyui-linkbutton",
                            btn.ButtonIdName,
                            btn.IconName,
                            //optPageType == 2 && !string.IsNullOrWhiteSpace(btn.OnClick) ? ",onClick:" + btn.OnClick : "",
                            (optPageType == 1 || optPageType == 2) && !string.IsNullOrWhiteSpace(btn.OnClick) ? ",onClick:" + btn.OnClick : "",
                            btn.ButtonName);
                    }
                    else
                    {
                        sbBtns.AppendFormat(
                           @"<a href=""{0}"" class=""{1}"" id=""{2}"" {3}>{4}</a>",
                           string.IsNullOrWhiteSpace(btn.HrefClick) ? "javascript:;" : btn.HrefClick,
                           "lbtn-main",
                           btn.ButtonIdName,
                           btn.FwType == 2 && !string.IsNullOrWhiteSpace(btn.OnClick) ? "ng-click=\"" + btn.OnClick + "\" " : "",
                           (!string.IsNullOrWhiteSpace(btn.IconName) ? "<i class=\"" + btn.IconName + "\"></i>" : "") + btn.ButtonName);
                    }
                }
            }

            return MvcHtmlString.Create(sbBtns.ToString());
        }
        #endregion

        #region 管理员设置或系统默认的主题样式
        /// <summary>
        /// 管理员设置或系统默认的主题样式
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ExtAuthTheme(this HtmlHelper htmlHelper)
        {
            //管理员信息
            var msUserTheme = MsSysUserAuth.Get().Operator.ThemeName;
            CookieHelper.Delete("MsSysTheme");
            CookieHelper.Set("MsSysTheme", msUserTheme);

            var strThemeLink = string.Format("<link href=\"/Content/Css/Themes/base.{0}.css\" rel=\"stylesheet\" id=\"linkThemes\" />", msUserTheme);
            return MvcHtmlString.Create(strThemeLink);
        }
        #endregion

        #region textbox扩展
        /// <summary>
        /// textbox扩展（原生）
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxY(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtTextBoxY(name, null);
        }

        /// <summary>
        /// textbox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxY(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetTextBoxOrForY(name, null, htmlAttributes));
        }

        /// <summary>
        /// textbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxForY<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtTextBoxForY(expression, null);
        }

        /// <summary>
        /// textbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxForY<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetTextBoxOrForY(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// textbox扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetTextBoxOrForY(string name, object value, object htmlAttributes, bool isFor = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class", "txt-main"}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "width", 200 },
                { "height", 28},
                { "required", "false" }, 
                { "isShowFill", "true" }, //当为必填项时，是否显示文本框后面的红色*标记
            };

            if (isFor)
            {
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrsY(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");

            return retBuilder + GetIsFillTipStr(dataOptions);
        }
        #endregion

        #region EasyUI textbox扩展
        /// <summary>
        /// EasyUI textbox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtTextBox(name, null);
        }

        /// <summary>
        /// EasyUI textbox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetTextBoxOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// EasyUI textbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtTextBoxFor(expression, null);
        }

        /// <summary>
        /// EasyUI textbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetTextBoxOrFor(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// EasyUI textbox扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetTextBoxOrFor(string name, object value, object htmlAttributes, bool isFor = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class", "easyui-textbox"}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "type", "'text'" }, 
                { "required", "false" }, 
                { "isShowFill", "true" }, //当为必填项时，是否显示文本框后面的红色*标记
                { "width", 200 },
                { "height", 28},
                { "value","''"},
                { "prompt","''"},
                { "tipPosition","'right'"},
                { "readonly","false"},
                { "validType","''"},
                { "buttonText","''"},
                { "buttonIcon","''"},
                { "buttonAlign","'right'"},
                { "onClickButton","null"},
                { "multiline","false"},
                { "iconCls","null"},
                { "iconAlign","'right'"},
                { "disabled","false"},
                { "onChange","function(newValue, oldValue){}"}
            };

            if (isFor)
            {
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");

            return retBuilder + GetIsFillTipStr(dataOptions);
        }

        private static string GetIsFillTipStr(Dictionary<string, object> dic)
        {
            string strRet = "<i class=\"fa frm-fa-fill fa-asterisk\" title=\"必填\"></i>";

            var isShowFill = Convert.ToBoolean(dic["isShowFill"]);
            var isRequired = Convert.ToBoolean(dic["required"]);
            return isRequired && isShowFill ? strRet : "";
        }
        #endregion

        #region EasyUI linkbutton扩展
        /// <summary>
        /// EasyUI linkbutton扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">按钮id</param>
        /// <returns></returns>
        public static MvcHtmlString ExtLinkButton(this HtmlHelper htmlHelper, string id)
        {
            return htmlHelper.ExtLinkButton(id, null);
        }

        /// <summary>
        /// EasyUI linkbutton扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">按钮id</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtLinkButton(this HtmlHelper htmlHelper, string id, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetLinkButton(id, htmlAttributes));
        }

        /// <summary>
        /// EasyUI linkbutton扩展
        /// </summary>
        /// <param name="id">按钮id</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        private static string GetLinkButton(string id, object htmlAttributes)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                { "class", "easyui-linkbutton" },
                { "id", id },
                { "name", id },
                { "href", "javascript:;" }
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "width", "null"},
                { "height", 28},
                { "text","''"},
                { "iconCls","''"},
                { "iconAlign","'left'"},
                { "plain","true"},
                { "disabled","false"},
                { "onClick","function(){}"}
            };

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, false);
            var builder = new TagBuilder("a");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.Normal)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");
            return retBuilder;
        }
        #endregion

        #region EasyUI numberspinner扩展
        /// <summary>
        /// EasyUI numberspinner扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberSpinner(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtNumberSpinner(name, null);
        }

        /// <summary>
        /// EasyUI numberspinner扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberSpinner(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetNumberSipnnerOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// EasyUI numberspinner扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberSpinnerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtNumberSpinnerFor(expression, null);
        }

        /// <summary>
        /// EasyUI numberspinner扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberSpinnerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetNumberSipnnerOrFor(fullName, thisValue, htmlAttributes, true));
        }

        private static string GetNumberSipnnerOrFor(string name, object value, object htmlAttributes, bool isFor = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class", "easyui-numberspinner"}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "required", "false" }, 
                { "width", 200 },
                { "height", 28},
                { "value","''"},
                { "readonly","false"},
                { "buttonText","''"},
                { "buttonIcon","''"},
                { "buttonAlign","'right'"},
                { "onClickButton","null"},
                { "iconCls","null"},
                { "iconAlign","'right'"},
                { "disabled","false"},
                { "onChange","function(newValue, oldValue){}"},//在改变当前值的时候触发
                { "onSpinUp","function(){}"},//在用户点击向上微调按钮的时候触发
                { "onSpinDown","function(){}"},//在用户点击向下微调按钮的时候触发
                { "min","0"},//最小值
                { "max","null"},//最大值
                { "increment","1"},//在点击微调按钮的时候的增量值
                { "precision","0"},//在十进制分隔符之后显示的最大精度。（即小数点后的显示精度）
                { "groupSeparator","','"},//使用哪一种字符分割整数组，以显示成千上万的数据。(比如：99,999,999.00中的','就是该分隔符设置。)
                { "prefix","''"},//前缀
                { "suffix","''"},//后缀
            };

            if (isFor)
            {
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");
            return retBuilder;
        }
        #endregion

        #region EasyUI numberbox扩展
        /// <summary>
        /// EasyUI numberbox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtNumberBox(name, null);
        }

        /// <summary>
        /// EasyUI numberbox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetNumberBoxOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// EasyUI numberbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtNumberBoxFor(expression, null);
        }

        /// <summary>
        /// EasyUI numberbox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetNumberBoxOrFor(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// EasyUI numberbox扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetNumberBoxOrFor(string name, object value, object htmlAttributes, bool isFor = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class", "easyui-numberbox"}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "required", "false" }, 
                { "width", 200 },
                { "height", 28},
                { "value","''"},
                { "readonly","false"},
                { "buttonText","''"},
                { "buttonIcon","''"},
                { "buttonAlign","'right'"},
                { "onClickButton","null"},
                { "multiline","false"},
                { "iconCls","null"},
                { "iconAlign","'right'"},
                { "disabled","false"},
                { "onChange","function(newValue, oldValue){}"},//在改变当前值的时候触发
                { "min","0"},//最小值
                { "max","null"},//最大值
                { "precision","0"},//在十进制分隔符之后显示的最大精度。（即小数点后的显示精度）
                { "groupSeparator","','"},//使用哪一种字符分割整数组，以显示成千上万的数据。(比如：99,999,999.00中的','就是该分隔符设置。)
                { "prefix","''"},//前缀
                { "suffix","''"},//后缀
            };

            if (isFor)
            {
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");
            return retBuilder;
        }
        #endregion

        #region EasyUI combobox扩展
        /// <summary>
        /// EasyUI combobox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="selectList">数据集</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDown(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.ExtDropDown(name, selectList, null);
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// 从客户端获取数据
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDownC(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return htmlHelper.ExtDropDown(name, new List<SelectListItem>(), htmlAttributes);
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// 
        /// 使用方法：
        ///     视图：
        ///         SelectList→@Html.ExtDropDown("ModuleType", (SelectList)ViewBag.ModuleTypes, new { required = true, width = 400 })
        ///         SelectListItem→@Html.ExtDropDown("ModuleType", (List<SelectListItem>)ViewBag.DepartmentList, new { })
        /// 
        ///     控制器：
        ///         SelectList→ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");
        ///         SelectListItem→ViewBag.RoleList = GetSelectListItem(SysRoleBll.GetEntities(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == UserModel.CompanyId), "RoleName", "RoleId");
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="selectList">数据集合</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDown(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return MvcHtmlString.Create(htmlHelper.DropDownList(name, selectList, GetDropDownOrForDic(null, htmlAttributes)).ToString()
                .Replace("&#39;", "'").Replace("&apos;", "'")
                .Replace("&#34;", "\"").Replace("&quot;", "\""));
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.ExtDropDownFor(expression, selectList, null);
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// 从客户端获取数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDownForC<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.ExtDropDownFor(expression, new List<SelectListItem>(), htmlAttributes);
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// 
        /// 使用方法：
        ///     视图：
        ///         SelectList→@Html.ExtDropDownFor(m => m.ModuleType, (SelectList)ViewBag.ModuleTypes, new { required = true, width = 400 })
        ///         SelectListItem→@Html.ExtDropDownFor(m => m.DepId, (List<SelectListItem>)ViewBag.DepartmentList, new { })
        /// 
        ///     控制器：
        ///         SelectList→ViewBag.ModuleTypes = new SelectList(GetEnumDicList<ModuleType>(), "Key", "Value");
        ///         SelectListItem→ViewBag.RoleList = GetSelectListItem(SysRoleBll.GetEntities(m => m.Status == 1 && m.IsEnable == 1 && m.CompanyId == UserModel.CompanyId), "RoleName", "RoleId");
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;

            return MvcHtmlString.Create(htmlHelper.DropDownListFor(expression, selectList, GetDropDownOrForDic(thisValue, htmlAttributes, true)).ToString()
               .Replace("&#39;", "'").Replace("&apos;", "'")
               .Replace("&#34;", "\"").Replace("&quot;", "\""));
        }

        /// <summary>
        /// EasyUI combobox扩展
        /// </summary>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static Dictionary<string, object> GetDropDownOrForDic(object value, object htmlAttributes, bool isFor = false)
        {
            IDictionary<string, object> htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //默认值
            object defaultVal = null;

            //定义默认属性
            var dic = new Dictionary<string, object>
            {
                { "class", "easyui-combobox" }
            };

            #region EasyUI中控件的data-options属性集合
            var dataOptions = new Dictionary<string, object>
            {
                { "required", "false" }, 
                { "width", 200 },
                { "height", 28},
                { "panelHeight", 200},
                { "validType",""},//'select'
                { "editable","false"},
                { "disabled","false"},
                { "readonly","false"},
                //{ "multiple","false"},//注意，multiple和onChange属性同时使用的话会报错
                { "value","''"},
                { "onChange","function(newValue, oldValue){}"},
                { "onSelect","function(rec){}"},
                { "onBeforeLoad","function(param){}"},
                { "onLoadSuccess","function(){}"},
                { "onLoadError","function(){}"},
                { "url","null"},
                { "method","'POST'"},
                { "valueField","'id'"},
                { "textField","'text'"},
                { "queryParams","{}"}
            };
            string strDataOptions = string.Empty;
            bool isValiSelect = false;
            foreach (var prop in htmlAttrsSource.Where(m => dataOptions.ContainsKey(m.Key) && m.Value != null))
            {
                object dataOpt;
                if (prop.Value.GetType().Name == "Boolean")
                {
                    dataOpt = prop.Value.ToString().ToLower();

                    //设置是否验证下拉框值为空
                    if (prop.Key == "required" && (string)dataOpt == "true")
                        isValiSelect = true;
                }
                else if (prop.Value.GetType().Name == "String" && prop.Key != "onChange" && prop.Key != "onSelect" && prop.Key != "onBeforeLoad" && prop.Key != "onLoadSuccess" && prop.Key != "onLoadError" && prop.Key != "queryParams")
                {
                    dataOpt = "'" + prop.Value + "'";

                    if (dataOptions.ContainsKey(prop.Key) && prop.Key == "value") defaultVal = dataOpt;
                }
                else
                    dataOpt = prop.Value;

                if (dataOptions.ContainsKey(prop.Key))
                    dataOptions[prop.Key] =
                        prop.Key == "onChange" && string.IsNullOrWhiteSpace(dataOpt.ToString()) ? "function(newValue, oldValue){}" :
                        prop.Key == "onSelect" && string.IsNullOrWhiteSpace(dataOpt.ToString()) ? "function(rec){}" :
                        prop.Key == "onBeforeLoad" && string.IsNullOrWhiteSpace(dataOpt.ToString()) ? "function(param){}" :
                        prop.Key == "onLoadSuccess" && string.IsNullOrWhiteSpace(dataOpt.ToString()) ? "function(){}" :
                        prop.Key == "onLoadError" && string.IsNullOrWhiteSpace(dataOpt.ToString()) ? "function(){}" :
                        dataOpt;
                else
                    dataOptions.Add(prop.Key, dataOpt);
            }
            dataOptions["validType"] = isValiSelect ? "'select'" : "''";
            defaultVal = isFor ? value != null ? "'" + value + "'" : "''" : defaultVal ?? "''";

            if (!dataOptions.ContainsKey("value")) dataOptions.Add("value", defaultVal);
            else dataOptions["value"] = defaultVal;
            //合并data-options属性
            strDataOptions = dataOptions.Aggregate(strDataOptions, (current, item) => current + (item.Key + ":" + item.Value + ","));
            #endregion

            foreach (var prop in htmlAttrsSource.Where(prop => !dataOptions.ContainsKey(prop.Key)))
            {
                if (prop.Key == "class" && dic.ContainsKey("class"))
                    dic["class"] = dic["class"] + " " + prop.Value.ToString().Trim();
                else
                    dic.Add(prop.Key, prop.Value);
            }
            dic.Add("data-options", strDataOptions.TrimEnd(','));

            return dic;
        }
        #endregion

        #region EasyUI combotree扩展
        /// <summary>
        /// EasyUI combotree扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtComboTree(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtComboTree(name, null);
        }

        /// <summary>
        /// EasyUI combotree扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtComboTree(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetComboTreeOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// EasyUI combotree扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtComboTreeFor(expression, null);
        }

        /// <summary>
        /// EasyUI combotree扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetComboTreeOrFor(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// EasyUI combotree扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetComboTreeOrFor(string name, object value, object htmlAttributes, bool isFor = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class", "easyui-combotree"}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "type", "'text'" }, 
                { "required", "false" }, 
                { "isShowFill", "true" }, //当为必填项时，是否显示文本框后面的红色*标记
                { "width", 200 },
                { "height", 28},
                { "value","''"},
                { "onClick","function(){}"},
                { "onLoadSuccess","function(node,data){}"},
                { "onChange","function(newValue, oldValue){}"},
                { "url","''"},
                { "method","'POST'"},
                { "lines","true"},
                { "queryParams","{}"}
            };

            if (isFor)
            {
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");

            return retBuilder + GetIsFillTipStr(dataOptions);
        }
        #endregion

        #region radio/checkbox扩展
        /// <summary>
        /// radio扩展
        /// 
        /// 使用方法：
        ///     视图：@Html.ExtRadioBoxList(m => m.IsEnable, (SelectList)ViewBag.StatusType)
        ///     控制器：
        ///         ViewBag.StatusType = new SelectList(EnumHelper.GetItemValueList<StatusType>(), "Key", "Value");
        ///         注意此处的StatusType为枚举类型
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <returns></returns>
        public static MvcHtmlString ExtRadioBoxList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.ExtRadioBoxList(expression, selectList, null);
        }

        /// <summary>
        /// radio扩展
        /// 
        /// 使用方法：
        ///     视图：@Html.ExtRadioBoxList(m => m.IsEnable, (SelectList)ViewBag.StatusType, new { id = "thisIsEnable" })
        ///     控制器：
        ///         ViewBag.StatusType = new SelectList(EnumHelper.GetItemValueList<StatusType>(), "Key", "Value");
        ///         注意此处的StatusType为枚举类型
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtRadioBoxList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            //获取模型对象
            var modelMd = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var thisName = modelMd.PropertyName;
            var thisValue = modelMd.Model.ToString().ToLower();

            return MvcHtmlString.Create(GetRadioOrChb(thisName, thisValue, selectList, htmlAttributes));
        }

        /// <summary>
        /// checkbox扩展
        /// 
        /// 使用方法：
        ///     视图：@Html.ExtCheckBoxList(m => m.IsEnable, (List<SelectListItem>)ViewBag.ChkBoxList)
        ///     控制器：
        ///         var chkBoxList = new List<SelectListItem>
        ///         {
        ///             new SelectListItem {Text = "类型1", Value = "0", Selected = true},
        ///             new SelectListItem {Text = "类型2", Value = "2", Selected = false},
        ///             new SelectListItem {Text = "类型3", Value = "1", Selected = true},
        ///             new SelectListItem {Text = "类型4", Value = "3", Selected = false}
        ///         }
        ///         ViewBag.ChkBoxList = chkBoxList;
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <returns></returns>
        public static MvcHtmlString ExtCheckBoxList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.ExtCheckBoxList(expression, selectList, null);
        }

        /// <summary>
        /// checkbox扩展
        /// 
        /// 使用方法：
        ///     视图：@Html.ExtCheckBoxList(m => m.IsEnable, (List<SelectListItem>)ViewBag.ChkBoxList, new { id = "thisComType" })
        ///     控制器：
        ///         var chkBoxList = new List<SelectListItem>
        ///         {
        ///             new SelectListItem {Text = "类型1", Value = "0", Selected = true},
        ///             new SelectListItem {Text = "类型2", Value = "2", Selected = false},
        ///             new SelectListItem {Text = "类型3", Value = "1", Selected = true},
        ///             new SelectListItem {Text = "类型4", Value = "3", Selected = false}
        ///         }
        ///         ViewBag.ChkBoxList = chkBoxList;
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="selectList">数据集合</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtCheckBoxList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            //获取模型对象
            var modelMd = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var thisName = modelMd.PropertyName;
            var thisValue = modelMd.Model.ToString().ToLower();
            return MvcHtmlString.Create(GetRadioOrChb(thisName, thisValue, selectList, htmlAttributes, true));
        }

        /// <summary>
        /// radio/checkbox扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="selectList">数据集合</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isCheckBox">是否为复选框</param>
        /// <returns></returns>
        private static string GetRadioOrChb(string name, object value, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool isCheckBox = false)
        {
            htmlAttributes = htmlAttributes ?? new { };

            //获取Id
            var thisId = string.Empty;
            PropertyInfo[] propArry = htmlAttributes.GetType().GetProperties();
            foreach (var prop in propArry.Where(prop => !string.IsNullOrWhiteSpace(prop.Name)).Where(prop => prop.Name.ToLower() == "id"))
            {
                thisId = prop.GetValue(htmlAttributes, null).ToString().Trim();
            }

            IDictionary<string, object> htmlAttrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var radioOrChb = isCheckBox ? "checkbox" : "radio";

            htmlAttrs.Add("type", radioOrChb);
            htmlAttrs.Add("name", name);

            StringBuilder stringBuilder = new StringBuilder();

            int idIndex = 0;
            foreach (SelectListItem selectItem in selectList.OrderByDescending(m => m.Value))
            {
                string id = string.Format("{0}{1}", name, idIndex++);

                IDictionary<string, object> newHtmlAttributes = htmlAttrs.DicCopy();
                newHtmlAttributes.Add("value", selectItem.Value);
                if (newHtmlAttributes.ContainsKey("id"))
                    newHtmlAttributes["id"] = id;
                else
                    newHtmlAttributes.Add("id", id);
                newHtmlAttributes.Add("label", selectItem.Text);

                if (isCheckBox)
                {
                    if (selectItem.Selected)
                    {
                        newHtmlAttributes.Add("checked", null);
                    }
                }
                else
                {
                    if ((string)value == selectItem.Value)
                    {
                        newHtmlAttributes.Add("checked", null);
                    }
                }

                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.MergeAttributes(newHtmlAttributes);
                string inputAllHtml = tagBuilder.ToString(TagRenderMode.SelfClosing);
                stringBuilder.Append(inputAllHtml);
            }
            return string.Format(@"<span class=""easyui-{0}"" id=""{1}"">" + stringBuilder + "</span>", radioOrChb, thisId);
        }
        #endregion

        #region EasyUI datebox扩展
        /// <summary>
        /// EasyUI datebox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDateBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtDateBox(name, null);
        }

        /// <summary>
        /// EasyUI datebox扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDateBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetDateBoxOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// EasyUI datebox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtDateBoxFor(expression, null);
        }

        /// <summary>
        /// EasyUI datebox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetDateBoxOrFor(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// EasyUI datetimebox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDatetimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtDatetimeBoxFor(expression, null);
        }

        /// <summary>
        /// EasyUI datetimebox扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtDatetimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetDateBoxOrFor(fullName, thisValue, htmlAttributes, true, true));
        }

        /// <summary>
        /// EasyUI datebox或datetimebox扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <param name="isDatetime">是否为datetimebox控件</param>
        /// <returns></returns>
        private static string GetDateBoxOrFor(string name, object value, object htmlAttributes, bool isFor = false, bool isDatetime = false)
        {
            var htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            //控件初始属性
            var htmlInitAttrs = new Dictionary<string, object>
            {
                {"id", name},
                {"name", name},
                {"class",  "easyui-" + (isDatetime ? "datetimebox" : "datebox")}
            };

            #region EasyUI中控件的data-options属性集
            var dataOptions = new Dictionary<string, object>
            {
                { "type", "'text'" }, 
                { "required", "false" }, 
                { "width", 200 },
                { "height", 28},
                { "value","''"},
                { "readonly","false"},
                { "validType","''"},//date
                { "buttonText","''"},
                { "buttonIcon","''"},
                { "buttonAlign","'right'"},
                { "onClickButton","null"},
                { "iconCls","null"},
                { "iconAlign","'right'"},
                { "disabled","false"},
                { "onSelect","function(date){}"}
            };
            if (isDatetime)
            {
                dataOptions.Add("spinnerWidth", "'100%'");
                dataOptions.Add("showSeconds", "true");
                dataOptions.Add("timeSeparator", "':'");
            }

            if (isFor)
            {
                value = value.GetType().Name == "DateTime" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") : value;
                htmlAttrsSource["value"] = value;
                dataOptions["value"] = value;
            }

            foreach (var item in htmlAttrsSource.Where(item => item.Value != null))
            {
                var attVal = GetAttrOptVal(item);

                if (dataOptions.ContainsKey(item.Key))
                    dataOptions[item.Key] = attVal;
                else
                    dataOptions.Add(item.Key, attVal);
            }
            #endregion

            var htmlRetAttrs = GetCtrlAttrs(htmlInitAttrs, dataOptions, isFor);
            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlRetAttrs);
            var retBuilder = builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'").Replace("&#34;", "\"").Replace("&quot;", "\"");
            return retBuilder;
        }
        #endregion

        #region hidden扩展
        /// <summary>
        /// hidden扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <returns></returns>
        public static MvcHtmlString ExtHidden(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ExtHidden(name, null);
        }

        /// <summary>
        /// hidden扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">控件名称</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtHidden(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetHiddenOrFor(name, null, htmlAttributes));
        }

        /// <summary>
        /// hidden扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtHiddenFor(expression, null);
        }

        /// <summary>
        /// hidden扩展
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetHiddenOrFor(fullName, thisValue, htmlAttributes, true));
        }

        /// <summary>
        /// hidden扩展
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="value">控件默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetHiddenOrFor(string name, object value, object htmlAttributes, bool isFor = false)
        {
            IDictionary<string, object> htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            IDictionary<string, object> htmlAttrs = new Dictionary<string, object>();

            htmlAttrs.Add("type", "hidden");
            htmlAttrs.Add("id", name);
            htmlAttrs.Add("name", name);

            //默认值
            object defaultVal = null;

            //增加或修改新的属性
            foreach (var prop in htmlAttrsSource)
            {
                if (prop.Key == "type" && prop.Value.ToString().Trim().Length > 0)
                    htmlAttrs["type"] = "hidden";
                else if (prop.Key == "value")
                    defaultVal = prop.Value;
                else if (!htmlAttrs.ContainsKey(prop.Key))
                    htmlAttrs.Add(prop.Key, prop.Value);
                else
                    htmlAttrs[prop.Key] = prop.Value;
            }

            defaultVal = isFor ? value : defaultVal;

            if (!htmlAttrs.ContainsKey("value")) htmlAttrs.Add("value", defaultVal ?? "");
            else htmlAttrs["value"] = defaultVal ?? "";

            var builder = new TagBuilder("input");
            builder.MergeAttributes(htmlAttrs);

            return builder.ToString(TagRenderMode.SelfClosing)
                .Replace("&#39;", "'").Replace("&apos;", "'")
                .Replace("&#34;", "\"").Replace("&quot;", "\"");
        }
        #endregion

        #region img扩展
        /// <summary>
        /// img扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">控件id</param>
        /// <returns></returns>
        public static MvcHtmlString ExtImg(this HtmlHelper htmlHelper, string id)
        {
            return htmlHelper.ExtImg(id, null);
        }

        /// <summary>
        /// img扩展
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">控件id</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtImg(this HtmlHelper htmlHelper, string id, object htmlAttributes)
        {
            return MvcHtmlString.Create(GetImgOrFor(id, null, htmlAttributes));
        }

        /// <summary>
        /// img扩展
        /// 此控件返回的Id在原来的基础上末尾追加了Show字符串，如：CompanyLogoShow
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <returns></returns>
        public static MvcHtmlString ExtImgFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.ExtImgFor(expression, null);
        }

        /// <summary>
        /// img扩展
        /// 此控件返回的Id在原来的基础上末尾追加了Show字符串，如：CompanyLogoShow
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">控件表达式</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <returns></returns>
        public static MvcHtmlString ExtImgFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var thisValue = metadata.Model;
            return MvcHtmlString.Create(GetImgOrFor(fullName, thisValue == null ? "" : thisValue.ToString(), htmlAttributes, true));
        }

        /// <summary>
        /// img扩展
        /// </summary>
        /// <param name="id">控件id</param>
        /// <param name="value">默认值</param>
        /// <param name="htmlAttributes">控件属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static string GetImgOrFor(string id, string value, object htmlAttributes, bool isFor = false)
        {
            IDictionary<string, object> htmlAttrsSource = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var sbImg = new StringBuilder();
            string alt = "Quber", src = "/Content/Images/Common/com_image.png", width = "100", height = "28";

            sbImg.AppendFormat(@"<img id=""{0}"" ", isFor ? id + "Show" : id);

            foreach (var item in htmlAttrsSource)
            {
                switch (item.Key)
                {
                    case "alt":
                        alt = item.Value.ToString();
                        break;
                    case "src":
                        src = item.Value.ToString();
                        break;
                    case "width":
                        width = item.Value.ToString();
                        break;
                    case "height":
                        height = item.Value.ToString();
                        break;
                }
            }
            src = isFor && value.Length > 0 ? value : src;

            sbImg.AppendFormat(@"alt=""{0}"" src=""{1}"" style=""width:{2}px;height:{3}px;"" ", alt, src, width, height);
            sbImg.Append("/>");

            return sbImg.ToString();
        }
        #endregion

        #region Form相关扩展
        /// <summary>
        /// 必填项*提示
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ExtFrmFill(this HtmlHelper htmlHelper)
        {
            var fillStr = GetIsFillTipStr(new Dictionary<string, object>
            {
               { "required", "true" }, 
               { "isShowFill", "true" }
            });
            return MvcHtmlString.Create(fillStr);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取从客户端传递进来的属性值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static object GetAttrOptVal(KeyValuePair<string, object> item)
        {
            //下列集合的Key的值不需要单引号
            var fnList = new Dictionary<string, object>
            {
                { "id",""},
                { "name",""},
                { "class",""},
                { "queryParams","{}"},
                { "onClick","function(){}"},
                { "onClickButton","null"},
                { "onChange","function(newValue, oldValue){}"},
                { "onLoadSuccess","function(node,data){}"},
                { "onSpinUp","function(){}"},
                { "onSpinDown","function(){}"},
                { "onSelect","function(date){}"}
            };

            object attVal;
            if (item.Value.GetType().Name == "Boolean")
                attVal = item.Value.ToString().ToLower();
            else if (item.Value.GetType().Name == "String" || item.Value.GetType().Name == "Guid")
                attVal = fnList.ContainsKey(item.Key) ? item.Value : string.Format("'{0}'", item.Value);
            else
                attVal = item.Value;

            return attVal;
        }

        /// <summary>
        /// 检查EasyUI组件所需的data-options的value是否为空、''、null等
        /// </summary>
        /// <param name="optVal"></param>
        /// <param name="isFor"></param>
        /// <returns></returns>
        private static bool CheckOptsValIsEmpty(object optVal, bool isFor = false)
        {
            //需要排除的属性值
            var empStr = new List<object> { "", "''", "null", "function(newValue, oldValue){}", "function(){}", "function(date){}" };
            if (!isFor) empStr.Add(null);

            var ret = empStr.Any(m => m == optVal);
            return ret;
        }

        /// <summary>
        /// 获取控件属性集合，包含data-options属性
        /// </summary>
        /// <param name="initAttr">控件初始属性</param>
        /// <param name="dataOpts">data-options属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static IDictionary<string, object> GetCtrlAttrs(IDictionary<string, object> initAttr, Dictionary<string, object> dataOpts, bool isFor)
        {
            var dataOptsRet = dataOpts.Where(item => !CheckOptsValIsEmpty(item.Value, isFor)).ToDictionary(item => item.Key, item => item.Value);

            #region 检查是否为textarea
            if (dataOpts.ContainsKey("multiline") && Convert.ToBoolean(dataOpts["multiline"]))
            {
                //最下宽度和最小高度为200px和60px
                dataOptsRet["width"] = dataOpts.ContainsKey("width") && Convert.ToInt32(dataOpts["width"]) > 200 ? Convert.ToInt32(dataOpts["width"]) : 200;
                dataOptsRet["height"] = dataOpts.ContainsKey("height") && Convert.ToInt32(dataOpts["height"]) > 60 ? Convert.ToInt32(dataOpts["height"]) : 60;
            }
            #endregion

            #region 设置非data-options的属性
            if (dataOptsRet.ContainsKey("id"))
            {
                initAttr["id"] = dataOptsRet["id"];
                dataOptsRet.Remove("id");
            }
            if (dataOptsRet.ContainsKey("name"))
            {
                initAttr["name"] = dataOptsRet["name"];
                dataOptsRet.Remove("name");
            }
            if (dataOptsRet.ContainsKey("href"))
            {
                initAttr["href"] = dataOptsRet["href"];
                dataOptsRet.Remove("href");
            }
            if (dataOptsRet.ContainsKey("class"))
            {
                initAttr["class"] = initAttr["class"] + " " + dataOptsRet["class"];
                dataOptsRet.Remove("class");
            }
            #endregion

            var dataOptsRetVal = dataOptsRet;
            if (dataOptsRetVal.ContainsKey("value") && dataOptsRetVal["value"] == null)
            {
                dataOptsRetVal["value"] = "''";
            }
            string strDataOptions = dataOptsRetVal.Aggregate("", (current, item) => current + (item.Key + ":" + item.Value + ",")).TrimEnd(',');
            initAttr["data-options"] = strDataOptions;

            if (isFor)
            {
                var ctrlForVal = dataOptsRet["value"] == null ? null : dataOptsRet["value"].ToString().TrimStart('\'').TrimEnd('\'');
                if (initAttr.ContainsKey("value"))
                    initAttr["value"] = ctrlForVal;
                else
                    initAttr.Add("value", ctrlForVal);
            }

            return initAttr;
        }

        /// <summary>
        /// 获取控件属性集合（原生）
        /// </summary>
        /// <param name="initAttr">控件初始属性</param>
        /// <param name="dataOpts">data-options属性</param>
        /// <param name="isFor">是否为实体所需控件</param>
        /// <returns></returns>
        private static IDictionary<string, object> GetCtrlAttrsY(IDictionary<string, object> initAttr, Dictionary<string, object> dataOpts, bool isFor)
        {
            var dataOptsRet = dataOpts.Where(item => !CheckOptsValIsEmpty(item.Value, isFor)).ToDictionary(item => item.Key, item => item.Value);

            #region 设置非data-options的属性
            if (dataOptsRet.ContainsKey("value") && dataOptsRet["value"] == null)
            {
                initAttr["value"] = "";
            }
            if (dataOptsRet.ContainsKey("required"))
            {
                dataOptsRet.Remove("required");
            }
            if (dataOptsRet.ContainsKey("isShowFill"))
            {
                dataOptsRet.Remove("isShowFill");
            }
            if (dataOptsRet.ContainsKey("class"))
            {
                initAttr["class"] = initAttr["class"] + " " + dataOptsRet["class"];
                dataOptsRet.Remove("class");
            }
            #endregion

            var dataOptsRetVal = dataOptsRet;
            string strDataOptions = dataOptsRetVal.Aggregate("", (current, item) => current + (item.Key + ":" + item.Value + ",")).TrimEnd(',');
            initAttr["style"] = strDataOptions;

            if (isFor)
            {
                var ctrlForVal = dataOptsRet["value"] == null ? null : dataOptsRet["value"].ToString().TrimStart('\'').TrimEnd('\'');
                if (initAttr.ContainsKey("value"))
                    initAttr["value"] = ctrlForVal;
                else
                    initAttr.Add("value", ctrlForVal);
            }

            return initAttr;
        }

        /// <summary>
        /// 字典拷贝
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        private static IDictionary<string, object> DicCopy(this IDictionary<string, object> ht)
        {
            return ht.ToDictionary(p => p.Key, p => p.Value);
        }
        #endregion
    }
}