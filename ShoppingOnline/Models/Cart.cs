using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingOnline.Models
{
    public class Cart
    {
        ShoppingOnlineDB db = new ShoppingOnlineDB();
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return Quantity * Price; } }
 
        public Cart(int productID) 
        {
            ProductID = productID;
            tb_Product product = db.tb_Product.Single(n=>n.ProductID == productID);
            ProductName = product.Name;
            ProductImage = product.Image;
            Price = Convert.ToDecimal(product.Price);
            Quantity = 1;
        }
    }
   
}