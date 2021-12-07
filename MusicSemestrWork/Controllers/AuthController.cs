using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicSemestrWork.Interfaces;
using MusicSemestrWork.Models;
using MusicSemestrWork.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSemestrWork.Controllers
{
    public class AuthController : Controller
    {
        readonly ApplicationContext db;
        readonly IConfiguration _configuration;
        private JwtSecurityToken _token;
        private readonly IJWTAuthManager _jWTAuthManager;

        public AuthController(ApplicationContext options, IConfiguration configuration, IJWTAuthManager jWTAuthManager)
        {
            _configuration = configuration;
            db = options;
            _jWTAuthManager = jWTAuthManager;
        }
        // Registration
        [HttpGet]
        public IActionResult Register()
        {
            if (Request.Cookies["token"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user == null)
                {
                    var User = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        Password = model.Password,
                        Username = model.Username
                    };
                    db.Users.Add(User);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Login", "Auth");
                }
                else
                    return RedirectToAction("Login", "Auth");

            }
            return View(model);
        }

        // Login
        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["token"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var token = _jWTAuthManager.Authenticate(user);

            if (token == null)
                return RedirectToAction("Login", "Auth");
            else
            {
                Response.Cookies.Append("token", token);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            var token = Request.Cookies["token"];
            if (token == null)
                return RedirectToAction("Index", "Home");

            Response.Cookies.Delete("token");
            return RedirectToAction("Index", "Home");
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

            var CurrentId = _token.Claims.First(claim => claim.Type == "nameid").Value;

            var user = db.Users.FirstOrDefault(u => u.Id.ToString() == CurrentId);

            return user;
        }
    }
}
