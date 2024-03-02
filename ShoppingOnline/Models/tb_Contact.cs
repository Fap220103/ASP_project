using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingOnline.Models
{
    public partial class tb_Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Message { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CustomerID { get; set; }

        public virtual tb_Customers tb_Customers { get; set; }
    }
}