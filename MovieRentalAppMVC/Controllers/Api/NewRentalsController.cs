using MovieRentalAppMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalAppMVC.Models;

namespace MovieRentalAppMVC.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        
        // /api/newrentalscontroller/createnewrental
        [HttpPost]
        public IHttpActionResult CreateNewRental (NewRentalDto newRental)
        {
            //2nd Edge Case: no movies in the Dto
            if (newRental.MovieIdsList.Count == 0)
            {
                return BadRequest("No Movie Ids have been given");
            }


            //1st Edge Case: customer is not valid
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
            {
                return BadRequest("Customer Id is not valid");
            }


            var movies = _context.Movies.Where(m => newRental.MovieIdsList.Contains(m.Id)).ToList();

            //3rd Edge Case: one or more movies are invalid
            if (movies.Count != newRental.MovieIdsList.Count)
            {
                return BadRequest("One or more movies are invalid");
            }

            foreach (var movie in movies)
            {

                //4th Edge Case: in movie is no longer available
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
            
        }

        
    }
}
