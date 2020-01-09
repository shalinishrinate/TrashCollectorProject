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

            var employees = _context.Employees.Include(e => e.ApplicationUser).ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            employee = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
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
                string currentUserId = User.Identity.GetUserId();
                employee.ApplicationId = currentUserId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
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
    }
}
