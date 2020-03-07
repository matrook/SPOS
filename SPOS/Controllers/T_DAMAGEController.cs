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
    public class T_DAMAGEController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_DAMAGE
        public async Task<ActionResult> Index()
        {
            return View(await db.T_DAMAGE.ToListAsync());
        }

        // GET: T_DAMAGE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_DAMAGE t_DAMAGE = await db.T_DAMAGE.FindAsync(id);
            if (t_DAMAGE == null)
            {
                return HttpNotFound();
            }
            return View(t_DAMAGE);
        }

        // GET: T_DAMAGE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_DAMAGE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DamageId,CategoryID,SubCategoryID,ProductID,LotNo,UnitId,Qty,Remarks,IsRemoved,IUSER,EUSER,IDAT,EDAT,BrId")] T_DAMAGE t_DAMAGE)
        {
            if (ModelState.IsValid)
            {
                db.T_DAMAGE.Add(t_DAMAGE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_DAMAGE);
        }

        // GET: T_DAMAGE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_DAMAGE t_DAMAGE = await db.T_DAMAGE.FindAsync(id);
            if (t_DAMAGE == null)
            {
                return HttpNotFound();
            }
            return View(t_DAMAGE);
        }

        // POST: T_DAMAGE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DamageId,CategoryID,SubCategoryID,ProductID,LotNo,UnitId,Qty,Remarks,IsRemoved,IUSER,EUSER,IDAT,EDAT,BrId")] T_DAMAGE t_DAMAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_DAMAGE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_DAMAGE);
        }

        // GET: T_DAMAGE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_DAMAGE t_DAMAGE = await db.T_DAMAGE.FindAsync(id);
            if (t_DAMAGE == null)
            {
                return HttpNotFound();
            }
            return View(t_DAMAGE);
        }

        // POST: T_DAMAGE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_DAMAGE t_DAMAGE = await db.T_DAMAGE.FindAsync(id);
            db.T_DAMAGE.Remove(t_DAMAGE);
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
