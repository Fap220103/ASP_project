namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Reviews
    {
        [Key]
        public int ReviewID { get; set; }

        public int? ProductID { get; set; }

        public int? CustomerID { get; set; }

        public int? Rating { get; set; }

        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        public DateTime? ReviewDate { get; set; }

        public virtual tb_Customers tb_Customers { get; set; }

        public virtual tb_Product tb_Product { get; set; }
    }
}
