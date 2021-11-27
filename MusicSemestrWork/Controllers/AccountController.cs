using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicSemestrWork.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSemestrWork.Controllers
{
    public class AccountController : Controller
    {
        readonly ApplicationContext db;
        readonly IConfiguration _configuration;

        public AccountController(ApplicationContext options, IConfiguration configuration)
        {
            _configuration = configuration;
            db = options;
        }
        // Registration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync<User>(u => u.Email == model.Email);

                if (user == null)
                {
                    var currentUser = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        Password = model.Password,
                        Username = model.Username
                    };
                    db.Users.Add(currentUser);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "user already exists");

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
        public async Task<IActionResult> Login(User model)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

            if(user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var token = GenerateJwtToken(user);

            if (token == null)
                return RedirectToAction("Login", "Account");
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

        private string GenerateJwtToken(User user)
        {
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            var claims = new Claim[] {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Username)
                };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: credentials);


            //var jwtToken = new JwtToken
            //{
            //    RefreshToken = new RefreshTokenGenerator().GenerateRefreshToken(32),
            //    Token = new JwtSecurityTokenHandler().WriteToken(token)
            //};

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
