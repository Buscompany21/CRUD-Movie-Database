using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission_4_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_4_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            _movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            var movies = _movieContext.Responses.ToList();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse ar)
        {
            _movieContext.Add(ar);
            _movieContext.SaveChanges();
            return View("MovieConfirmation", ar);
        }

        public IActionResult MovieList ()
        {
            return View();
        }

        public IActionResult MyPodcasts()
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
