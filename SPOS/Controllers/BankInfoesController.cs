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
    public class BankInfoesController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: BankInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.BankInfoes.ToListAsync());
        }

        // GET: BankInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankInfo bankInfo = await db.BankInfoes.FindAsync(id);
            if (bankInfo == null)
            {
                return HttpNotFound();
            }
            return View(bankInfo);
        }

        // GET: BankInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BankId,BankAccName,BankAccNo,OpenDate,Balance,BrId")] BankInfo bankInfo)
        {
            if (ModelState.IsValid)
            {
                db.BankInfoes.Add(bankInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bankInfo);
        }

        // GET: BankInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankInfo bankInfo = await db.BankInfoes.FindAsync(id);
            if (bankInfo == null)
            {
                return HttpNotFound();
            }
            return View(bankInfo);
        }

        // POST: BankInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BankId,BankAccName,BankAccNo,OpenDate,Balance,BrId")] BankInfo bankInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bankInfo);
        }

        // GET: BankInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankInfo bankInfo = await db.BankInfoes.FindAsync(id);
            if (bankInfo == null)
            {
                return HttpNotFound();
            }
            return View(bankInfo);
        }

        // POST: BankInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BankInfo bankInfo = await db.BankInfoes.FindAsync(id);
            db.BankInfoes.Remove(bankInfo);
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
