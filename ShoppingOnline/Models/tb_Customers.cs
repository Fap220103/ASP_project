namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Customers()
        {
            tb_Feedbacks = new HashSet<tb_Feedbacks>();
            tb_Orders = new HashSet<tb_Orders>();
            tb_Reviews = new HashSet<tb_Reviews>();
        }

        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? Birthday { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Feedbacks> tb_Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Orders> tb_Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reviews> tb_Reviews { get; set; }
    }
}
