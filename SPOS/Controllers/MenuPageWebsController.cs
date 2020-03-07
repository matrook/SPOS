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
    public class MenuPageWebsController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: MenuPageWebs
        public async Task<ActionResult> Index()
        {
            return View(await db.MenuPageWebs.ToListAsync());
        }

        // GET: MenuPageWebs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPageWeb menuPageWeb = await db.MenuPageWebs.FindAsync(id);
            if (menuPageWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPageWeb);
        }

        // GET: MenuPageWebs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuPageWebs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PageId,SubMenuHeadID,MenuHeadID,PageName,URL,CreateDate,LastUpdateDate,IsRemoved,PageTitle,LiID")] MenuPageWeb menuPageWeb)
        {
            if (ModelState.IsValid)
            {
                db.MenuPageWebs.Add(menuPageWeb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(menuPageWeb);
        }

        // GET: MenuPageWebs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPageWeb menuPageWeb = await db.MenuPageWebs.FindAsync(id);
            if (menuPageWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPageWeb);
        }

        // POST: MenuPageWebs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PageId,SubMenuHeadID,MenuHeadID,PageName,URL,CreateDate,LastUpdateDate,IsRemoved,PageTitle,LiID")] MenuPageWeb menuPageWeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuPageWeb).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menuPageWeb);
        }

        // GET: MenuPageWebs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPageWeb menuPageWeb = await db.MenuPageWebs.FindAsync(id);
            if (menuPageWeb == null)
            {
                return HttpNotFound();
            }
            return View(menuPageWeb);
        }

        // POST: MenuPageWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuPageWeb menuPageWeb = await db.MenuPageWebs.FindAsync(id);
            db.MenuPageWebs.Remove(menuPageWeb);
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
