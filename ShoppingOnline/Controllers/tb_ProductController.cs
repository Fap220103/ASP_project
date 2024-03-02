using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class tb_ProductController : Controller
    {
        private ShoppingOnlineDB db = new ShoppingOnlineDB();

        // GET: tb_Product
        public ActionResult Index()
        {
            var tb_Product = db.tb_Product.Include(t => t.tb_Brand).Include(t => t.tb_Categories).Include(t => t.tb_Supplier);
            return View(tb_Product.ToList());
        }

        // GET: tb_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // GET: tb_Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.tb_Brand, "BrandID", "BrandName");
            ViewBag.CategoryID = new SelectList(db.tb_Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.tb_Supplier, "SupplierID", "SupplierName");
            return View();
        }

        // POST: tb_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Image,ListImages,Price,Quantity,Warranty,Hot,Description,Detail,ViewCount,BrandID,SupplierID,CategoryID,CreatedDate")] tb_Product tb_Product)
        {
            if (ModelState.IsValid)
            {
                db.tb_Product.Add(tb_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.tb_Brand, "BrandID", "BrandName", tb_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.tb_Categories, "CategoryID", "CategoryName", tb_Product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.tb_Supplier, "SupplierID", "SupplierName", tb_Product.SupplierID);
            return View(tb_Product);
        }

        // GET: tb_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.tb_Brand, "BrandID", "BrandName", tb_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.tb_Categories, "CategoryID", "CategoryName", tb_Product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.tb_Supplier, "SupplierID", "SupplierName", tb_Product.SupplierID);
            return View(tb_Product);
        }

        // POST: tb_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Image,ListImages,Price,Quantity,Warranty,Hot,Description,Detail,ViewCount,BrandID,SupplierID,CategoryID,CreatedDate")] tb_Product tb_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.tb_Brand, "BrandID", "BrandName", tb_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.tb_Categories, "CategoryID", "CategoryName", tb_Product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.tb_Supplier, "SupplierID", "SupplierName", tb_Product.SupplierID);
            return View(tb_Product);
        }

        // GET: tb_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // POST: tb_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Product tb_Product = db.tb_Product.Find(id);
            db.tb_Product.Remove(tb_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ProductDetail(int? productID)
        {
            if (productID == null)
            {
                // Trả về trang lỗi nếu không có ProductID được cung cấp
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.tb_Product.Find(productID);

            if (product == null)
            {
                // Xử lý khi không tìm thấy sản phẩm
                // Bạn có thể chuyển hướng đến trang lỗi hoặc hiển thị thông báo khác tùy ý
                return HttpNotFound(); // hoặc return RedirectToAction("NotFound");
            }

            return View(product);
        }
    }
}
