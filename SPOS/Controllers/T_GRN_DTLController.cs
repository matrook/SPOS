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
    public class T_GRN_DTLController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_GRN_DTL
        public async Task<ActionResult> Index()
        {
            return View(await db.T_GRN_DTL.ToListAsync());
        }

        // GET: T_GRN_DTL/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_DTL t_GRN_DTL = await db.T_GRN_DTL.FindAsync(id);
            if (t_GRN_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_DTL);
        }

        // GET: T_GRN_DTL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_GRN_DTL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReceiveDetailId,ReceiveId,CategoryID,SubCategoryID,ProductID,LotNo,UnitId,Qty,CostPrice,ReturnQty,SalePrice,BrId")] T_GRN_DTL t_GRN_DTL)
        {
            if (ModelState.IsValid)
            {
                db.T_GRN_DTL.Add(t_GRN_DTL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_GRN_DTL);
        }

        // GET: T_GRN_DTL/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_DTL t_GRN_DTL = await db.T_GRN_DTL.FindAsync(id);
            if (t_GRN_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_DTL);
        }

        // POST: T_GRN_DTL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReceiveDetailId,ReceiveId,CategoryID,SubCategoryID,ProductID,LotNo,UnitId,Qty,CostPrice,ReturnQty,SalePrice,BrId")] T_GRN_DTL t_GRN_DTL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_GRN_DTL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_GRN_DTL);
        }

        // GET: T_GRN_DTL/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_GRN_DTL t_GRN_DTL = await db.T_GRN_DTL.FindAsync(id);
            if (t_GRN_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_GRN_DTL);
        }

        // POST: T_GRN_DTL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_GRN_DTL t_GRN_DTL = await db.T_GRN_DTL.FindAsync(id);
            db.T_GRN_DTL.Remove(t_GRN_DTL);
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
