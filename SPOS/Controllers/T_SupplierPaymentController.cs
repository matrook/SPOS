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
    public class T_SupplierPaymentController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_SupplierPayment
        public async Task<ActionResult> Index()
        {
            return View(await db.T_SupplierPayment.ToListAsync());
        }

        // GET: T_SupplierPayment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SupplierPayment t_SupplierPayment = await db.T_SupplierPayment.FindAsync(id);
            if (t_SupplierPayment == null)
            {
                return HttpNotFound();
            }
            return View(t_SupplierPayment);
        }

        // GET: T_SupplierPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_SupplierPayment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SPId,SupplierId,TrnDate,ReceivedAmount,TrnType,Due,SPDescription,Post,IUser,EUser,IDate,EDate,BrId")] T_SupplierPayment t_SupplierPayment)
        {
            if (ModelState.IsValid)
            {
                db.T_SupplierPayment.Add(t_SupplierPayment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_SupplierPayment);
        }

        // GET: T_SupplierPayment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SupplierPayment t_SupplierPayment = await db.T_SupplierPayment.FindAsync(id);
            if (t_SupplierPayment == null)
            {
                return HttpNotFound();
            }
            return View(t_SupplierPayment);
        }

        // POST: T_SupplierPayment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SPId,SupplierId,TrnDate,ReceivedAmount,TrnType,Due,SPDescription,Post,IUser,EUser,IDate,EDate,BrId")] T_SupplierPayment t_SupplierPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SupplierPayment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_SupplierPayment);
        }

        // GET: T_SupplierPayment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SupplierPayment t_SupplierPayment = await db.T_SupplierPayment.FindAsync(id);
            if (t_SupplierPayment == null)
            {
                return HttpNotFound();
            }
            return View(t_SupplierPayment);
        }

        // POST: T_SupplierPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_SupplierPayment t_SupplierPayment = await db.T_SupplierPayment.FindAsync(id);
            db.T_SupplierPayment.Remove(t_SupplierPayment);
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
