namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Feedbacks
    {
        [Key]
        public int FeedbackID { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "ntext")]
        public string FeedbackText { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FeedbackDate { get; set; }

        public virtual tb_Customers tb_Customers { get; set; }
    }
}
