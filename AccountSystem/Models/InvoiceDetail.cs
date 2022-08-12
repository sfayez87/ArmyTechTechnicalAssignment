namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceDetail
    {
        public long ID { get; set; }

        public long InvoiceHeaderID { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        public double ItemCount { get; set; }

        public double ItemPrice { get; set; }

        public virtual InvoiceHeader InvoiceHeader { get; set; }
    }
}
