using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountSystem.Models;

namespace AccountSystem.Controllers
{
    public class InvoiceHeadersController : Controller
    {
        private AccountModel db = new AccountModel();

        // GET: InvoiceHeaders
        public ActionResult Index()
        {
            var invoiceHeaders = db.InvoiceHeaders.Include(i => i.Branch).Include(i => i.Cashier);
            return View(invoiceHeaders.ToList());
        }

        // GET: InvoiceHeaders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName");
            ViewBag.CashierID = new SelectList(db.Cashiers, "ID", "CashierName");
            return View();
        }

        // POST: InvoiceHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,Invoicedate,CashierID,BranchID")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceHeaders.Add(invoiceHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", invoiceHeader.BranchID);
            ViewBag.CashierID = new SelectList(db.Cashiers, "ID", "CashierName", invoiceHeader.CashierID);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", invoiceHeader.BranchID);
            ViewBag.CashierID = new SelectList(db.Cashiers, "ID", "CashierName", invoiceHeader.CashierID);
            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,Invoicedate,CashierID,BranchID")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "BranchName", invoiceHeader.BranchID);
            ViewBag.CashierID = new SelectList(db.Cashiers, "ID", "CashierName", invoiceHeader.CashierID);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            InvoiceHeader invoiceHeader = db.InvoiceHeaders.Find(id);
            db.InvoiceHeaders.Remove(invoiceHeader);
            db.SaveChanges();
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
