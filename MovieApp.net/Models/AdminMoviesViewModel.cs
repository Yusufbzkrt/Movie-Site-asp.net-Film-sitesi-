using MovieApp.net.Entity;
using MovieApp.net.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Models
{
	public class AdminMoviesViewModel
	{
		public List<AdminMovieViewModel> Movies { get; set; }
	}
	public class AdminMovieViewModel
	{
		public int MovieId { get; set; }
		public string Title { get; set; }
		public string Imageurl { get; set; }
		public List<Genre> Genres { get; set; }
		/*burda sistemi çalıştırdığımız zaman description kısmı 
         falanda geliyordu fakat biz bu bbilgileri istemiyoruz 
        bunun için bu kısmı özelleştirdik ve sadece istediğmiz
        kısımların bilgilerini yazdık*/
	}

	public class AdminCreateMovieModel
	{
		[Display(Name = "Film Adı")]
		[Required(ErrorMessage = "Film adı girmelisiniz.")]
		[StringLength(100)]
		public string Title { get; set; }
		[Display(Name = "Film Açıklaması")]
		[Required(ErrorMessage = "Film açıklaması girmelisiniz.")]
		[StringLength(3500, MinimumLength = 10, ErrorMessage = "Film açıklaması için 10-3500 karakter girilmelidir.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "En az bir tür seçmelisiniz")]
		public int[] GenreIds { get; set; }

        public bool IsClassic { get; set; }//film klasik mi?

		[ClassicMovieAttirıbute(1950)]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; } = DateTime.Now; //Default olarak bugünkü tarih bilgisi işaretlenir
    }

	public class AdminEditMovieViewModel
	{
		public int MovieId { get; set; }

		[Display(Name = "Film Adı")]
		[Required(ErrorMessage = "Film adı girmelisiniz.")]
		public string Title { get; set; }

		[Display(Name = "Film Açıklaması")]
		[Required(ErrorMessage = "Film açıklaması girmelisiniz.")]
		[StringLength(3500, MinimumLength = 10, ErrorMessage = "Film açıklaması için 10-3500 karakter girilmelidir.")]
		public string Description { get; set; }
		public string Imageurl { get; set; }
		[Required(ErrorMessage = "En az bir tür seçmelisiniz")]
		public int[] GenreIds { get; set; }
	}
}

