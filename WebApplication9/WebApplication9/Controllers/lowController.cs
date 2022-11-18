using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class lowController : Controller
    {
        // GET: low
        public ActionResult Index()
        {
            return View();
        }

        // GET: low/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: low/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: low/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: low/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: low/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: low/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: low/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
