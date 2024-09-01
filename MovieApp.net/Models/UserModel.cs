using MovieApp.net.Models.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.net.Models
{
	public class UserModel
	{
        public int UserId { get; set; }
		[Required]
		[StringLength(10,MinimumLength = 3,ErrorMessage ="Username 3-10 karakter arasında olmalıdır.")]
        public string UserName { get; set; }

		[Required]
		[StringLength(15, MinimumLength = 3, ErrorMessage = "{0} Karakter uzunluğu {2}-{1} arasında olmalıdır.")]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage ="Girdiğiniz mail, email formatı ile uyuşmuyor")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]//passwordu gizler
		[StringLength(12, MinimumLength = 6, ErrorMessage = "Password 6-12 karakter arasında olmalıdır.")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage = "Girdiğiniz şifreler eşleşmiyor.")]//aynı olması gereken property ismini nameof a verdik ve şifre ve yeniden şifre işlemi aynı olmassa kabul etmiyecektir sistem
		public string RePassword { get; set; }

		[Url]
		public string Url { get; set; }

		[BirthDateAttiribute(ErrorMessage ="Doğum tarihiniz şimdiki veya sonraki tarih olamaz")]
		[DataType(DataType.Date)]
		[Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}