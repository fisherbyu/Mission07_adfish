using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_adfish.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_adfish.Controllers
{
    public class HomeController : Controller
    {
        
        private MoviesContext _moviesContext { get; set; }
        public HomeController( MoviesContext DbMovieContext)
        {
            _moviesContext = DbMovieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyMovies()
        {
            var MovieList = _moviesContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(MovieList);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _moviesContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _moviesContext.Add(response);
                _moviesContext.SaveChanges();
                return View("ConfirmEntry", response);
            }
            else
            {
                ViewBag.Categories = _moviesContext.Categories.ToList();
                return View();
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.Categories = _moviesContext.Categories.ToList();

            var movie = _moviesContext.Responses.Single(x => x.MovieId == MovieId);

            return View("AddMovie", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            _moviesContext.Update(response);
            _moviesContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }
        
        
        [HttpGet]
        public IActionResult Delete(int MovieID)
        {
            var movie = _moviesContext.Responses.Single(x => x.MovieId == MovieID);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            _moviesContext.Responses.Remove(response);
            _moviesContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }


    }
}
