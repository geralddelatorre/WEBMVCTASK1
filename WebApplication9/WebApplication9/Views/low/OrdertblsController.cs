using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Views.low
{
    public class OrdertblsController : Controller
    {
        private CUSTOMANDORDEREntities db = new CUSTOMANDORDEREntities();

        // GET: Ordertbls
        public ActionResult Index()
        {
            return View(db.Ordertbls.ToList());
        }

        // GET: Ordertbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordertbl ordertbl = db.Ordertbls.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }
            return View(ordertbl);
        }

        // GET: Ordertbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ordertbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Orderno,Orderdate,CustomerId,Totalamount")] Ordertbl ordertbl)
        {
            if (ModelState.IsValid)
            {
                db.Ordertbls.Add(ordertbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordertbl);
        }

        // GET: Ordertbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordertbl ordertbl = db.Ordertbls.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }
            return View(ordertbl);
        }

        // POST: Ordertbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Orderno,Orderdate,CustomerId,Totalamount")] Ordertbl ordertbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordertbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordertbl);
        }

        // GET: Ordertbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordertbl ordertbl = db.Ordertbls.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }
            return View(ordertbl);
        }

        // POST: Ordertbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordertbl ordertbl = db.Ordertbls.Find(id);
            db.Ordertbls.Remove(ordertbl);
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
