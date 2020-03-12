using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPOS.Models;

namespace SPOS.Controllers
{
    public class T_PRODController : Controller
    {
        private readonly SPOSEntities db = new SPOSEntities();

        // GET: T_PROD
        public ActionResult Index()
        {
            //return View(await db.T_PROD.ToListAsync());


            using (SPOSEntities db = new SPOSEntities())
            {
                List<T_SubCategory> subCategories = db.T_SubCategory.ToList();
                List<T_Category> categories = db.T_Category.ToList();
                List<T_PROD> products = db.T_PROD.ToList();

                var subcategory = (from s in subCategories
                                  join c in categories on s.CategoryID equals c.CategoryID into table1
                                  from c in table1.ToList()

                                  join p in products on s.CategoryID equals p.CategoryID into table2
                                  from p in table2.ToList()
                                  where p.SubCategoryID == s.SubCategoryID
                                  select new ViewModel
                                  {
                                      SubCategories = s,
                                      Categories = c,
                                      Products = p
                                  }).OrderBy(x => x.Products.ProductID); 
                return View(subcategory);
            }
        }

        // GET: T_PROD/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PROD t_PROD = await db.T_PROD.FindAsync(id);
            if (t_PROD == null)
            {
                return HttpNotFound();
            }
            return View(t_PROD);
        }

        // GET: T_PROD/Create
        public ActionResult Create()
        {

            SPOSEntities entities = new SPOSEntities();
            ViewModel model = new ViewModel();
            foreach (var category in entities.T_Category)
            {
                model.PT_Category.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryID.ToString() });
            }
            return View(model);



        }

        // POST: T_PROD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,CategoryID,SubCategoryID,PBarcode,PName,CostPrice,SalePrice,Discount,ReorderLevel,Manufacture,UnitID,IUser,EUser,IDate,EDate,IsRemoved,SalingPrice")] ViewModel viewModel, int? categoryID, int? SubCategoryID)
        {

         

                ViewModel model = new ViewModel();
            SPOSEntities entities = new SPOSEntities();
            foreach (var category in entities.T_Category)
            {
                model.PT_Category.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryID.ToString() });
               
            }

            if (categoryID.HasValue)
            {
                var T_SubCategory = (from subcategory in entities.T_SubCategory
                              where subcategory.CategoryID == categoryID.Value
                              select subcategory).ToList();
                foreach (var subcategory in T_SubCategory)
                {
                    model.PT_SubCategory.Add(new SelectListItem { Text = subcategory.SubCategoryName, Value = subcategory.SubCategoryID.ToString() });
                }

            
            }

            if (ModelState.IsValid && SubCategoryID.HasValue)
            {
                viewModel.Products.CategoryID = categoryID.Value;
                viewModel.Products.SubCategoryID = SubCategoryID.Value;
                db.T_PROD.Add(viewModel.Products);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: T_PROD/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PROD t_PROD = await db.T_PROD.FindAsync(id);
            if (t_PROD == null)
            {
                return HttpNotFound();
            }
            return View(t_PROD);
        }

        // POST: T_PROD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,CategoryID,SubCategoryID,PBarcode,PName,CostPrice,SalePrice,Discount,ReorderLevel,Manufacture,UnitID,IUser,EUser,IDate,EDate,IsRemoved,SalingPrice")] T_PROD t_PROD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_PROD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_PROD);
        }

        // GET: T_PROD/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PROD t_PROD = await db.T_PROD.FindAsync(id);
            if (t_PROD == null)
            {
                return HttpNotFound();
            }
            return View(t_PROD);
        }

        // POST: T_PROD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_PROD t_PROD = await db.T_PROD.FindAsync(id);
            db.T_PROD.Remove(t_PROD);
            await db.SaveChangesAsync();
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
    }
}
