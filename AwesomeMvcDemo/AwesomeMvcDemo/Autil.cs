using System.Web.Mvc;

namespace AwesomeMvcDemo
{
    public static class Autil
    {
        public static string ServerMapPath(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.Server.MapPath(@"~\");
        }
    }
}
