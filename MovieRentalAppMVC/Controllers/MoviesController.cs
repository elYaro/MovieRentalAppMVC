﻿using MovieRentalAppMVC.Models;
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
                OPTIONAL PARAMETERS
                Below an example of using optional parameter. To use optional parameter we need to make in nullable. 
                Int is value type so we need to make it nullable by using "?".
                String is reference type so it is already nullable.
                NOTICE: we can not sent those both parameters in URL in this scenario because it needs custom routing. See example above


                // GET: Movies/Index/ or /Movies because Index id default action , it is set in RouteConfig
                public ActionResult Index(int? pageIndex, string sortBy)
                {
                    if (!pageIndex.HasValue)
                    {
                        pageIndex = 1;
                    }
                
                    if (string.IsNullOrWhiteSpace(sortBy))
                    {
                        sortBy = "ascending";
                    }

                    return Content(string.Format("page Index = {0} and sort By = {1}", pageIndex, sortBy));
                }
        */

        /* 
                ACTION PARAMETERS
                Action Parameters which are the inputs to Actions
                Below an example how EntFr maps request data to parameter values for Action Methods.  
                So, if an Action Method takes a parapeter, EnFr looks for the parameter with the same name in the requst data. 
                If the names match it passes tha data. 
            
                Here the parameter passed in 
                ULR: / movies/edit/2 
                or 
                in the query string : /movies/edit?id=2
                or
                in the form data
                are mapped and passed 

                // GET: Movies/Edit/2
                public ActionResult Edit (int id)
                {
                    return Content("Id = " + id);
                }
        */



        /*
                ACTION RESULTS
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