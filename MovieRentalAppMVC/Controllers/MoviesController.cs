using MovieRentalAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalAppMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };

            return View(movie);
        }





        /*
                ActionResults which are the outputs of actions
                Below some helper methods of ActionResult


                // GET: Movies/ActionResultHelperMethods
                public ActionResult ActionResultHelperMethods()
                {
                    var movie = new Movie() { Name = "Shrek" };


                    //return View(movie);
                    //return Content("bla bla bla content view helper method");
                    //return Redirect("http://google.com");
                    //return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "someFilter" });
                    //return HttpNotFound();
                    //return new EmptyResult();
                    //return Json(...);
                    //return File(...)
                }
        */
    }
}