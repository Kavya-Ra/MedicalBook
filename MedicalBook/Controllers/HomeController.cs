using MedicalBook.DbContext;
using MedicalBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalBook.Controllers
{
    public class HomeController : Controller
    {
        private MedicalBookEntities db = new MedicalBookEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var data = db.GetProductWithImageList().ToList();
            HomeViewModel homeView = new HomeViewModel();
            homeView.getProductWithImages = data;
            return View(homeView);
        }

        [HttpGet]
        public JsonResult ProductSearch(String search)
        {
            var d = "";
            if(search!=null)
            {
                var data = db.GetProductBySearch(search).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(d);
         
        }

        [HttpGet]
        public JsonResult MenuList()
        {
           
            var data2 = db.product_maincategory.ToList();
          /*  HomeViewModel homeView = new HomeViewModel();
            homeView.GetProduct_Maincategories = data2;


            foreach (var item in data2)
            {
                homeView.product_Categories = db.product_category.Where(m => m.pc_mcid == item.mpc_id).ToList();
            }*/

            return Json(data2, JsonRequestBehavior.AllowGet);

        }
    }
}
