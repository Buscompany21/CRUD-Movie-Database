using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Movies ()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(ar);
                _movieContext.SaveChanges();

                return View("MovieConfirmation", ar);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(ar);
            }

            
        }

        public IActionResult MovieList ()
        {
            var moviesList = _movieContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(moviesList);
        }

        [HttpGet]
        public IActionResult Edit (string movieEntryID)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movieEntry = _movieContext.Responses.Single(x => x.Title == movieEntryID);
            return View("Movies", movieEntry);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse mr)
        {
            _movieContext.Update(mr);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (string movieEntryID)
        {
            var movieEntry = _movieContext.Responses.Single(x => x.Title == movieEntryID);
            return View(movieEntry);
        }

        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            _movieContext.Responses.Remove(mr);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
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
