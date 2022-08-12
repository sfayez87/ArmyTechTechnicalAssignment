namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceHeader")]
    public partial class InvoiceHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceHeader()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerName { get; set; }

        public DateTime Invoicedate { get; set; }

        public int? CashierID { get; set; }

        public int BranchID { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Cashier Cashier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
