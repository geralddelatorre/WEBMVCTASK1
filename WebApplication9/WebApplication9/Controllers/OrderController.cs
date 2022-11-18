using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;
using System.Web.Script.Serialization;
using ServiceStack.FluentValidation.Validators;
using MVC_Activity01.Models;

namespace WebApplication9.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order

        private MYEntities db = new MYEntities();
        private MYSEntities dbs = new MYSEntities();
        private MYEntities dbb = new MYEntities();
        private MYTEntities tdb = new MYTEntities();
        private MYSOrderFilterEntities dbFilter = new MYSOrderFilterEntities();
        private CUSTOMANDORDEREntities all = new CUSTOMANDORDEREntities();


        public ActionResult Index()
        {
            ViewBag.Title = "Order Details";
            var customers = db.Customs.ToList();
            var customerModel = customers.Select(c => new Custom
            {
                Id = c.Id,
                Fullname = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();


            SelectList CustomerList = new SelectList(customerModel, "Id", "Fullname");
            ViewData["CustomerList"] = CustomerList;
            return View();


        }

        //public ActionResult Orderlist(int id = 0)
        //{


        //    var customers = dbb.Customs.ToList();
        //    var customerModel = customers.Select(c => new Custom
        //    {
        //        Id = c.Id,
        //       Firstname = c.Firstname,
        //        Middlename = c.Middlename,
        //        Lastname = c.Lastname,
        //        Birthday = c.Birthday,
        //        Gender = c.Gender,
        //        Age = c.Age,
        //        Address = c.Address,
        //        Email = c.Email,
        //        Status = c.Status,

        //        Fullname = $"{c.Firstname}, {c.Middlename} {c.Lastname}"
        //    }).ToList();

        //    var orderList = all.Ordertbls.Where(x => x.CustomerId == id || id == 0).ToList();
        //    var modelOrder = orderList.Select(c => new Ordertbl
        //    {
        //        Id = c.Id,
        //        Orderno = c.Orderno,

        //        Orderdate = c.Orderdate,
        //        CustomerId = c.CustomerId,
        //        Totalamount = c.Totalamount,

        //        Customer = customerModel.FirstOrDefault(x => x.Id == c.CustomerId)
        //    }).ToList();



        //    return PartialView("Orderlist", modelOrder);
        //}
        //NEW DATA HERE!!
        public ActionResult Orderlist(int id = 0 )
        {


            var customers = db.Customs.ToList();
            var customerModel = customers.Select(c => new Custom
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Middlename = c.Middlename,
                Lastname = c.Lastname,
                Birthday = c.Birthday,
                Gender = c.Gender,
                Age = (int)c.Age,
                Address = c.Address,
                Email = c.Email,
                Status = c.Status,
                Fullname = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();
           
            var orderList = dbFilter.Ordertbl.Where(x => x.CustomerId == id || id == 0).ToList();
            var modelOrder = orderList.Select(c => new Ordertbl
            {
                Id = c.Id,
                Orderno = c.Orderno,
                Orderdate = c.Orderdate,
                
                CustomerId = c.CustomerId,
                Totalamount = c.Totalamount,
                Customer = customerModel.FirstOrDefault(x => x.Id == c.CustomerId)
            }).ToList();



            return PartialView("Orderlist", modelOrder);
        }


        [HttpGet]




        public ActionResult Create()
        {
            var customers = dbb.Customs.ToList();
            var customerModel = customers.Select(c => new Custom
            {
                Id = c.Id,
                Fullname = $"{c.Lastname}, {c.Firstname} {c.Middlename}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Fullname");
            ViewData["CustomerId"] = CustomerList;
            return View();
        }




        [HttpPost]
       

        public ActionResult Create(Ordertbl data)
        {
            using (all) {
                all.Ordertbls.Add(data);
                all.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}