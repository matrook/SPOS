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
    public class MenuHeadWebsController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: MenuHeadWebs
        public async Task<ActionResult> Index()
        {
            return View(await db.MenuHeadWebs.ToListAsync());
        }

        // GET: MenuHeadWebs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHeadWeb menuHeadWeb = await db.MenuHeadWebs.FindAsync(id);
            if (menuHeadWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuHeadWeb);
        }

        // GET: MenuHeadWebs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuHeadWebs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MenuHeadWebID,MenuHeadWebName,Priority,DivID")] MenuHeadWeb menuHeadWeb)
        {
            if (ModelState.IsValid)
            {
                db.MenuHeadWebs.Add(menuHeadWeb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(menuHeadWeb);
        }

        // GET: MenuHeadWebs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHeadWeb menuHeadWeb = await db.MenuHeadWebs.FindAsync(id);
            if (menuHeadWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuHeadWeb);
        }

        // POST: MenuHeadWebs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MenuHeadWebID,MenuHeadWebName,Priority,DivID")] MenuHeadWeb menuHeadWeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuHeadWeb).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menuHeadWeb);
        }

        // GET: MenuHeadWebs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHeadWeb menuHeadWeb = await db.MenuHeadWebs.FindAsync(id);
            if (menuHeadWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuHeadWeb);
        }

        // POST: MenuHeadWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuHeadWeb menuHeadWeb = await db.MenuHeadWebs.FindAsync(id);
            db.MenuHeadWebs.Remove(menuHeadWeb);
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
