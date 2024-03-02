using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShoppingOnline.Models
{
    public partial class ShoppingOnlineDB : DbContext
    {
        public ShoppingOnlineDB()
            : base("name=ShoppingOnlineDB")
        {
        }

        public virtual DbSet<tb_Brand> tb_Brand { get; set; }
        public virtual DbSet<tb_Categories> tb_Categories { get; set; }
        public virtual DbSet<tb_Contact> tb_Contact { get; set; }
        public virtual DbSet<tb_Customers> tb_Customers { get; set; }
        public virtual DbSet<tb_Feedbacks> tb_Feedbacks { get; set; }
        public virtual DbSet<tb_Invoice> tb_Invoice { get; set; }
        public virtual DbSet<tb_InvoiceDetail> tb_InvoiceDetail { get; set; }
        public virtual DbSet<tb_OrderDetail> tb_OrderDetail { get; set; }
        public virtual DbSet<tb_Orders> tb_Orders { get; set; }
        public virtual DbSet<tb_Product> tb_Product { get; set; }
        public virtual DbSet<tb_Reviews> tb_Reviews { get; set; }
        public virtual DbSet<tb_Staff> tb_Staff { get; set; }
        public virtual DbSet<tb_Supplier> tb_Supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Contact>()
                .Property(e => e.Message)
                .IsUnicode();
            modelBuilder.Entity<tb_Invoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tb_Invoice>()
                .HasMany(e => e.tb_InvoiceDetail)
                .WithRequired(e => e.tb_Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_InvoiceDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tb_InvoiceDetail>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tb_OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tb_Orders>()
                .HasMany(e => e.tb_OrderDetail)
                .WithRequired(e => e.tb_Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tb_Product>()
                .HasMany(e => e.tb_InvoiceDetail)
                .WithRequired(e => e.tb_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Product>()
                .HasMany(e => e.tb_OrderDetail)
                .WithRequired(e => e.tb_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Staff>()
                .Property(e => e.StaffName)
                .IsFixedLength();
        }
    }
}
