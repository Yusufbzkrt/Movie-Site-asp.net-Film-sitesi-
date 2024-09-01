using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Models.Validators
{
	public class ClassicMovieAttirıbute: ValidationAttribute
	{
        public ClassicMovieAttirıbute(int year)
        {
            Year = year;
        }
        public int Year { get; set; }
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var movie = (AdminCreateMovieModel)validationContext.ObjectInstance;
			var releaseYear = ((DateTime)value).Year;

			if(movie.IsClassic && releaseYear > Year)
			{
				return new ValidationResult($"Klasik film için {Year} ve öncesi değer girmelisin.");
			}
			return ValidationResult.Success;
		}
	}
}
