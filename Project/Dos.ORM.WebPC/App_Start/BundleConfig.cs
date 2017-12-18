using System.Web.Optimization;

namespace Dos.ORM.WebPC
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //主题样式
            bundles.Add(new StyleBundle("~/MsSys/CssTheme").Include(
                "~/Content/Css/Themes/base.blue.css"
            ));


            #region For List And Detail
            bundles.Add(new StyleBundle("~/MsSys/ListDetail/Css1").Include(
                "~/Content/Components/Animate/animate.min.css",
                "~/Content/Components/FontAwesome/css/font-awesome.min.css",
                "~/Content/Components/EasyUI/themes/bootstrap/easyui.css"
            ));
            bundles.Add(new ScriptBundle("~/MsSys/ListDetail/Js2").Include(
                "~/Content/Components/jQuery/jquery-1.12.4.min.js",
                "~/Content/Components/EasyUI/jquery.easyui.min.js",
                "~/Content/Components/EasyUI/locale/easyui-lang-zh_CN.js"
            ));
            bundles.Add(new StyleBundle("~/MsSys/ListDetail/CssTheme").Include(
                "~/Content/Css/Themes/base.green.css"
            ));
            bundles.Add(new ScriptBundle("~/MsSys/ListDetail/Js4").Include(
                "~/Content/Js/Base/base.core.js",
                "~/Content/Js/Base/base.loading.js"
            ));
            #endregion

            bundles.Add(new ScriptBundle("~/MsSys/ListDetail/JsNg").Include(
                "~/Content/Components/AngularJS/angular.min.js"
            ));

            bundles.Add(new ScriptBundle("~/MsSys/ListDetail/JsOth").Include(
               "~/Content/Components/jClock/jquery.jclock.js",
               "~/Content/Components/zTree/js/jquery.ztree.core.min.js",
               "~/Content/Components/Layer/layer.min.js"
            ));
        }
    }
}
