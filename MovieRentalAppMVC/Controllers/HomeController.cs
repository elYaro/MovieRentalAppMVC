using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MovieRentalAppMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /*
         * Allowing OUTPUT Cache'ing to cache thw rendered HTML : 
         * Duration -> how long data in cache is stored, 
         * Location -> we can cache data on the server (if view is NOT specific to the given user) or on the client (if view is specific to the given user),
         * VaryByParam -> if this action takes one or more parameters, and the output changes based on the value of these parameters, we can cache each output separately ex. for specific param = "genre" , for all params ="*"
         
        [OutputCache(Duration =20, Location = OutputCacheLocation.Server, VaryByParam = "*" )]
        */

        /*
         * in order to DISABLE CACHING we change the above line into this:
         Duration -> to zero (0)
         NoStore = true
        */
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A few words about this project.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can reach me under one of the following:";

            return View();
        }
    }
}