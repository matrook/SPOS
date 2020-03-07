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
using System.Configuration;
using System.Data.SqlClient;

namespace SPOS.Controllers
{
    public class T_SubCategoryController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_SubCategory
        public ActionResult Index()
        {
           
            using (SPOSEntities db = new SPOSEntities())
            {
                List<T_SubCategory> subCategories = db.T_SubCategory.ToList();
                List<T_Category> categories = db.T_Category.ToList();
              

                var subcategory = from s in subCategories
                                     join c in categories on s.CategoryID equals c.CategoryID into table1
                                     from c in table1.ToList()
                                     
                                     select new ViewModel
                                     {
                                         subCategories = s,
                                         categories = c
                                         
                                     };
                return View(subcategory);
            }



        }

        // GET: T_SubCategory/Details/5
        public async Task<ActionResult> Details(int? id , int? cid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SubCategory t_SubCategory = await db.T_SubCategory.FindAsync(id);
            T_Category t_Category = await db.T_Category.FindAsync(cid);
            ViewData["CategoryName"] = t_Category.CategoryName;
            if (t_SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(t_SubCategory);
        }

        // GET: T_SubCategory/Create
        public ActionResult Create()
        {


            ViewBag.CategoryList = new SelectList(db.T_Category.ToList(), "CategoryID", "CategoryName");

            return View();
        }
      
        // POST: T_SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName,IsRemoved,IUser,EUser,IDate,EDate")] T_SubCategory t_SubCategory)
        {
            if (ModelState.IsValid)
            {


                db.T_SubCategory.Add(t_SubCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_SubCategory);
        }


      
        // GET: T_SubCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SubCategory t_SubCategory = await db.T_SubCategory.FindAsync(id);
            if (t_SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(t_SubCategory);
        }

        // POST: T_SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName,IsRemoved,IUser,EUser,IDate,EDate")] T_SubCategory t_SubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SubCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_SubCategory);
        }

        // GET: T_SubCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SubCategory t_SubCategory = await db.T_SubCategory.FindAsync(id);
            if (t_SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(t_SubCategory);
        }

        // POST: T_SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_SubCategory t_SubCategory = await db.T_SubCategory.FindAsync(id);
            db.T_SubCategory.Remove(t_SubCategory);
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
