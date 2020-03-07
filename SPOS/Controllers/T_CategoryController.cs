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
    public class T_CategoryController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_Category
        public async Task<ActionResult> Index()
        {
            return View(await db.T_Category.ToListAsync());
        }

        // GET: T_Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Category t_Category = await db.T_Category.FindAsync(id);
            if (t_Category == null)
            {
                return HttpNotFound();
            }
            return View(t_Category);
        }

        // GET: T_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryID,CategoryName,IsRemoved,IUser,EUser,IDate,EDate")] T_Category t_Category)
        {
            if (ModelState.IsValid)
            {
                db.T_Category.Add(t_Category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_Category);
        }

        // GET: T_Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Category t_Category = await db.T_Category.FindAsync(id);
            if (t_Category == null)
            {
                return HttpNotFound();
            }
            return View(t_Category);
        }

        // POST: T_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryID,CategoryName,IsRemoved,IUser,EUser,IDate,EDate")] T_Category t_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_Category);
        }

        // GET: T_Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Category t_Category = await db.T_Category.FindAsync(id);
            if (t_Category == null)
            {
                return HttpNotFound();
            }
            return View(t_Category);
        }

        // POST: T_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_Category t_Category = await db.T_Category.FindAsync(id);
            db.T_Category.Remove(t_Category);
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
