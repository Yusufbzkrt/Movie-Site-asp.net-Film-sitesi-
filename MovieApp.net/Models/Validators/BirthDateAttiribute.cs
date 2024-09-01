using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Models.Validators
{
	public class BirthDateAttiribute: ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime datetime =Convert.ToDateTime(value);
			return datetime <= DateTime.Now;
		}
	}
}
