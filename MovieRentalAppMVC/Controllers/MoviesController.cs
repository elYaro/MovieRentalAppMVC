using MovieRentalAppMVC.Models;
using MovieRentalAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalAppMVC.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        //Action for CREATE movie which is saving the movie passed from form to the Db
        //instead of passing as a parameter to Create action (MovieFormViewModel) we pass (Movie movie). It is called MODEL BINDING
        //In order to use this action for both : creating a new movie and editing existing movie I have renamed the action from Create to Save and added some logic to an action (if movie id == 0 then create the movie, otherweise edit an existing movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    //Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            
            

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }





        // Action for creating the new customer, returning the view with form
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),
                //Movie = new Movie()
                
            };

            return View("MovieForm", viewModel);
        }



        //Edit Action
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id == id);

            if (movie ==null)
            {
                return HttpNotFound();
            }
           
            var viewModel = new MovieFormViewModel(movie)
            {
                //Movie = movie,

                //Id = movie.Id,
                //Name = movie.Name,
                //ReleaseDate = movie.ReleaseDate,
                //GenreId = movie.GenreId,
                //NumberInStock = movie.NumberInStock,

            Genres = _context.Genres.ToList()
            };
           

            return View("MovieForm", viewModel); 
        }


        //GET: Movies
        public ActionResult Index()
        {
            //var movies = GetAllMovies();
            // var movies = _context.Movies.Include(m => m.Genre).ToList();

            //return View(movies);

            if (User.IsInRole("CanManageMovies"))
                return View();

            return View("ReadOnlyIndex");

        }

        
        
        //GET: Movies/Details/1
        public ActionResult Details(int id)
        {
            //var movie = GetAllMovies().SingleOrDefault(m => m.Id == id);
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        /*    
        //Helper method to create list of Movies
        private IEnumerable<Movie> GetAllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Skrek 2"},
                new Movie { Id = 3, Name = "Wall-e"}
            };

            return movies;
        }
        */



        



        /*
                CUSTOM ROUTE NEW WAY , ATTRIBUTE ROUTES
                In order to sent multiple parapeters in URL we need costom routes. 
                To do so we need to add custom routes in RoutesConfig, look over there to see an example.
                We can use the old school way: routes.MapRoute() 
                or
                the new way routes.MapMvcArrtibuteRoutes(). Both are presented in RoutesConfig.cs
/*
                
                NOTE:
                COONSTRAINS example: 
                min, 
                max, 
                range, 
                minlenght, 
                maxlengh, 
                int, 
                float, 
                guid (GUID is a 16 byte binary SQL Server data type that is globally unique across tables, databases, and servers.)

        
                [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
                public ActionResult ByReleaseDate(int year, int month)
                {

                    return Content(string.Format("year = {0} and month = {1}", year, month));
                }
    
        */

        /*
                MULTIPLE PARAMETERS
                In order to sent multiple parapeters in URL we need costom routes. 
                To do so we need to add custom routes in RoutesConfig.
                We can use the old scool way: routes.MapRoute() or the new way routes.MapMvcArrtibuteRoutes(). 
                Both are shown in RoutesConfig.cs
        

                //GET: Movies/Released/1999/3
                public ActionResult ByReleaseDate(int year, int month)
                {

                    return Content(string.Format("year = {0} and month = {1}", year, month)) ;
                }
        */



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