namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Invoice()
        {
            tb_InvoiceDetail = new HashSet<tb_InvoiceDetail>();
        }

        [Key]
        public int InvoiceID { get; set; }

        public bool? Status { get; set; }

        public int? OrderID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? StaffID { get; set; }

        public virtual tb_Orders tb_Orders { get; set; }

        public virtual tb_Staff tb_Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_InvoiceDetail> tb_InvoiceDetail { get; set; }
    }
}
