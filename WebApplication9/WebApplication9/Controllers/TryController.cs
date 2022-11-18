using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class TryController : Controller
    {
        private MYEntities db = new MYEntities();

        // GET: Try
        public ActionResult Index()
        {
            return View(db.Customs.ToList());
        }

        // GET: Try/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            return View(custom);
        }

        // GET: Try/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Try/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Middlename,Lastname,Birthday,Gender,Age,Address,Email,Status")] Custom custom)
        {
            if (ModelState.IsValid)
            {
                db.Customs.Add(custom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(custom);
        }

        // GET: Try/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            return View(custom);
        }

        // POST: Try/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Middlename,Lastname,Birthday,Gender,Age,Address,Email,Status")] Custom custom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(custom);
        }

        // GET: Try/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            return View(custom);
        }

        // POST: Try/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custom custom = db.Customs.Find(id);
            db.Customs.Remove(custom);
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
