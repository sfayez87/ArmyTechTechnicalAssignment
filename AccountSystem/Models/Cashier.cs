namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cashier")]
    public partial class Cashier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cashier()
        {
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string CashierName { get; set; }

        public int BranchID { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
