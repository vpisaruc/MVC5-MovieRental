using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenres { get ; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Set movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Set movie Genre.")]
        public int? MovieGenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Set Release Date.")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        [Required(ErrorMessage = "Set Number in Stock.")]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        // конструктор по умолчанию
        public MovieFormViewModel()
        {
            Id = 0;
        }

        // конструктор для инициализации параметров MovieFormViewModel
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            MovieGenreId = movie.MovieGenreId;
        }
    }
}