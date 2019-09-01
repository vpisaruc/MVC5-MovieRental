using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using AutoMapper;

namespace Vidly.Controllers
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

        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.MovieGenre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }

            return View("ReadOnlyList");

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movieGenre = _context.MovieGenres.ToList();
            var movie = new Movie();
            var viewModel = new MovieFormViewModel(movie)
            {
                MovieGenres = movieGenre
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            // валидатор нашей формы, он смотрит на параметры в [] базы данных,в нашем случае класса
            // и если не удовлетворяет возвращает нас на эту же страницу с сообщениями об ошибке 
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenres = _context.MovieGenres.ToList()
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
                // это очень симпатичный вариант решения, но он работает через раз
                //Mapper.Map(movie, movieInDb);
                movieInDb.Name = movie.Name;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            // этот блок необходим, чтобы отлавливать ошибки

             _context.SaveChanges();
            


            return RedirectToAction("Index", "Movies");
        }
    }
}