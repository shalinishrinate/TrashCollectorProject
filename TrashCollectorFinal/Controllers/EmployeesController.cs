﻿using Microsoft.AspNet.Identity;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Employees
        public ActionResult Index()
        {
            string currentDay = DateTime.Today.DayOfWeek.ToString();
            string userId = User.Identity.GetUserId();
            var employee = _context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            var nearByCustomers = _context.Customers.Where(c => (c.Zipcode == employee.Zipcode) && (currentDay == c.PickupDay)).ToList();
            return RedirectToAction("Index", "Customers", nearByCustomers);
            
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            string userId = User.Identity.GetUserId();
            var employee = _context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var nearByCustomers = _context.Customers.Where(c => (c.Zipcode == employee.Zipcode)).ToList();
            return View(nearByCustomers);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                string UserId = User.Identity.GetUserId();
                employee.ApplicationId = UserId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var editedEmployee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
                editedEmployee.FirstName = employee.FirstName;
                editedEmployee.LastName = employee.LastName;
                editedEmployee.Zipcode = employee.Zipcode;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = new Employee();
            employee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                employee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
            
        }
        //get
        public ActionResult EmployeePickupDay()
        {
            string userId = User.Identity.GetUserId();

          var currentDay = DateTime.Today.DayOfWeek.ToString();

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }
        
        // GET: 
        public ActionResult PickupConfirmation(int id)
        {
            Customer customer = new Customer();
            customer = _context.Customers.Where(e => e.Id == id).SingleOrDefault();

            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PickupConfirmation(int id, Customer customer)
        {
            try
            {
            Customer editedcustomer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
                editedcustomer.PickupConfirmation = customer.PickupConfirmation;

            if (customer.PickupConfirmation == true)
            {
               editedcustomer.Balance += (10 + customer.Balance);
            }
              _context.SaveChanges();
              return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult Monday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Monday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Tuesday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Tuesday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Wednesday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Wednesday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Thursday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Thursday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Friday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Friday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Saturday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Saturday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        public ActionResult Sunday()
        {
            string userId = User.Identity.GetUserId();

            var currentDay = "Sunday";

            var employee = _context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            var nearbyCustomers = _context.Customers.Where(c => c.Zipcode == employee.Zipcode && c.PickupDay == currentDay).ToList();

            return View(nearbyCustomers);
        }

        //GET:
        //public ActionResult PickCustomerDaywise()
        //{
        //    WeekDay weekday = new SelectList(new List <string>()) { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday","Saturday","Sunday"}

        //    //what I want to be able to do is show customers who have chosen a particuar weekday based on the week day chosen on the dropdown.
        //}

        //// POST:
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult PickCustomerDayWise()
        //{

        //}
    }
}
