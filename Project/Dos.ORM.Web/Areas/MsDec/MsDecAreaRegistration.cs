using System.Web.Mvc;

namespace Dos.ORM.Web.Areas.MsDec
{
    public class MsDecAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MsDec";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MsDec_default",
                "MsDec/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dos.ORM.Web.Areas.MsDec.Controllers" }
            );
        }
    }
}