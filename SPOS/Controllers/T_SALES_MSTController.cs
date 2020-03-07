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
    public class T_SALES_MSTController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_SALES_MST
        public async Task<ActionResult> Index()
        {
            return View(await db.T_SALES_MST.ToListAsync());
        }

        // GET: T_SALES_MST/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_MST t_SALES_MST = await db.T_SALES_MST.FindAsync(id);
            if (t_SALES_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_MST);
        }

        // GET: T_SALES_MST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_SALES_MST/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SlNo,InvoiceNo,SalesDate,SType,SubTotal,Vat,GrossAmount,Discount,DiscountTk,ReceiveAmount,DueCollection,CashPaid,CashChange,CustomerID,NetAmount,CustName,CustAddress,CustPhone,Description,IUSER,EUSER,IDAT,EDAT,BrId")] T_SALES_MST t_SALES_MST)
        {
            if (ModelState.IsValid)
            {
                db.T_SALES_MST.Add(t_SALES_MST);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_SALES_MST);
        }

        // GET: T_SALES_MST/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_MST t_SALES_MST = await db.T_SALES_MST.FindAsync(id);
            if (t_SALES_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_MST);
        }

        // POST: T_SALES_MST/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SlNo,InvoiceNo,SalesDate,SType,SubTotal,Vat,GrossAmount,Discount,DiscountTk,ReceiveAmount,DueCollection,CashPaid,CashChange,CustomerID,NetAmount,CustName,CustAddress,CustPhone,Description,IUSER,EUSER,IDAT,EDAT,BrId")] T_SALES_MST t_SALES_MST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SALES_MST).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_SALES_MST);
        }

        // GET: T_SALES_MST/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_MST t_SALES_MST = await db.T_SALES_MST.FindAsync(id);
            if (t_SALES_MST == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_MST);
        }

        // POST: T_SALES_MST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_SALES_MST t_SALES_MST = await db.T_SALES_MST.FindAsync(id);
            db.T_SALES_MST.Remove(t_SALES_MST);
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
