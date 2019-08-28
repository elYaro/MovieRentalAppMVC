using MovieRentalAppMVC.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalAppMVC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Customers
        public ActionResult Index()
        {

            //var customers = GetAllCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }



        //GET: Customers/Details/1
        public ActionResult Details(int id)
        {
            //var customer = GetAllCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer); 
        }


        /*
        //Helper method to create list of Customers
        private IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Bolek Bolkowski"},
                new Customer {Id = 2, Name = "Lolek Lolkowski"},
                new Customer {Id = 3, Name = "Tola Tolkowska"}
            };

            return customers;

        }
        */
    }
}