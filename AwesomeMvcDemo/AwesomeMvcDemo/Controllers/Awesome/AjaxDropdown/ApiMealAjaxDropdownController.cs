using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.Controllers.Awesome.AjaxDropdown
{
    /*begin*/
    public class ApiMealAjaxDropdownController : Controller
    {
        public ActionResult GetItems(int? v, string text = "ma")
        {
            var items = Db.Meals.Where(o => o.Name.ToLower().Contains(text.ToLower()))
                          .Select(o => new KeyContent(o.Id, o.Name));

            return Json(items);
        }
    }/*end*/
}
