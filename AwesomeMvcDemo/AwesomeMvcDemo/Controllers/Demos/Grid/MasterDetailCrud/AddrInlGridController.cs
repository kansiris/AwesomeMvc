using System.Web.Mvc;
using AwesomeMvcDemo.Models;
using AwesomeMvcDemo.ViewModels.Input;
using Omu.Awem.Utils;

namespace AwesomeMvcDemo.Controllers.Demos.Grid.MasterDetailCrud
{
    public class AddrInlGridController : Controller
    {
        private object MapToGridModel(RestaurantAddress o)
        {
            return new { o.Id, o.Line1, o.Line2 };
        }

        [HttpPost]
        public ActionResult Create(RestaurantAddressInput input)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.GetErrorsInline());
            }

            var ent = Db.Insert(new RestaurantAddress
            {
                RestaurantId = input.RestaurantId,
                Line1 = input.Line1,
                Line2 = input.Line2
            });

            return Json(new { Item = MapToGridModel(ent) });

        }

        [HttpPost]
        public ActionResult Edit(RestaurantAddressInput input)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.GetErrorsInline());
            }

            var ent = Db.Get<RestaurantAddress>(input.Id);
            ent.Line1 = input.Line1;
            ent.Line2 = input.Line2;
            Db.Update(ent);

            return Json(new { });
        }
    }
}
