using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class CartController : Controller
    {
        ShoppingOnlineDB db = new ShoppingOnlineDB();
        // GET: Cart
        public List<Cart> GetCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if(lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        public ActionResult AddCart(int productID,string strURL)
        {
            List<Cart> lstCart = GetCart();
            Cart product = lstCart.Find(n=>n.ProductID == productID);
            if(product == null)
            {
                product = new Cart(productID);
                lstCart.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.Quantity++;
                return Redirect(strURL);
            }
        }
        private int TotalQuantity()
        {
            int totalQuantity = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if(lstCart != null)
            {
                totalQuantity = lstCart.Sum(n=>n.Quantity);
            }
            return totalQuantity;
        }
        private decimal TotalPrice()
        {
            decimal TotalPrice = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                TotalPrice = lstCart.Sum(n => n.TotalPrice);
            }
            return TotalPrice;
        }
        public ActionResult Cart()
        {
            List<Cart> lstCart = GetCart();
            ViewBag.Count = lstCart.Count;
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return View(lstCart);
        }
        //Delete Cart
        public ActionResult DeleteCart(int productID)
        {
            List<Cart> lstCart = GetCart();
            Cart product = lstCart.SingleOrDefault(n=>n.ProductID == productID);
            if(product != null)
            {
                lstCart.RemoveAll(n=>n.ProductID==productID);
                return RedirectToAction("Cart");
            }
            if(lstCart.Count ==0)
            {
                return RedirectToAction("MainInterface", "Client");
            }
            return RedirectToAction("Cart");
        }
        //Update Cart
        public ActionResult UpdateCart(int productID,FormCollection f)
        {
            List<Cart> lstCart = GetCart();
            Cart cart = lstCart.SingleOrDefault(n => n.ProductID == productID);
            if(cart != null)
            {
                cart.Quantity = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Cart");
        }
    }
}