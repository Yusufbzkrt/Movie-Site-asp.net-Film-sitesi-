using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.net.Data;
using MovieApp.net.Entity;
using MovieApp.net.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        public MoviesController(MovieContext context)
        { 
            _context = context;
        }
		[HttpGet]
		public IActionResult Index()
        {
           
            return View();
        }

		//localhost:9666/movies/list/
		//localhost:9666/movies/list/id
		[HttpGet]
		public IActionResult List(int? id,string q)
        {
            //var movies = MovieRepository.Movies;
            var movies = _context.Movies.AsQueryable();

            if (id != null)
            {
                movies = movies
                    .Include(m => m.Genres)
                    .Where(m => m.Genres.Any(g=>g.GenreId==id)); //tür bilgisinin id si ile yukarıdan gönderilen id eşit mi kontrolü yapılır
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i =>
                i.Title.ToLower().Contains(q.ToLower()) ||
                i.Description.ToLower().Contains(q.ToLower()));            
            }
            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()//burası önceden Movies = MovieRepository.Movies; idi fakat filtrelenmiş bilgiyi veya filtrelenmemiş bilgiyi ekrana vermek için buna çevirdik.
            };
            return View("Movies", model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }
    }
}
/*GET metodu formun görüntülenmesini sağlar, POST metodu ise formdan gelen veriyi işler. Bu nedenle, form işlemleri için hem GET hem de POST metotlarını
 * tanımlamak gerekir. Eğer sadece POST metodunu kullanmak istiyorsanız, formu render eden bir GET metoduna ihtiyacınız vardır.*/

