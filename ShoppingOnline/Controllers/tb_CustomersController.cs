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
    public class tb_CustomersController : Controller
    {
        private ShoppingOnlineDB db = new ShoppingOnlineDB();

        // GET: tb_Customers
        public ActionResult Index()
        {
            return View(db.tb_Customers.ToList());
        }

        // GET: tb_Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customers tb_Customers = db.tb_Customers.Find(id);
            if (tb_Customers == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customers);
        }

        // GET: tb_Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,Account,Password,Email,Address,Phone,Image,Birthday")] tb_Customers tb_Customers)
        {
            if (ModelState.IsValid)
            {
                db.tb_Customers.Add(tb_Customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Customers);
        }

        // GET: tb_Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customers tb_Customers = db.tb_Customers.Find(id);
            if (tb_Customers == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customers);
        }

        // POST: tb_Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,Account,Password,Email,Address,Phone,Image,Birthday")] tb_Customers tb_Customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Customers);
        }

        // GET: tb_Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customers tb_Customers = db.tb_Customers.Find(id);
            if (tb_Customers == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customers);
        }

        // POST: tb_Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Customers tb_Customers = db.tb_Customers.Find(id);
            db.tb_Customers.Remove(tb_Customers);
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
    }
}
