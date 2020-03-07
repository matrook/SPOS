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
    public class MenuPermissionWebsController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: MenuPermissionWebs
        public async Task<ActionResult> Index()
        {
            return View(await db.MenuPermissionWebs.ToListAsync());
        }

        // GET: MenuPermissionWebs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermissionWeb menuPermissionWeb = await db.MenuPermissionWebs.FindAsync(id);
            if (menuPermissionWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPermissionWeb);
        }

        // GET: MenuPermissionWebs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuPermissionWebs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GrantID,BrId,UserID,MenuHeadID,SubMenuHeadID,PageID,CanView")] MenuPermissionWeb menuPermissionWeb)
        {
            if (ModelState.IsValid)
            {
                db.MenuPermissionWebs.Add(menuPermissionWeb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(menuPermissionWeb);
        }

        // GET: MenuPermissionWebs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermissionWeb menuPermissionWeb = await db.MenuPermissionWebs.FindAsync(id);
            if (menuPermissionWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPermissionWeb);
        }

        // POST: MenuPermissionWebs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GrantID,BrId,UserID,MenuHeadID,SubMenuHeadID,PageID,CanView")] MenuPermissionWeb menuPermissionWeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuPermissionWeb).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menuPermissionWeb);
        }

        // GET: MenuPermissionWebs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermissionWeb menuPermissionWeb = await db.MenuPermissionWebs.FindAsync(id);
            if (menuPermissionWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPermissionWeb);
        }

        // POST: MenuPermissionWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuPermissionWeb menuPermissionWeb = await db.MenuPermissionWebs.FindAsync(id);
            db.MenuPermissionWebs.Remove(menuPermissionWeb);
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
