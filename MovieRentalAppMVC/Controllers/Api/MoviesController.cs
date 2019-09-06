using MovieRentalAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalAppMVC.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET: /api/movies
        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _context.Movies.ToList();

            if (movies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movies;
        }


        //GET: /api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movie;
        }


        //POST /api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Movies.Add(movie);

            _context.SaveChanges();

            return movie;
            
        }


        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();
        }


        //DELETE /api/movie/1
        [HttpDelete]
        public void DeleteMovie (int id)
        {
            var movieIdDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieIdDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieIdDb);

            _context.SaveChanges();
        }

    }
}
