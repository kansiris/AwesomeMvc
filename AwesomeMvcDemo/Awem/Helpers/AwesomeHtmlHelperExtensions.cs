using System.Text;
using System.Web;
using Omu.AwesomeMvc;

namespace Omu.Awem.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class AwesomeHtmlHelperExtensions
    {
        /// <summary>
        /// Set the defaults for awem.js and jquery.validate (if present) by calling utils.init; 
        /// sets date format, first day of week, decimal separator, isMobileOrTablet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ahtml"></param>
        /// <returns></returns>
        public static IHtmlString Init<T>(this AwesomeHtmlHelper<T> ahtml)
        {
            var isMobileOrTablet = Autil.IsMobileOrTablet(ahtml) ? 1 : 0;
            var dateFormat = AweUtil.ConvertTojQueryDateFormat(Autil.CurrentCulture().DateTimeFormat.ShortDatePattern);
            var decimalSep = Autil.CurrentCulture().NumberFormat.NumberDecimalSeparator;

            var sb = new StringBuilder("<script>");
            sb.AppendFormat("awem.isMobileOrTablet = function() {{ return {0}; }};", isMobileOrTablet);
            sb.AppendFormat("awem.fdw = {0};", (int)Autil.CurrentCulture().DateTimeFormat.FirstDayOfWeek);
            sb.AppendFormat("utils.init('{0}', {1}, '{2}')", dateFormat, isMobileOrTablet, decimalSep);
            sb.Append("</script>");
            
            return new HtmlString(sb.ToString());
        }
    }
}
