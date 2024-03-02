namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Orders()
        {
            tb_Invoice = new HashSet<tb_Invoice>();
            tb_OrderDetail = new HashSet<tb_OrderDetail>();
        }

        [Key]
        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public bool? Status { get; set; }

        public bool? Delivered { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int? CustomerID { get; set; }

        public int? Discount { get; set; }

        public virtual tb_Customers tb_Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Invoice> tb_Invoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_OrderDetail> tb_OrderDetail { get; set; }
    }
}
