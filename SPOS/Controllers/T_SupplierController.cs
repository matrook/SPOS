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
    public class T_SupplierController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_Supplier
        public async Task<ActionResult> Index()
        {
            return View(await db.T_Supplier.ToListAsync());
        }

        // GET: T_Supplier/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Supplier t_Supplier = await db.T_Supplier.FindAsync(id);
            if (t_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(t_Supplier);
        }

        // GET: T_Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SupplierID,SupplierName,Address,PhoneNo,Balance,IsRemoved,IUser,EUser,IDate,EDate")] T_Supplier t_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.T_Supplier.Add(t_Supplier);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_Supplier);
        }

        // GET: T_Supplier/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Supplier t_Supplier = await db.T_Supplier.FindAsync(id);
            if (t_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(t_Supplier);
        }

        // POST: T_Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SupplierID,SupplierName,Address,PhoneNo,Balance,IsRemoved,IUser,EUser,IDate,EDate")] T_Supplier t_Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Supplier).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_Supplier);
        }

        // GET: T_Supplier/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Supplier t_Supplier = await db.T_Supplier.FindAsync(id);
            if (t_Supplier == null)
            {
                return HttpNotFound();
            }
            return View(t_Supplier);
        }

        // POST: T_Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_Supplier t_Supplier = await db.T_Supplier.FindAsync(id);
            db.T_Supplier.Remove(t_Supplier);
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
