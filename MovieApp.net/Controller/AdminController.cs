using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.net.Data;
using MovieApp.net.Entity;
using MovieApp.net.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.net.Controllers
{
	public class AdminController : Controller
	{
		private readonly MovieContext _context;
		public AdminController(MovieContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MovieUpdate(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
			{
				MovieId = m.MovieId,
				Title = m.Title,
				Description = m.Description,
				Imageurl = m.ImageUrl,
				GenreIds = m.Genres.Select(i=>i.GenreId).ToArray()
			}).FirstOrDefault(m => m.MovieId == id);

			ViewBag.Genres = _context.Genres.ToList();

			if (entity == null)
			{
				return NotFound();
			}
			return View(entity);
		}

		[HttpPost]//aşağıda asenkron bir metot olarak tanımladığımız için fonk başına async getirdik ve task içine aldık.
		public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model, int[] genreIds, IFormFile file) //Iformfile deymini kullanmalı ve yanında movieupdate de kullandığımız name issmiyle aynısını girmeliyiz yani file
		{
			if (ModelState.IsValid)
			{
				var entity = _context.Movies.Include(m => m.Genres).FirstOrDefault(m => m.MovieId == model.MovieId);//neden ınclude; Include, ilişkili tabloların verilerini sorguya dahil etmek için kullanılır. 
				if (entity == null) { return NotFound(); }

				entity.Title = model.Title;
				entity.Description = model.Description;
				if (file != null)
				{
					var extension = Path.GetExtension(file.FileName);//yüklenen dosyanın uzantısını aldık.
					var fileName = string.Format($"{Guid.NewGuid()}{extension}");//upload edilen resme guid ile benzersiz bir isim atandı ve extension değişkeni ile dosyanın uzantısı eklendi sonuna
					var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);//dosyanın kaydedileceği yer
					entity.ImageUrl = fileName;
					using (var stream = new FileStream(path, FileMode.Create)) //using ekledik ki işimiz bittiği zaman bellekten silinmiş olsun
					{
						await file.CopyToAsync(stream);
					}
				}
				entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList(); //Bu kod, belirli bir film (entity) için genreIds listesindeki ID'lerle ilişkili türleri (Genres) alır ve bu türleri entity.Genres listesine atar. Başka bir deyişle, bir film için seçilen türlerin listesini günceller.
				_context.SaveChanges();
				return RedirectToAction("MovieList");
			}
			ViewBag.Genres = _context.Genres.ToList();
			return View(model);
			//resim yüklemek için IFormFile file parametresi ve 59-70 arası kod nloğu yazıldı
		}

		public IActionResult MovieList()
		{
			return View(new AdminMoviesViewModel
			{
				Movies = _context.Movies
				.Include(m => m.Genres)
				.Select(m => new AdminMovieViewModel
				{
					MovieId = m.MovieId,
					Title = m.Title,
					Imageurl = m.ImageUrl,
					Genres = m.Genres.ToList()
				})
				.ToList()/*burda sistemi çalıştırdığımız zaman description kısmı 
         falanda geliyordu fakat biz bu bbilgileri istemiyoruz 
        bunun için bu kısmı özelleştirdik ve sadece istediğmiz
        kısımların bilgilerini yazdık*/
			});
		}

		public IActionResult GenreList()
		{
			return View(GetGenres());
		}
		private AdminGenresViewModel GetGenres()
		{
			return new AdminGenresViewModel
			{
				Genres = _context.Genres.Select(g => new AdminGenreViewModel
				{
					GenreId = g.GenreId,
					Name = g.Name,
					Count = g.Movies.Count
				}).ToList()
			};
		}//AdminGenresView model döndürür

		[HttpPost]
		public IActionResult GenreCreate(AdminGenresViewModel model)
		{
			if (ModelState.IsValid)
			{
				_context.Genres.Add(new Genre { Name = model.Name });
				_context.SaveChanges();
				return RedirectToAction("GenreList");
			}
			return View("GenreList", GetGenres());//genrelisti döndürür ve modeli çalıştırrır
		}
		public IActionResult GenreUpdate(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var entity = _context
				.Genres
				.Select(g => new AdminGenreEditViewModel
				{
					GenreId = g.GenreId,
					Name = g.Name,
					Movies = g.Movies.Select(i => new AdminMovieViewModel
					{
						MovieId = i.MovieId,
						Title = i.Title,
						Imageurl = i.ImageUrl
					}).ToList()
				}).FirstOrDefault(g => g.GenreId == id);
			if (entity == null)
			{
				return NotFound();
			}
			return View(entity);
		}
		[HttpPost]
		public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
		{
			if (ModelState.IsValid)
			{
				var entity = _context.Genres.Include("Movies").FirstOrDefault(i => i.GenreId == model.GenreId);
				if (entity == null) { return NotFound(); }
				entity.Name = model.Name;
				foreach (var id in movieIds) 
				{
					entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
				}

				entity.Name = model.Name;
				_context.SaveChanges();
				return RedirectToAction("GenreList");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult GenreDelete(int genreid)
		{
			var entity = _context.Genres.Find(genreid);
			if (entity != null)
			{
				_context.Genres.Remove(entity);
				_context.SaveChanges();
			}
			return RedirectToAction("GenreList");
		}
		[HttpPost]
		public IActionResult MovieDelete(int movieid)
		{
			var entity = _context.Movies.Find(movieid);
			if (entity != null)
			{
				_context.Movies.Remove(entity);
				_context.SaveChanges();
			}
			return RedirectToAction("MovieList");
		}
		public IActionResult MovieCreate()
		{
			ViewBag.Genres = _context.Genres.ToList();

			return View(new AdminCreateMovieModel());//ilk get isteği gönderilip sistem ayağı kalkmaya çalıştığı için modeli belirtmeliyiz
		}
		[HttpPost]
		public IActionResult MovieCreate(AdminCreateMovieModel model, int[] genreIds, IFormFile file)
		{

			//if (genreIds.Length==0) 
			//{
			//	ModelState.AddModelError("GenreIds","En az bir tür seçmelisiniz.");
			//}

			if (ModelState.IsValid)
			{
				var entity = new Movie
				{
					Title = model.Title,
					Description = model.Description,
					ImageUrl = "no-image.png"
				};
				if (file != null && file.Length > 0)
				{
					var fileName = Path.GetFileName(file.FileName);
					var filePath = Path.Combine("wwwroot/img", fileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}

					entity.ImageUrl = fileName; // Yüklenen dosyanın adı veritabanına kaydedilecek
				}
				foreach (int id in genreIds)
				{
					entity.Genres.Add(_context.Genres.FirstOrDefault(i => i.GenreId == id));
				}
				_context.Movies.Add(entity);
				_context.SaveChanges();
				return RedirectToAction("MovieList", "Admin");//admin altındaki movielist
			}
			ViewBag.Genres = _context.Genres.ToList();

			return View(model);
		}
	}

}
