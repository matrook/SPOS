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
    public class T_GRN_MSTController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_GRN_MST
        public async Task<ActionResult> Index()
        {
            return View(await db.T_GRN_MST.ToListAsync());
        }

        // GET: T_GRN_MST/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_MST t_GRN_MST = await db.T_GRN_MST.FindAsync(id);
            if (t_GRN_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_MST);
        }

        // GET: T_GRN_MST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_GRN_MST/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReceiveId,ReceiveDate,ReceiveNo,InvoiceNo,SupplierID,ApprovedStatus,GrossAmount,Discount,CashPaid,DueAmount,Type,IsRemoved,IUSER,EUSER,IDAT,EDAT,BrId")] T_GRN_MST t_GRN_MST)
        {
            if (ModelState.IsValid)
            {
                db.T_GRN_MST.Add(t_GRN_MST);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_GRN_MST);
        }

        // GET: T_GRN_MST/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_MST t_GRN_MST = await db.T_GRN_MST.FindAsync(id);
            if (t_GRN_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_MST);
        }

        // POST: T_GRN_MST/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReceiveId,ReceiveDate,ReceiveNo,InvoiceNo,SupplierID,ApprovedStatus,GrossAmount,Discount,CashPaid,DueAmount,Type,IsRemoved,IUSER,EUSER,IDAT,EDAT,BrId")] T_GRN_MST t_GRN_MST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_GRN_MST).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_GRN_MST);
        }

        // GET: T_GRN_MST/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_MST t_GRN_MST = await db.T_GRN_MST.FindAsync(id);
            if (t_GRN_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_MST);
        }

        // POST: T_GRN_MST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_GRN_MST t_GRN_MST = await db.T_GRN_MST.FindAsync(id);
            db.T_GRN_MST.Remove(t_GRN_MST);
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
