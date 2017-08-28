using MVC_App.Data;
using MVC_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_App.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDbContext db = new CustomerDbContext();
        // GET: Customer
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Customer obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<Customer> user = db.Customers.ToList();
            return View(user);

        }

        public ActionResult edit(int Id)
        {
            Customer employee = db.Customers.Where(c => c.ID == Id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]

        public ActionResult edit(Customer emp)
        {
            Customer employee = db.Customers.Where(c => c.ID == emp.ID).FirstOrDefault();
            db.Entry(employee).CurrentValues.SetValues(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult delete(int Id)
        {

            Customer employee = db.Customers.Where(c => c.ID == Id).FirstOrDefault();
            db.Customers.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult details(int Id)
        {
            Customer employee = db.Customers.Where(c => c.ID == Id).FirstOrDefault();
            
            return View(employee);
        }
        public ActionResult Search()
        {

            return View();

        }
        public ActionResult SearchResults(string name)
        {
            Customer employee = db.Customers.Where(c => c.Name == name).FirstOrDefault();

            return View(employee);
        }

        public ActionResult getUsers()
        {
            return View();
        }


        public ActionResult PartialCustomers()
        {
            List<Customer> customers = db.Customers.ToList();
          //  Customer employee = db.Customers.Where(c => c.ID == id).FirstOrDefault();
            return PartialView("PartialCustomers", customers);

            //return PartialView( employee);

        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginDeatails(Customer obj)
        {
            Customer employee = db.Customers.Where(c =>  c.Email==obj.Email & c.Password == obj.Password).FirstOrDefault();
            if (employee == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("Invaliduser","gfgfgsfdg")

                //return View();
            }
            else
            {
                return View(employee);
            }
        }



    }
}