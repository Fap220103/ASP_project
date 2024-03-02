namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public virtual tb_Orders tb_Orders { get; set; }

        public virtual tb_Product tb_Product { get; set; }
    }
}
