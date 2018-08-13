using System.Globalization;
using System.Threading;
using System.Web.Helpers;
using Omu.Awem.Utils;
using Omu.AwesomeMvc;

namespace Omu.Awem
{
    internal static class Autil
    {
        internal static string Serialize(object input)
        {
            return Json.Encode(input);
        }

        internal static CultureInfo CurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        internal static bool IsMobileOrTablet<T>(AwesomeHtmlHelper<T> ahtml)
        {
            return MobileUtils.IsMobileOrTablet();
        }
    }
}
