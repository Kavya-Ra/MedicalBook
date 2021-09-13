using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedicalBook.DbContext;
using MedicalBook.ViewModel;

namespace MedicalBook.Controllers
{
    public class MenusController : Controller
    {
        private MedicalBookEntities db = new MedicalBookEntities();

        // GET: Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "m_id,m_name,m_desc,m_url,m_level")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "m_id,m_name,m_desc,m_url,m_level")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateSubmenu1()
        {
            var sub = new SelectList(db.Menus, "m_id", "m_name");
            ViewBag.sm1_menuid = sub;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSubmenu1(SubMenu_1 subMenu_1)
        {

            SubMenu_1 data = new SubMenu_1();
            data.sm1_menuid = subMenu_1.sm1_menuid;
            data.sm1_name = subMenu_1.sm1_name;
            data.sm1_desc = subMenu_1.sm1_desc;
            data.sm1_url = subMenu_1.sm1_url;
            data.sm1_level = subMenu_1.sm1_level;
            db.SubMenu_1.Add(data);
            await db.SaveChangesAsync();
            return RedirectToAction("SubMenuList");
        }

        public ActionResult SubMenuList()
        {
            return View(db.SubMenu_1.ToList());
        }

        public ActionResult CreateSubMenu2()
        {
            var sub = new SelectList(db.SubMenu_1, "sm1_id", "sm1_name");
            ViewBag.sm2_menuid = sub;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSubMenu2(SubMenu_2 subMenu_2)
        {
            SubMenu_2 data = new SubMenu_2();
            data.sm2_menuid = subMenu_2.sm2_menuid;
            data.sm2_name = subMenu_2.sm2_name;
            data.sm2_desc = subMenu_2.sm2_desc;
            data.sm2_url = subMenu_2.sm2_url;
            data.sm2_level = subMenu_2.sm2_level;
            db.SubMenu_2.Add(data);
            await db.SaveChangesAsync();
            return RedirectToAction("SubMenu2List");
        }

        public ActionResult SubMenu2List()
        {
            return View(db.SubMenu_2.ToList());
        }

        [HttpGet]
        public JsonResult HomeMenu()
        {
            MenuListViewModel menuListViewModel = new MenuListViewModel();
            List<MenuViewModel> menus = new List<MenuViewModel>();
            var data = db.Menus.ToList();
           
            foreach (var item in data)
            {
                MenuViewModel menu = new MenuViewModel()
                {
                m_id = item.m_id,
                m_name = item.m_name,
                m_desc = item.m_desc,
                m_url = item.m_url,
                m_level = item.m_level,
              };
                menus.Add(menu);

                  var data1 = db.SubMenu_1.Where(m => m.sm1_menuid == menu.m_id).ToList();
                List<SubMenu2ViewModel> models = new List<SubMenu2ViewModel>();
                List<SubMenuViewModel> models1 = new List<SubMenuViewModel>();
                foreach (var item1 in data1)
                {
                    SubMenuViewModel subMenuViewModel = new SubMenuViewModel()
                    {
                                sm1_id = item1.sm1_id,
                                sm1_name = item1.sm1_name,
                                sm1_desc = item1.sm1_desc,
                                sm1_menuid = item1.sm1_menuid,
                                sm1_level = item1.sm1_level,
                                sm1_url= item1.sm1_url
                    };

                    models1.Add(subMenuViewModel);
                    var data2 = db.SubMenu_2.Where(sm => sm.sm2_menuid == item1.sm1_id).ToList();

                    foreach (var item3 in data2)
                    {
                        SubMenu2ViewModel subMenu2 = new SubMenu2ViewModel()
                        {
                            sm2_id = item3.sm2_id,
                            sm2_name = item3.sm2_name,
                            sm2_menuid = item3.sm2_menuid,
                            sm2_desc = item3.sm2_desc,
                            sm2_level = item3.sm2_level,
                            sm2_url = item3.sm2_url
                        };
                        models.Add(subMenu2);
                       
                    }

                    subMenuViewModel.GetSubMenu_2s = models;
                    menu.subMenuViewModels = models1;
                    menuListViewModel.menuViewModels = menus;
                }

            }


            return Json(menuListViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}
