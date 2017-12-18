using System.Web.Mvc;

namespace Dos.ORM.Web.Areas.MsBus
{
    public class MsBusAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MsBus";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MsBus_default",
                "MsBus/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dos.ORM.Web.Areas.MsBus.Controllers" }
            );
        }
    }
}