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
    public class T_SALES_DTLController : Controller
    {
        private SPOSEntities db = new SPOSEntities();

        // GET: T_SALES_DTL
        public async Task<ActionResult> Index(string id)
        {

            
            return View(await db.T_SALES_DTL.ToListAsync());
        }

        // GET: T_SALES_DTL/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_DTL t_SALES_DTL = await db.T_SALES_DTL.FindAsync(id);
            if (t_SALES_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_DTL);
        }

        // GET: T_SALES_DTL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_SALES_DTL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create([Bind(Include = "SlNo,InvoiceNo,SalesDate,SType,SubTotal,Vat,GrossAmount,Discount,DiscountTk,ReceiveAmount,DueCollection,CashPaid,CashChange,CustomerID,NetAmount,CustName,CustAddress,CustPhone,Description,IUSER,EUSER,IDAT,EDAT,BrId")] ViewModel viewModel,Sales sales, string barcode)

        {


            using (SPOSEntities db = new SPOSEntities())
            {

                barcode = sales.Products.PBarcode.ToString();

                SPOSEntities entities = new SPOSEntities();
                List<T_PROD> cprod = db.T_PROD.ToList();
                List<T_GRN_DTL> cgrn_dtl = db.T_GRN_DTL.ToList();
                List<T_GRN_MST> cgrn_mst = db.T_GRN_MST.ToList();

                var subcategory = (from s in cgrn_dtl
                                   join c in cgrn_mst on s.BrId equals c.BrId into table1
                                   from c in table1.ToList()

                                   join p in cprod on s.BrId equals p.ProductID into table2
                                   from p in table2.ToList()
                                   where p.PBarcode == barcode
                                   select new Sales
                                   {
                                       SReceiveIdDTL = s,
                                       ReceiveDetailIdMST = c,
                                       Products = p
                                   }).OrderBy(x => x.Products.ProductID);

                ViewBag.Message = subcategory;

                return View();

            }
            //if (ModelState.IsValid && PBarcode.HasValue)
            //{
            //    viewModel.Products.CategoryID = categoryID.Value;
            //    viewModel.Products.SubCategoryID = SubCategoryID.Value;
            //    db.T_PROD.Add(viewModel.Products);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            //return View(model);
        }

        // GET: T_SALES_DTL/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_DTL t_SALES_DTL = await db.T_SALES_DTL.FindAsync(id);
            if (t_SALES_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_DTL);
        }

        // POST: T_SALES_DTL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SlNo,InvoiceNo,ProductID,LotNo,SalePrice,SaleQty,DisAomuntPerItems,ReturnQty,CostPrice,ReferenceInvoice,BrId")] T_SALES_DTL t_SALES_DTL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SALES_DTL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_SALES_DTL);
        }

        // GET: T_SALES_DTL/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SALES_DTL t_SALES_DTL = await db.T_SALES_DTL.FindAsync(id);
            if (t_SALES_DTL == null)
            {
                return HttpNotFound();
            }
            return View(t_SALES_DTL);
        }

        // POST: T_SALES_DTL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_SALES_DTL t_SALES_DTL = await db.T_SALES_DTL.FindAsync(id);
            db.T_SALES_DTL.Remove(t_SALES_DTL);
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
