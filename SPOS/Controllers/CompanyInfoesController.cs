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
    public class CompanyInfoesController : Controller
    {
        private readonly SPOSEntities db = new SPOSEntities();

        // GET: CompanyInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.CompanyInfoes.ToListAsync());
        }

        // GET: CompanyInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = await db.CompanyInfoes.FindAsync(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CmpId,cmpName,BrId,BrName,cmpAddressLine1,cmpAddressLine2,ContactNo,Email,Web,OpenDate,TrnDate,FStartDate,FEndDate,CurrentDate,Logo,Vat,Vat_Area,Vat_RegiNo,Bill_Invoice_Print_Type")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.CompanyInfoes.Add(companyInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(companyInfo);
        }

        // GET: CompanyInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = await db.CompanyInfoes.FindAsync(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CmpId,cmpName,BrId,BrName,cmpAddressLine1,cmpAddressLine2,ContactNo,Email,Web,OpenDate,TrnDate,FStartDate,FEndDate,CurrentDate,Logo,Vat,Vat_Area,Vat_RegiNo,Bill_Invoice_Print_Type")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = await db.CompanyInfoes.FindAsync(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CompanyInfo companyInfo = await db.CompanyInfoes.FindAsync(id);
            db.CompanyInfoes.Remove(companyInfo);
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
