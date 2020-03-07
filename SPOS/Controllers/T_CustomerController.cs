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
    public class T_CustomerController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_Customer
        public async Task<ActionResult> Index()
        {
            return View(await db.T_Customer.ToListAsync());
        }

        // GET: T_Customer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Customer t_Customer = await db.T_Customer.FindAsync(id);
            if (t_Customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Customer);
        }

        // GET: T_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerID,DeptId,Name,Address,Phone,DueAdvance,IsRemoved,IUser,EUser,IDate,EDate,DueLimit,BrId")] T_Customer t_Customer)
        {
            if (ModelState.IsValid)
            {
                db.T_Customer.Add(t_Customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_Customer);
        }

        // GET: T_Customer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Customer t_Customer = await db.T_Customer.FindAsync(id);
            if (t_Customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Customer);
        }

        // POST: T_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerID,DeptId,Name,Address,Phone,DueAdvance,IsRemoved,IUser,EUser,IDate,EDate,DueLimit,BrId")] T_Customer t_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_Customer);
        }

        // GET: T_Customer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Customer t_Customer = await db.T_Customer.FindAsync(id);
            if (t_Customer == null)
            {
                return HttpNotFound();
            }
            return View(t_Customer);
        }

        // POST: T_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_Customer t_Customer = await db.T_Customer.FindAsync(id);
            db.T_Customer.Remove(t_Customer);
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
