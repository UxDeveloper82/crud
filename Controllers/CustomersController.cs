using Microsoft.AspNetCore.Mvc;
using PartsInventory.Data;
using PartsInventory.Models;
using PartsInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: Customers
        public IActionResult Index() 
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        
        }

        public IActionResult Details(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return NoContent();
            return View(customer);
        }

        public IActionResult New() 
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer
                };
            
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Email = customer.Email;
                customerInDb.MobilPhone = customer.MobilPhone;
                customerInDb.BillingAddress = customer.BillingAddress;
                customerInDb.City = customer.City;
                customerInDb.State = customer.State;
                customerInDb.PostalCode = customer.PostalCode;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        
        }



    }
}
