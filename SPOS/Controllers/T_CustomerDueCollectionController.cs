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
    public class T_CustomerDueCollectionController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_CustomerDueCollection
        public async Task<ActionResult> Index()
        {
            return View(await db.T_CustomerDueCollection.ToListAsync());
        }

        // GET: T_CustomerDueCollection/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CustomerDueCollection t_CustomerDueCollection = await db.T_CustomerDueCollection.FindAsync(id);
            if (t_CustomerDueCollection == null)
            {
                return HttpNotFound();
            }
            return View(t_CustomerDueCollection);
        }

        // GET: T_CustomerDueCollection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_CustomerDueCollection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustDueCollectionID,BrId,CustomerID,ReceiveAmount,CRDate,IsRemoved,IUser,EUser,IDate,EDate")] T_CustomerDueCollection t_CustomerDueCollection)
        {
            if (ModelState.IsValid)
            {
                db.T_CustomerDueCollection.Add(t_CustomerDueCollection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_CustomerDueCollection);
        }

        // GET: T_CustomerDueCollection/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CustomerDueCollection t_CustomerDueCollection = await db.T_CustomerDueCollection.FindAsync(id);
            if (t_CustomerDueCollection == null)
            {
                return HttpNotFound();
            }
            return View(t_CustomerDueCollection);
        }

        // POST: T_CustomerDueCollection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustDueCollectionID,BrId,CustomerID,ReceiveAmount,CRDate,IsRemoved,IUser,EUser,IDate,EDate")] T_CustomerDueCollection t_CustomerDueCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_CustomerDueCollection).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_CustomerDueCollection);
        }

        // GET: T_CustomerDueCollection/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CustomerDueCollection t_CustomerDueCollection = await db.T_CustomerDueCollection.FindAsync(id);
            if (t_CustomerDueCollection == null)
            {
                return HttpNotFound();
            }
            return View(t_CustomerDueCollection);
        }

        // POST: T_CustomerDueCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_CustomerDueCollection t_CustomerDueCollection = await db.T_CustomerDueCollection.FindAsync(id);
            db.T_CustomerDueCollection.Remove(t_CustomerDueCollection);
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
