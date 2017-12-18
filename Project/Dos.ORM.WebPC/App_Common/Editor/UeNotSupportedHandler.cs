using System.Web;

namespace Dos.ORM.WebPC.App_Common.Editor
{
    /// <summary>
    /// UeNotSupportedHandler 的摘要说明
    /// </summary>
    public class UeNotSupportedHandler : UeHandler
    {
        public UeNotSupportedHandler(HttpContext context)
            : base(context)
        {
        }

        public override void Process()
        {
            WriteJson(new
            {
                state = "action 参数为空或者 action 不被支持。"
            });
        }
    }
}