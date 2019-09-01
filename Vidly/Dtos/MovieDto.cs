using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Set movie Name")]
        public string Name { get; set; }

        public MovieGenreDto MovieGenre { get; set; }

        [Required(ErrorMessage = "Set movie Genre.")]
        public int MovieGenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Set Release Date.")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        [Required(ErrorMessage = "Set Number in Stock.")]
        public int NumberInStock { get; set; }
    }
}