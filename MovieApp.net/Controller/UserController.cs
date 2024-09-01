using Microsoft.AspNetCore.Mvc;
using MovieApp.net.Models;

namespace MovieApp.net.Controllers
{
	public class UserController : Controller
	{
		public IActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateUser(UserModel model)
		{
			return View();
		}
	}
}
