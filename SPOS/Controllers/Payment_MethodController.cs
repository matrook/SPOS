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
    public class Payment_MethodController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: Payment_Method
        public async Task<ActionResult> Index()
        {
            return View(await db.Payment_Method.ToListAsync());
        }

        // GET: Payment_Method/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Method payment_Method = await db.Payment_Method.FindAsync(id);
            if (payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(payment_Method);
        }

        // GET: Payment_Method/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment_Method/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentMethod_ID,PaymentMethod_Name")] Payment_Method payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Payment_Method.Add(payment_Method);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(payment_Method);
        }

        // GET: Payment_Method/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Method payment_Method = await db.Payment_Method.FindAsync(id);
            if (payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(payment_Method);
        }

        // POST: Payment_Method/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaymentMethod_ID,PaymentMethod_Name")] Payment_Method payment_Method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_Method).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payment_Method);
        }

        // GET: Payment_Method/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Method payment_Method = await db.Payment_Method.FindAsync(id);
            if (payment_Method == null)
            {
                return HttpNotFound();
            }
            return View(payment_Method);
        }

        // POST: Payment_Method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment_Method payment_Method = await db.Payment_Method.FindAsync(id);
            db.Payment_Method.Remove(payment_Method);
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
