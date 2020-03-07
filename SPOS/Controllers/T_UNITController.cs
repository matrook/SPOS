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
    public class T_UNITController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_UNIT
        public async Task<ActionResult> Index()
        {
            return View(await db.T_UNIT.ToListAsync());
        }

        // GET: T_UNIT/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_UNIT t_UNIT = await db.T_UNIT.FindAsync(id);
            if (t_UNIT == null)
            {
                return HttpNotFound();
            }
            return View(t_UNIT);
        }

        // GET: T_UNIT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_UNIT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UnitID,UnitName,IsRemoved,IUser,EUser,IDate,EDate")] T_UNIT t_UNIT)
        {
            if (ModelState.IsValid)
            {
                db.T_UNIT.Add(t_UNIT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_UNIT);
        }

        // GET: T_UNIT/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_UNIT t_UNIT = await db.T_UNIT.FindAsync(id);
            if (t_UNIT == null)
            {
                return HttpNotFound();
            }
            return View(t_UNIT);
        }

        // POST: T_UNIT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UnitID,UnitName,IsRemoved,IUser,EUser,IDate,EDate")] T_UNIT t_UNIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_UNIT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_UNIT);
        }

        // GET: T_UNIT/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_UNIT t_UNIT = await db.T_UNIT.FindAsync(id);
            if (t_UNIT == null)
            {
                return HttpNotFound();
            }
            return View(t_UNIT);
        }

        // POST: T_UNIT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_UNIT t_UNIT = await db.T_UNIT.FindAsync(id);
            db.T_UNIT.Remove(t_UNIT);
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
