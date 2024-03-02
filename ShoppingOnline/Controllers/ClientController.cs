using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class ClientController : Controller
    {
        
        ShoppingOnlineDB db = new ShoppingOnlineDB();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string tendn)
        {
            // Kiểm tra nếu có tên đăng nhập được truyền từ Redirect
            if (!String.IsNullOrEmpty(tendn))
            {
                ViewBag.LastUsername = tendn;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var tendn = f["TenDN"];
            var mk = f["Matkhau"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewBag.ErrorMessage1 = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewBag.LastUsername = tendn;
                ViewBag.ErrorMessage2 = "Phải nhập mật khẩu";
            }
            else
            {
                tb_Customers cus = db.tb_Customers.SingleOrDefault(p => p.Account == tendn && p.Password == mk);
                if (cus != null)
                {
                    Session["CustomerID"] = cus.CustomerID;
                    return RedirectToAction("MainInterface");
                }
                else
                {
                    ViewBag.LastUsername = tendn;
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["CustomerID"] = null;
            return RedirectToAction("MainInterface","Client");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            var name = f["name"];
            var email = f["email"];
            var pass = f["pass"];
            var re_pass = f["re_pass"];
            tb_Customers new_cus = new tb_Customers();
            new_cus.Name = name;
            new_cus.Account = name;
            new_cus.Email = email;
            new_cus.Password = pass;
            db.tb_Customers.Add(new_cus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<tb_Product> LaySPMoi(int count)
        {
            return db.tb_Product.OrderByDescending(p=>p.CreatedDate).Take(count).ToList();
        }
        public ActionResult MainInterface()
        {
            var products = LaySPMoi(6);
            return View(products);
        }
        public List<tb_Product> GetRelatedProducts()
        {
            var products = LaySPMoi(6);
            return products;
        }
        [HttpGet]
        public ActionResult ProductDetail(int productId)
        {
            var product = db.tb_Product.First(p => p.ProductID == productId);
            var relatedProducts = GetRelatedProducts();
            ViewBag.RelatedProducts = relatedProducts;
            ViewBag.customerID = Session["CustomerID"];
            if (product == null)
            {
                // Xử lý khi không tìm thấy sản phẩm
                return HttpNotFound(); // hoặc return RedirectToAction("NotFound");
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            if (Session["CustomerID"]==null)
            {
                return RedirectToAction("Login", "Client");
            }
            else
            {
                ViewBag.CustomerID = Session["CustomerID"];
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult Contact(int customerID,FormCollection f)
        {
            try
            {
                tb_Contact contact = new tb_Contact();
                contact.CustomerID = customerID;
                contact.Name = f["txtName"];
                contact.Email = f["txtEmail"];
                contact.Message = f["txtMessage"];
                contact.CreatedDate = DateTime.Now;
                db.tb_Contact.Add(contact);
                db.SaveChanges();
                ViewBag.Thongbao = "Chúng tôi sẽ sớm liên hệ lại với bạn";
                return View();
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            
            
        }
        [HttpPost]
        public ActionResult FeedBack(int customerID,int productId)
        {
            try
            {
                var text = Request["txtFeedback"];
                tb_Feedbacks feedback = new tb_Feedbacks();
                feedback.CustomerID = customerID;
                feedback.FeedbackText = text;
                db.tb_Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("ProductDetail", productId);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");

            }

        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult CategoryMenu()
        {
            var list = db.tb_Categories.Take(4).ToList();
            return PartialView(list);
        }
        [Route("SanPhamTheoCate/{CatelogyID}")]
        public ActionResult HienThiSPTheoCate(int CatelogyID)
        {
            var sp = db.tb_Product.Where(p=>p.CategoryID == CatelogyID).ToList();
            return View(sp);
        }
        [HttpGet]
        public ActionResult MyAccount(int userID)
        {
            var myAccount = db.tb_Customers.FirstOrDefault(p=>p.CustomerID == userID);
            return View(myAccount);
        }
        [HttpPost]
        public ActionResult MyAccount(int userID,FormCollection f)
        {
            
            string name = f["txtName"];
            string account = f["txtAccount"];
            string email = f["txtEmail"];
            string address = f["txtAddress"];
            string phone = f["txtPhone"];
            DateTime birthday = Convert.ToDateTime(f["txtBirthday"]);
            string image = f["image"];
            
            var user = db.tb_Customers.FirstOrDefault(p=> p.CustomerID == userID);

            user.Name = name;
            user.Account = account;
            user.Email = email;
            user.Address = address;
            user.Phone = phone;
            user.Birthday = birthday;
            user.Image = image;
            db.SaveChanges();
            return this.MyAccount(userID);
        }
        [HttpGet]
        public ActionResult ChangePass(int userID)
        {
            var myAccount = db.tb_Customers.FirstOrDefault(p => p.CustomerID == userID);
            return View(myAccount);
        }
        [HttpPost]
        public ActionResult ChangePass(int userID,FormCollection f)
        {
            var oldPass = f["OldPass"];
            var newPass = f["NewPass"];
            var confirmPass = f["ConfirmPass"];
            var myAccount = db.tb_Customers.FirstOrDefault(p => p.CustomerID == userID);
            if(myAccount.Password == oldPass)
            {
                if(newPass == confirmPass)
                {
                    myAccount.Password = newPass;
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Error = "Mật khẩu và nhập lại mật khẩu không trùng!! Mời nhập lại";
                }
            }
            else
            {
                ViewBag.Success = "Mật khẩu cũ không chính xác";
            }
            return View(userID);
        }
    }
}