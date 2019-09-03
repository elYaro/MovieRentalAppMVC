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



        //Edit Action
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);


        }






        //Action for CREATE customer which is saving the customer passed from form to the Db
        //instead of passing as a parameter to Create action (CustomerFormViewModel) we pass (Customer customer). It is called MODEL BINDING
        //In order to use this action for both : creating a new customer and editing existing customer I have renamed the action from Create to Save and added some logic to an action (if customer id == 0 then create the customer, otherweise edit an existing customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //VALIDATION ACTION PARAPETER: customer
            //1st steep: add data annotations to properties in Domain Model
            //2nd steep: use ModelState.IsValid to change the flow of the program
            //3rd steep: add validation messages to the form @Html.ValidationMassageFor(c => c.Name)
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                /* now is the time to update the customer properties based on the form. There are few ways to do it:

                1st Way to update. - RECOMMENDED IN OFFICIAL MICROSOFT TUTORIALS
                     TryUpdateModel(customerInDb);
                    properties of this customer object will be updated based on the key-value pairs in request data.
                    Its gona open a SECURITY HOLE IN APPLICATION. In case that not all properties should be updated the hacker can modify and add some key-value pairs and manipulate the data.

                To avoid this Microsoft suggest another approach:
                2nd WAY to update. - RECOMMENDED BY MICROSOFT. Using the 3rd argument and in the string array including names of properties to be updated. This is not a good way. Problem is the magic strings. If one day we will change the properties names in the model class the names in string array will not match and application will blow.
                    TryUpdateModel(customerInDb, "", string []{"Name", "BirthDate", "Email" });

                3rd Way to update is as follows:
                
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


                4th Way to update is to use AutoMapper. AutoMapper is a convention based mapping tool. itlooks at the property names in the source and target object and mapps them by convention. 
                 Mapper.Map(customer, customerInDb)   

            */

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }



                _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }





        // Action for creating the new customer, returning the view with form
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer(),

            };

            return View("CustomerForm", viewModel);
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