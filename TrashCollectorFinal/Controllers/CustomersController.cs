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
        public ActionResult Index(List<Customer> customerList)
        {
            List<Customer> customers;
            if (customerList == null)
            {
                customers = _context.Customers.Include(c => c.ApplicationUser).ToList();
            }
            else
            {
                customers = customerList;
            }
            return View(customers);

        }

        public ActionResult CustomerIndex()
        {
            var userId = User.Identity.GetUserId();
            var customer = _context.Customers.Include(c => c.ApplicationUser).FirstOrDefault();
            List<Customer> SingleCustomer = _context.Customers.Where(c => c.Id == customer.Id).ToList();
            return View(SingleCustomer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {

            var userId = User.Identity.GetUserId();
            Customer customer;
            if (User.IsInRole("Customer") == true && id == null)
            {
                customer = _context.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            }
            else
            {
                customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            //customer.SuspendedStart = DateTime.Now;
            //customer.SuspendedEnd = DateTime.Now;
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
                return RedirectToAction("Details", "Customers");
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
            //customer.SuspendedStart = DateTime.Now;
            //customer.SuspendedEnd = DateTime.Now;
            customer.DaysOfWeek = new SelectList(new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var editedCustomer = _context.Customers.Include(c => c.ApplicationUser).Where(c => c.Id == id).SingleOrDefault();
                editedCustomer.FirstName = customer.FirstName;
                editedCustomer.LastName = customer.LastName;
                editedCustomer.StreetAddress = customer.StreetAddress;
                editedCustomer.City = customer.City;
                editedCustomer.State = customer.State;
                editedCustomer.Zipcode = customer.Zipcode;
                editedCustomer.PickupDay = customer.PickupDay;
                editedCustomer.ExtraPickupDate = customer.ExtraPickupDate;
                editedCustomer.SuspendedStart = customer.SuspendedStart;
                editedCustomer.SuspendedEnd = customer.SuspendedEnd;
                _context.SaveChanges();
                return RedirectToAction("Details", editedCustomer);
            }
            catch
            {

                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult CreatePickup(int id)
        {
            Customer customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePickup(int? id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer editedCustomer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
                editedCustomer.PickupDay = customer.PickupDay;
                editedCustomer.SuspendedStart = customer.SuspendedStart;
                editedCustomer.SuspendedEnd = customer.SuspendedEnd;

                if (User.IsInRole("Customer"))
                    if (editedCustomer.ExtraPickupDate == null)
                    {
                        editedCustomer.ExtraPickupDate = customer.ExtraPickupDate;
                    }
                _context.SaveChanges();
                return RedirectToAction("Details", editedCustomer);

            }

            catch (Exception e)
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
