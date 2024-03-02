namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Staff()
        {
            tb_Invoice = new HashSet<tb_Invoice>();
        }

        [Key]
        public int StaffID { get; set; }

        [StringLength(100)]
        public string StaffName { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Invoice> tb_Invoice { get; set; }
    }
}
