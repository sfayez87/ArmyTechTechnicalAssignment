using AccountSystem.Models;
using AccountSystem.Repositories;
using AccountSystem.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountSystem.Controllers
{
    public class AccountController : Controller
    {
        GenericRepository<InvoiceHeader> invoiceHRepo = new GenericRepository<InvoiceHeader>();
        GenericRepository<InvoiceDetail> invoiceDRepo = new GenericRepository<InvoiceDetail>();
        GenericRepository<Cashier> cashierRepo = new GenericRepository<Cashier>();
        GenericRepository<Branch> branchRepo = new GenericRepository<Branch>();
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View(invoiceHRepo.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult EditInvoice(long id)
        {
            var invoiceHeader = invoiceHRepo.Get(id);
            ViewBag.CashierID = new SelectList(cashierRepo.GetAll(), "ID", "CashierName",invoiceHeader.CashierID);
            ViewBag.BranchID = new SelectList(branchRepo.GetAll(), "ID", "BranchName",invoiceHeader.BranchID);
            InvoiceVM invoiceVM = new InvoiceVM();
            invoiceVM.InvoiceHeader = invoiceHeader;
            invoiceVM.InvoiceDetails = invoiceDRepo.GetAll().Where(i => i.InvoiceHeaderID == invoiceHeader.ID).ToList();
            return View(invoiceVM);
        }
        [HttpPost]
        public ActionResult EditInvoice(FormCollection collection,InvoiceVM invoiceVM)
        {
            var itemIdColl = collection.GetValues("item.ID");
            var itemNameColl = collection.GetValues("ItemName");
            var itemCountColl = collection.GetValues("ItemCount");
            var itemPriceColl = collection.GetValues("ItemPrice");

            if (ModelState.IsValid)
            {
                    invoiceHRepo.Edit(new InvoiceHeader
                    {
                        ID = invoiceVM.InvoiceHeader.ID,
                        CustomerName = invoiceVM.InvoiceHeader.CustomerName,
                        Invoicedate = invoiceVM.InvoiceHeader.Invoicedate,
                        CashierID = invoiceVM.InvoiceHeader.CashierID,
                        BranchID = invoiceVM.InvoiceHeader.BranchID
                    });
                    var invoiceDetails = invoiceDRepo.GetAll().Where(a=>a.InvoiceHeaderID==invoiceVM.InvoiceHeader.ID);
                    invoiceDRepo.DeleteRange(invoiceDetails);
                for (int i = 0; i < itemNameColl.Length; i++)
                {
                    //long id = Convert.ToInt64(itemIdColl[i]);
                    string itemName = itemNameColl[i].ToString();
                    double itemCount = Convert.ToDouble(itemCountColl[i]);
                    double itemPrice = Convert.ToDouble(itemPriceColl[i]);

                    invoiceDRepo.Add(new InvoiceDetail
                    {
                        //ID=id,
                        InvoiceHeaderID = invoiceVM.InvoiceHeader.ID,
                        ItemName = itemName,
                        ItemCount = itemCount,
                        ItemPrice = itemPrice
                    });
                }
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/EditInvoice.cshtml", invoiceVM);
        }
    }
}