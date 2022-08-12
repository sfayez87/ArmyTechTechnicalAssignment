using AccountSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountSystem.ViewModels
{
    public class InvoiceVM
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}