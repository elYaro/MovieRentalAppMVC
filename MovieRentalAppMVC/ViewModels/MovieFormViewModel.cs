using MovieRentalAppMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalAppMVC.ViewModels
{
    public class MovieFormViewModel
    {
        //public Movie Movie { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Release")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 30)]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }



        public IEnumerable<Genre> Genres { get; set; }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}