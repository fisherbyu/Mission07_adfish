using Microsoft.AspNetCore.Mvc;
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
            var MovieList = _moviesContext.Responses.ToList();

            return View(MovieList);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _moviesContext.Add(response);
            _moviesContext.SaveChanges();
            return View("ConfirmEntry", response);
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        
    }
}
