namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Product()
        {
            tb_InvoiceDetail = new HashSet<tb_InvoiceDetail>();
            tb_OrderDetail = new HashSet<tb_OrderDetail>();
            tb_Reviews = new HashSet<tb_Reviews>();
        }

        [Key]
        public int ProductID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string ListImages { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? Warranty { get; set; }

        public DateTime? Hot { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? ViewCount { get; set; }

        public int? BrandID { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual tb_Brand tb_Brand { get; set; }

        public virtual tb_Categories tb_Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_InvoiceDetail> tb_InvoiceDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_OrderDetail> tb_OrderDetail { get; set; }

        public virtual tb_Supplier tb_Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reviews> tb_Reviews { get; set; }
        
    }
}
