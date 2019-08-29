using MovieRentalAppMVC.Models;
using MovieRentalAppMVC.ViewModels;
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



        //Action for CREATE customer which is saving the customer passed from form to the Db
        //instead of passing as a parapeter to Create action (NewCustomerViewModel viewModel) we pass (Customer customer). It is called MODEL BINDING
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }





        // Action for creating the new customer, returning the view with form
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes

            };

            return View(viewModel);
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