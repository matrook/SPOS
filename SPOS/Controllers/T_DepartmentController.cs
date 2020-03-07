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
    public class T_DepartmentController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_Department
        public async Task<ActionResult> Index()
        {
            return View(await db.T_Department.ToListAsync());
        }

        // GET: T_Department/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Department t_Department = await db.T_Department.FindAsync(id);
            if (t_Department == null)
            {
                return HttpNotFound();
            }
            return View(t_Department);
        }

        // GET: T_Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DeptId,DeptName")] T_Department t_Department)
        {
            if (ModelState.IsValid)
            {
                db.T_Department.Add(t_Department);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_Department);
        }

        // GET: T_Department/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Department t_Department = await db.T_Department.FindAsync(id);
            if (t_Department == null)
            {
                return HttpNotFound();
            }
            return View(t_Department);
        }

        // POST: T_Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DeptId,DeptName")] T_Department t_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Department).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_Department);
        }

        // GET: T_Department/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Department t_Department = await db.T_Department.FindAsync(id);
            if (t_Department == null)
            {
                return HttpNotFound();
            }
            return View(t_Department);
        }

        // POST: T_Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_Department t_Department = await db.T_Department.FindAsync(id);
            db.T_Department.Remove(t_Department);
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
