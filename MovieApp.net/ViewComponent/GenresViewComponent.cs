using Microsoft.AspNetCore.Mvc;
using MovieApp.net.Data;
using MovieApp.net.Models;
using System.Collections.Generic;
using System.Linq;
namespace MovieApp.net.ViewComponents

{
    public class GenresViewComponent:ViewComponent
    {
        private readonly MovieContext _context;
        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Genres.ToList());
        }
    }
}

