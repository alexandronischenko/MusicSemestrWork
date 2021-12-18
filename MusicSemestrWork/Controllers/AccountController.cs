using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSemestrWork;
using MusicSemestrWork.Models;
using MusicSemestrWork.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
	public class AccountController : Controller
	{
		private ApplicationContext db;
		private JwtSecurityToken _token;
		public User CurrentUser { get => GetUser(); }
        public string ClaimsType { get; private set; }

        public AccountController(ApplicationContext context)
		{
			db = context;
		}

		public IActionResult Index()
		{

			if (CurrentUser == null)
			{
				return RedirectToAction("Register", "Auth");
			}
			return View(CurrentUser);
		}

		public IActionResult Profile()
		{
            if (CurrentUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(CurrentUser);
		}

		public IActionResult Settings(UserViewModel model)
		{
            if (CurrentUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (model.Avatar != null)
			{
				byte[] imageData = null;
				using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
				}
				CurrentUser.Avatar = imageData;
			}

			if (model.Birthday != null)
            {
				CurrentUser.Birthday = model.Birthday;
            }

			if (model.Username != null)
			{
				CurrentUser.Username = model.Username;
			}

			if (model.Password != null && model.NewPassword != null)
			{
				CurrentUser.Password = Encryption.EncryptString(model.NewPassword);	
			}


			db.SaveChanges();

			return View(CurrentUser);
		}


		public User GetUser()
		{
			var currentUser = HttpContext.User;

			if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
			{
				return null;
			}

			var stream = Request.Cookies["token"];
			var handler = new JwtSecurityTokenHandler();
			var jsonToken = handler.ReadToken(stream);
			_token = jsonToken as JwtSecurityToken;

			//var CurrentName = _token.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
			var CurrentId = _token.Claims.First(claim => claim.Type == "nameid").Value;

            var user = db.Users.FirstOrDefault(u => u.Id.ToString() == CurrentId);

			return user;
		}
	}
}