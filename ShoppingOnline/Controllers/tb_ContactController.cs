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
    public class tb_ContactController : Controller
    {
        private ShoppingOnlineDB db = new ShoppingOnlineDB();

        // GET: tb_Contact
        public ActionResult Index()
        {
            var tb_Contact = db.tb_Contact.Include(t => t.tb_Customers);
            return View(tb_Contact.ToList());
        }

        // GET: tb_Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = db.tb_Contact.Find(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tb_Contact);
        }

        // GET: tb_Contact/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.tb_Customers, "CustomerID", "Name");
            return View();
        }

        // POST: tb_Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,Name,Email,Message,CreatedDate,CustomerID")] tb_Contact tb_Contact)
        {
            if (ModelState.IsValid)
            {
                db.tb_Contact.Add(tb_Contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.tb_Customers, "CustomerID", "Name", tb_Contact.CustomerID);
            return View(tb_Contact);
        }

        // GET: tb_Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = db.tb_Contact.Find(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.tb_Customers, "CustomerID", "Name", tb_Contact.CustomerID);
            return View(tb_Contact);
        }

        // POST: tb_Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,Name,Email,Message,CreatedDate,CustomerID")] tb_Contact tb_Contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.tb_Customers, "CustomerID", "Name", tb_Contact.CustomerID);
            return View(tb_Contact);
        }

        // GET: tb_Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = db.tb_Contact.Find(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tb_Contact);
        }

        // POST: tb_Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Contact tb_Contact = db.tb_Contact.Find(id);
            db.tb_Contact.Remove(tb_Contact);
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
