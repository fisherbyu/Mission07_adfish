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
        private readonly ILogger<HomeController> _logger;
        private MoviesContext _moviesContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MoviesContext DbMovieContext)
        {
            _logger = logger;
            _moviesContext = DbMovieContext;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
