using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorFinal.Models;

namespace TrashCollectorFinal.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.ApplicationUser).ToList();
            return View(customers);

        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            // GETUSERID
           
            var userId = User.Identity.GetUserId();
            var customer = _context.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            customer.SuspendedStart = DateTime.Now;
            customer.SuspendedEnd = DateTime.Now;
            customer.DaysOfWeek = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            return View(customer);
        }

        // POST: Customers/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                customer.ApplicationId = currentUserId;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
            
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = new Customer();
            customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            customer.SuspendedStart = DateTime.Now;
            customer.SuspendedEnd = DateTime.Now;
            customer.DaysOfWeek = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            return View(customer);
        }
        //no
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var editedCustomer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
                editedCustomer.FirstName = customer.FirstName;
                editedCustomer.LastName = customer.LastName;
                editedCustomer.City = customer.City;
                editedCustomer.State = customer.State;
                editedCustomer.StreetAddress = customer.StreetAddress;
                editedCustomer.Zipcode = customer.Zipcode;
                editedCustomer.PickupDay = customer.PickupDay;
                editedCustomer.ExtraPickupDate = customer.ExtraPickupDate;
                //editedCustomer.Balance = customer.Balance;
                editedCustomer.SuspendedStart = customer.SuspendedStart;
                editedCustomer.SuspendedEnd = customer.SuspendedEnd;
                editedCustomer.PickupConfirmation = customer.PickupConfirmation;

                if (customer.PickupConfirmation == true)
                {
                    editedCustomer.Balance += (10 + customer.Balance);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {

                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult PickupDate(int id)
        //{
        //    Customer customer = new Customer();
        //    customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PickupDate(int id, Customer customer)
        //{
        //    try
        //    {
        //        var editedCustomer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
        //        editedCustomer.PickupConfirmation = customer.PickupConfirmation;
        //        editedCustomer.ExtraPickupDate = customer.ExtraPickupDate;
        //        editedCustomer.Balance = customer.Balance;
        //        editedCustomer.SuspendedStart = customer.SuspendedStart;
        //        editedCustomer.SuspendedEnd = customer.SuspendedEnd;
                
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}

    }
}
