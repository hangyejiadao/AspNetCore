using System.Web;

namespace Dos.ORM.Web.App_Common.Editor
{
    /// <summary>
    /// UeConfigHandler 的摘要说明
    /// </summary>
    public class UeConfigHandler : UeHandler
    {
        public UeConfigHandler(HttpContext context) : base(context) { }

        public override void Process()
        {
            WriteJson(UeConfig.Items);
        }
    }
}