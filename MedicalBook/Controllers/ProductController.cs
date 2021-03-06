using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedicalBook.DbContext;
using MedicalBook.ViewModel;

namespace MedicalBook.Controllers
{
    public class ProductController : Controller
    {
        private MedicalBookEntities db = new MedicalBookEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.product_maincategory.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_maincategory product_maincategory = db.product_maincategory.Find(id);
            if (product_maincategory == null)
            {
                return HttpNotFound();
            }
            return View(product_maincategory);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mpc_id,mpc_name,mpc_desc,mpc_createdby,mpc_createddate,mpc_modifiedby,mpc_modifieddate,mpc_deletedby,mpc_deleteddate,mpc_isdeleted")] product_maincategory product_maincategory)
        {
            if (ModelState.IsValid)
            {
                product_maincategory.mpc_createdby = 0;
                product_maincategory.mpc_createddate = DateTime.Now;
                product_maincategory.mpc_modifiedby = 0;
                product_maincategory.mpc_modifieddate = DateTime.Now;
                product_maincategory.mpc_deletedby = 0;
                product_maincategory.mpc_deleteddate = DateTime.Now;
                db.product_maincategory.Add(product_maincategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_maincategory);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_maincategory product_maincategory = db.product_maincategory.Find(id);
            if (product_maincategory == null)
            {
                return HttpNotFound();
            }
            return View(product_maincategory);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mpc_id,mpc_name,mpc_desc,mpc_createdby,mpc_createddate,mpc_modifiedby,mpc_modifieddate,mpc_deletedby,mpc_deleteddate,mpc_isdeleted")] product_maincategory product_maincategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_maincategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_maincategory);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_maincategory product_maincategory = db.product_maincategory.Find(id);
            if (product_maincategory == null)
            {
                return HttpNotFound();
            }
            return View(product_maincategory);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product_maincategory product_maincategory = db.product_maincategory.Find(id);
            db.product_maincategory.Remove(product_maincategory);
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

        public async Task<ActionResult> CreateProductCategory(int? id)
        {
            if(id==null)
            {
                var sub = new SelectList(db.product_maincategory, "mpc_id", "mpc_name");
                ViewBag.pc_mcid = sub;
            }
            else{

                var data = await db.product_category.Where(p => p.pc_id == id).FirstOrDefaultAsync();
                ProductCategoryViewModel model = new ProductCategoryViewModel()
                {
                    pc_id = data.pc_id,
                    pc_name = data.pc_name,
                    pc_desc = data.pc_desc,
                  
                };
                var sub = new SelectList(db.product_maincategory, "mpc_id", "mpc_name",data.pc_mcid);
                ViewBag.pc_mcid = sub;
                return View(model);
            }

            return View();
        }
          
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> CreateProductCategory(ProductCategoryViewModel productCategoryView)
        {

            if (productCategoryView.pc_id != null)
            {
                product_category data = db.product_category.Find(productCategoryView.pc_id);
                if(data != null)
                {
                    if (ModelState.IsValid)
                    {
                        data.pc_mcid = productCategoryView.pc_mcid;
                        data.pc_name = productCategoryView.pc_name;
                        data.pc_desc = productCategoryView.pc_desc;
                        data.pc_modifiedby = 0;
                        data.pc_modifieddate = DateTime.Now;
                        db.Entry(data).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("ProductCategoryList");
                    }
                }
                return View(productCategoryView);
            }
            else
            {
                product_category data = new product_category();
                data.pc_mcid = productCategoryView.pc_mcid;
                data.pc_name = productCategoryView.pc_name;
                data.pc_desc = productCategoryView.pc_desc;
                data.pc_createdby = 0;
                data.pc_createddate = DateTime.Now;
                data.pc_modifiedby = 0;
                data.pc_modifieddate = DateTime.Now;
                data.pc_deletedby = 0;
                data.pc_deleteddate = DateTime.Now;
                db.product_category.Add(data);
                await db.SaveChangesAsync();
                return RedirectToAction("ProductCategoryList");
            }
           
        }

        public ActionResult ProductCategoryList()
        {
            return View(db.product_category.Where(m => m.pc_isdeleted == 0).ToList());
        }

        public ActionResult DeleteProductCategory(int? id)
        {
            if (id != null)
            {
                product_category category = db.product_category.Find(id);
                category.pc_isdeleted = 1;
                category.pc_deleteddate = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductCategoryList");
            }
            return View();
        }

        public async Task<ActionResult> CreateProduct(int? id)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            if (id == null)
            {
                
                var sub = new SelectList(db.product_category, "pc_id", "pc_name");
                ViewBag.category_id = sub;
                var sub1 = new SelectList(db.product_inventory, "pi_id", "pi_quantity");
                ViewBag.inventory_id = sub1;
                var sub2 = new SelectList(db.discounts, "dis_id", "dis_name");
                ViewBag.discount_id = sub2;
                var sub3 = new SelectList(db.authors, "au_id", "au_name");
                ViewBag.author_id = sub3;
                var sub4 = new SelectList(db.publishers, "pub_id", "pub_name");
                ViewBag.publisher_id = sub4;
               
            }
            else
            {
                var data = await db.products.Where(d => d.p_id == id).FirstOrDefaultAsync();
                ProductViewModel model = new ProductViewModel()
                {
                    p_id = data.p_id,
                    p_name = data.p_name,
                    p_desc = data.p_desc,
                    p_year = data.p_year,
                    p_edition = data.p_edition,
                    p_isbn = data.p_isbn,
                    author_id = data.author_id,
                    publisher_id = data.publisher_id,
                    p_price = data.p_price,
                    category_id = data.category_id,
                    inventory_id = data.inventory_id,
                    discount_id = data.discount_id,
                   
                };
                model.Product_Images_list = db.product_image.Where(m => m.product_id == model.p_id).ToList();

                var auth = new SelectList(db.authors, "au_id", "au_name", data.author_id);
                ViewBag.author_id = auth;
                var pub = new SelectList(db.publishers, "pub_id", "pub_name", data.publisher_id);
                ViewBag.publisher_id = pub;
                var proca = new SelectList(db.product_category, "pc_id", "pc_name", data.category_id);
                ViewBag.category_id = proca;
                var proin = new SelectList(db.product_inventory, "pi_id", "pi_quantity", data.inventory_id);
                ViewBag.inventory_id = proin;
                var dis = new SelectList(db.discounts, "dis_id", "dis_name", data.discount_id);
                ViewBag.discount_id = dis;
                return View(model);

            }
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProduct(ProductViewModel productViewModel, HttpPostedFileBase[] files)
        {
            if (productViewModel.p_id != null)
            {
                product data = db.products.Find(productViewModel.p_id);
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        data.p_name = productViewModel.p_name;
                        data.p_desc = productViewModel.p_desc;
                        data.p_price = productViewModel.p_price;
                        data.p_edition = productViewModel.p_edition;
                        data.p_isbn = productViewModel.p_isbn;
                        data.p_year = productViewModel.p_year;
                        data.category_id = productViewModel.category_id;
                        data.inventory_id = productViewModel.inventory_id;
                        data.discount_id = productViewModel.discount_id;
                        data.author_id = productViewModel.author_id;
                        data.publisher_id = productViewModel.publisher_id;
                        data.p_modifiedby = 0;
                        data.p_modifieddate = DateTime.Now;
                        db.Entry(data).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                       
                        int id  = (int)productViewModel.p_id;
                        if (ModelState.IsValid)
                        {   //iterating through multiple file collection
                            int i = 1;
                            Random random = new Random();
                            int unique = random.Next(1000, 9999);
                            foreach (HttpPostedFileBase file in files)
                            {

                                //Checking file is available to save.  
                                if (file != null)
                                {
                                    int count = i++;
                                    var ext = Path.GetExtension(file.FileName).ToLower();
                                    var filename = data.p_name + "pic_" + unique + "_" + count + ext;
                                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + filename);
                                    //Save file to server folder  
                                    file.SaveAs(ServerSavePath);
                                    //assigning file uploaded status to ViewBag for showing message to user.  
                                    product_image data2 = new product_image();
                                    data2.p_image = "UploadedFiles/" + filename;
                                    data2.product_id = id;
                                    db.product_image.Add(data2);


                                }

                            }
                            await db.SaveChangesAsync();
                        }
                        return RedirectToAction("ProductList");
                    }

                }
                return View(productViewModel);
            }
            else
            {
                product data = new product();
                data.p_name = productViewModel.p_name;
                data.p_desc = productViewModel.p_desc;
                data.p_price = productViewModel.p_price;
                data.p_edition = productViewModel.p_edition;
                data.p_isbn = productViewModel.p_isbn;
                data.p_year = productViewModel.p_year;
                data.category_id = productViewModel.category_id;
                data.inventory_id = productViewModel.inventory_id;
                data.discount_id = productViewModel.discount_id;
                data.author_id = productViewModel.author_id;
                data.publisher_id = productViewModel.publisher_id;
                data.p_createdby = 0;
                data.p_createddate = DateTime.Now;
                data.p_modifiedby = 0;
                data.p_modifieddate = DateTime.Now;
                data.p_deletedby = 0;
                data.p_deleteddate = DateTime.Now;
                db.products.Add(data);
                await db.SaveChangesAsync();

                    int id = db.products.Max(P => P.p_id);
                    if (ModelState.IsValid)
                    {   //iterating through multiple file collection
                        int i = 1;
                        Random random = new Random();
                        int unique = random.Next(1000, 9999);
                        foreach (HttpPostedFileBase file in files)
                        {

                            //Checking file is available to save.  
                            if (file != null)
                            {
                                int count = i++;
                                var ext = Path.GetExtension(file.FileName).ToLower();
                                var filename = data.p_name + "pic_" + unique + "_" + count + ext;
                                var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + filename);
                                //Save file to server folder  
                                file.SaveAs(ServerSavePath);
                                //assigning file uploaded status to ViewBag for showing message to user.  
                                product_image data2 = new product_image();
                                data2.p_image = "UploadedFiles/" + filename;
                                data2.product_id = id;
                                db.product_image.Add(data2);


                            }

                        }
                        await db.SaveChangesAsync();
                    }

                    return RedirectToAction("ProductList");
            }
        }

        public ActionResult DeletePicture(int? id, int pid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            product_image product_Image = db.product_image.Find(id);
            if (product_Image != null)
            {
                db.product_image.Remove(product_Image);
                db.SaveChanges();
                return View(pid);
            }

            return View(pid);
        }

        public ActionResult DeleteProduct(int? id)
        {
            if (id != null)
            {
                product product = db.products.Find(id);
                product.p_isdeleted = 1;
                product.p_deleteddate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public ActionResult ProductList()
        {

            List<ProductViewModel> product = new List<ProductViewModel>();
            var data = db.products.Where(m => m.p_isdeleted == 0).ToList();
            foreach (var item in data)
            {
                ProductViewModel menu = new ProductViewModel()
                {
                    p_id = item.p_id,
                    p_name = item.p_name,
                    p_desc = item.p_desc,
                    p_price = item.p_price,

                };

                menu.Product_Images_list = db.product_image.Where(m => m.product_id == menu.p_id).ToList();

                product.Add(menu);
            }


            return View(product);
        }

        public async Task<ActionResult> ProductInventory(int? id)
        {
            if(id!=null)
            {
                var data = await db.product_inventory.Where(p => p.pi_id == id).FirstOrDefaultAsync();
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductInventory(product_inventory product_inventory)
        {
                product_inventory data1 = db.product_inventory.Find(product_inventory.pi_id );
                if (data1 != null)
                {
                    if (ModelState.IsValid)
                    {
                    data1.pi_quantity = product_inventory.pi_quantity;
                    data1.pi_modifiedby = 0;
                    data1.pi_modifieddate = DateTime.Now;
                    db.Entry(data1).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("ProductInventoryList");
                    }
                }
                else
                {
                    product_inventory data = new product_inventory();
                    data.pi_quantity = product_inventory.pi_quantity;
                    data.pi_createdby = 0;
                    data.pi_createddate = DateTime.Now;
                    data.pi_modifiedby = 0;
                    data.pi_modifieddate = DateTime.Now;
                    data.pi_deletedby = 0;
                    data.pi_deleteddate = DateTime.Now;
                    db.product_inventory.Add(data);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ProductInventoryList");
                }
            return View();
          
        }

        public ActionResult ProductInventoryList()
        {
            return View(db.product_inventory.Where(p=>p.pi_isdeleted==0).ToList());
        }

        public ActionResult DeleteProductInventory(int? id)
        {
            if (id != null)
            {
                product_inventory inventory = db.product_inventory.Find(id);
                inventory.pi_isdeleted = 1;
                inventory.pi_deleteddate = DateTime.Now;
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductInventoryList");
            }
            return View();
        }

        public async Task<ActionResult> ProductDiscount(int?id)
        {
            if (id != null)
            {
                var data = await db.discounts.Where(p => p.dis_id == id).FirstOrDefaultAsync();
                return View(data);
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductDiscount(discount discount)
        {
            discount data1 = db.discounts.Find(discount.dis_id);

            if(data1!=null)
            {
                if (ModelState.IsValid)
                {
                    data1.dis_name = discount.dis_name;
                    data1.dis_percentage = discount.dis_percentage;
                    data1.dis_desc = discount.dis_desc;
                    data1.dis_modifiedby = 0;
                    data1.dis_modifieddate = DateTime.Now;
                    db.Entry(data1).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("ProductDiscountList");
                }
            }
            else
            {
                discount data = new discount();
                data.dis_name = discount.dis_name;
                data.dis_desc = discount.dis_desc;
                data.dis_percentage = discount.dis_percentage;
                data.dis_active = discount.dis_active;
                data.dis_createdby = 0;
                data.dis_createddate = DateTime.Now;
                data.dis_modifiedby = 0;
                data.dis_modifieddate = DateTime.Now;
                data.dis_deletedby = 0;
                data.dis_deleteddate = DateTime.Now;
                db.discounts.Add(data);

                await db.SaveChangesAsync();
                return RedirectToAction("ProductDiscountList");

            }
            return View();
        }

        public ActionResult ProductDiscountList()
        {
            return View(db.discounts.Where(p=>p.dis_isdeleted==0).ToList());
        }

        public ActionResult DeleteProductDiscount(int? id)
        {
            if (id != null)
            {
                discount discount = db.discounts.Find(id);
                discount.dis_isdeleted = 1;
                discount.dis_deleteddate = DateTime.Now;
                db.Entry(discount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductDiscountList");
            }
            return View();
        }

        public async Task<ActionResult> CreateAuthor(int?id)
        {
            if (id != null)
            {
                var data = await db.authors.Where(p => p.au_id == id).FirstOrDefaultAsync();
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAuthor(author author)
        {
            author data1 = db.authors.Find(author.au_id);

            if (data1 != null)
            {
                if (ModelState.IsValid)
                {
                    data1.au_name = author.au_name;
                    data1.au_modifiedby = 0;
                    data1.au_modifieddate = DateTime.Now;
                    db.Entry(data1).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("AuthorList");
                }
            }
            else
            {
                author data = new author();
                data.au_name = author.au_name;
                data.au_createdby = 0;
                data.au_createddate = DateTime.Now;
                data.au_modifiedby = 0;
                data.au_modifieddate = DateTime.Now;
                data.au_deletedby = 0;
                data.au_deleteddate = DateTime.Now;
                db.authors.Add(data);
                await db.SaveChangesAsync();
                return RedirectToAction("AuthorList");
            }
            return View();

        }

        public ActionResult AuthorList()
        {
            return View(db.authors.Where(a=>a.au_isdeleted==0).ToList());
        }
        public ActionResult DeleteAuthor(int? id)
        {
            if (id != null)
            {
                author author = db.authors.Find(id);
                author.au_isdeleted = 1;
                author.au_deleteddate = DateTime.Now;
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AuthorList");
            }
            return View();
        }

        public async Task<ActionResult> CreatePublisher(int?id)
        {

            if (id != null)
            {
                var data = await db.publishers.Where(p => p.pub_id == id).FirstOrDefaultAsync();
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePublisher(publisher publisher)
        {
            publisher data1 = db.publishers.Find(publisher.pub_id);

            if (data1 != null)
            {
                if (ModelState.IsValid)
                {
                    data1.pub_name = publisher.pub_name;
                    data1.pub_modifiedby = 0;
                    data1.pub_modifieddate = DateTime.Now;
                    db.Entry(data1).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("PublisherList");
                }
            }
            else
            {
                publisher data = new publisher();
                data.pub_name = publisher.pub_name;
                data.pub_createdby = 0;
                data.pub_createddate = DateTime.Now;
                data.pub_modifiedby = 0;
                data.pub_modifieddate = DateTime.Now;
                data.pub_deletedby = 0;
                data.pub_deleteddate = DateTime.Now;
                db.publishers.Add(data);
                await db.SaveChangesAsync();
                return RedirectToAction("PublisherList");
            }
            return View();
        }

        public ActionResult PublisherList()   
        {
            return View(db.publishers.Where(p=>p.pub_isdeleted==0).ToList());
        }

        public ActionResult DeletePublisher(int? id)
        {
            if (id != null)
            {
                publisher publisher = db.publishers.Find(id);
                publisher.pub_isdeleted = 1;
                publisher.pub_deleteddate = DateTime.Now;
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PublisherList");
            }
            return View();
        }
        [HttpGet]
        public JsonResult ActionSearch(String search)
        {
            var data = db.GetProductBySearch(search).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);       
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMenu()
        {
            var data = db.product_maincategory.ToList();
            HomeViewModel homeViewModel = new HomeViewModel();
            List<ProductMainCategoryViewModel> products = new List<ProductMainCategoryViewModel>();
            foreach (var item in data)
            {
                ProductMainCategoryViewModel productMain = new ProductMainCategoryViewModel()
                {
                mpc_id = item.mpc_id,
                mpc_name = item.mpc_name,
                mpc_desc = item.mpc_desc,
                mpc_createdby = item.mpc_createdby
                };
               

                var data1 = db.product_category.Where(m => m.pc_mcid == productMain.mpc_id).ToList();
                
                List<ProductCategoryViewModel> models1 = new List<ProductCategoryViewModel>();

                foreach (var items in data1)
                {
                    ProductCategoryViewModel productCategoryView = new ProductCategoryViewModel()
                    {
                        pc_id = items.pc_id,
                        pc_mcid = items.pc_mcid,
                        pc_name = items.pc_name,
                        pc_desc = items.pc_desc,
                      
                    };

                    models1.Add(productCategoryView);
                }
                productMain.productCategoryViews = models1;
                products.Add(productMain);
            }

            homeViewModel.productMainCategoryViewModels = products;

            return Json(homeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCategory()
        {
            var data = db.product_maincategory.ToList();
            List<ProductMainCategoryViewModel> products = new List<ProductMainCategoryViewModel>();
            HomeViewModel homeViewModel = new HomeViewModel();
            foreach (var item in data)
            {
                ProductMainCategoryViewModel productMain = new ProductMainCategoryViewModel()
                {
                    mpc_id = item.mpc_id,
                    mpc_name = item.mpc_name,
                    mpc_desc = item.mpc_desc,
                    mpc_createdby = item.mpc_createdby
                };
                products.Add(productMain);
            }

            homeViewModel.productMainCategoryViewModels = products;
            return Json(homeViewModel, JsonRequestBehavior.AllowGet);
        }

            public ActionResult ProductCategoryImage()
        {
            var sub = new SelectList(db.product_maincategory, "mpc_id", "mpc_name");
            ViewBag.maincategory_id = sub;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductCategoryImage(CategoryImageViewModel categoryImageView, HttpPostedFileBase[] files)
        {
            productcategory_image data = new productcategory_image();
            data.maincategory_id = categoryImageView.maincategory_id;
            data.pcimg_date = DateTime.Now;



            int i = 1;
            Random random = new Random();
            int unique = random.Next(1000, 9999);
            foreach (HttpPostedFileBase file in files)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    int count = i++;
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    var filename = "pic_" + unique + "_" + count + ext;
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + filename);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    data.pcimg_image = "UploadedFiles/" + filename;
                    db.productcategory_image.Add(data);
                    await db.SaveChangesAsync();
                }

            }
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductCategoryView(int catid)
        {
            List<ProductViewModel> product = new List<ProductViewModel>();
            var data = db.products.Where(p => p.category_id == catid).ToList();
            foreach (var item in data)
            {
                ProductViewModel menu = new ProductViewModel()
                {
                    p_id = item.p_id,
                    p_name = item.p_name,
                    p_desc = item.p_desc,
                    p_price = item.p_price,

                };

                menu.product_Image = db.product_image.Where(m => m.product_id == menu.p_id).FirstOrDefault();

                product.Add(menu);
            }

            return View(product);
        }

      
    }
}
