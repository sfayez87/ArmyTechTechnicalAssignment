namespace AccountSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountModel : DbContext
    {
        public AccountModel()
            : base("name=AccountModel")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cashier> Cashiers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Cashiers)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.InvoiceHeaders)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Branches)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceHeader>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.InvoiceHeader)
                .WillCascadeOnDelete(false);
        }
    }
}
