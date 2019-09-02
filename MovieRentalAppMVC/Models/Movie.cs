using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalAppMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Release")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date of Adding")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

    }
}