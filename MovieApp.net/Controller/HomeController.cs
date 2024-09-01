using Microsoft.AspNetCore.Mvc;
using MovieApp.net.Data;
using MovieApp.net.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controlers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                PopularMovies = _context.Movies.ToList()
            };
            return View(model);
        }
        public IActionResult about()
        {
            return View();
        }
    }
}
