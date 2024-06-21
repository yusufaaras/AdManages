using AdManage.Domain.Entities;
using AdManage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Areas.Register.Controllers
{ 
    [Area("UserProcedures")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> _UserManager;
		private readonly SignInManager<AppUser> _SignInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_UserManager = userManager;
			_SignInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserRegistorViewModel p) // async eklendi
		{
			AppUser appUser = new AppUser()
			{
				Name = p.Name,
				Surname = p.SurName,
				Email = p.Mail,
				UserName = p.UserName
			};
			if (p.Password == p.ConifrmPassword)
			{
				var result = await _UserManager.CreateAsync(appUser, p.Password);

				if (result.Succeeded)
				{
					
					return Redirect("/UserProcedures/Login/Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(p);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(UserSignInViewModel p)
		{
			

			if (ModelState.IsValid)
			{   
				var result = await _SignInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Default");
				}
				else
				{
					return Redirect("/UserProcedures/Login/Login");
				}
			}
			return View(p);
		}
	}
}