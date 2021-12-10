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

namespace MusicSemestrWork.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationContext db;
        public IEnumerable<Post> Posts { get => db.Posts; }
        readonly IConfiguration _configuration;
        public User CurrentUser { get => GetUser(); }
        private JwtSecurityToken _token;

        public HomeController(ApplicationContext options, IConfiguration configuration)
        {
            _configuration = configuration;
            db = options;

        }
        
        public IActionResult Index()
        {
            //Response.Cookies.Delete("token");
            return View();
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

            ViewBag.ShowTopBar = false;

            return user;
        }
    }
}
