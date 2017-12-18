﻿using System.Web.Mvc;

namespace Dos.ORM.WebPC.Areas.MsSys
{
    public class MsSysAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MsSys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MsSys_default",
                "MsSys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dos.ORM.WebPC.Areas.MsSys.Controllers" }
            );
        }
    }
}