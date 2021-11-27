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
        readonly IConfiguration _configuration;

        public HomeController(ApplicationContext options, IConfiguration configuration)
        {
            _configuration = configuration;
            db = options;
        }

        public IActionResult Index()
        {
            var currentUser = HttpContext.User;
            if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
            {
                return View(null);
            }

            var stream = Request.Cookies["token"];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            var id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;

            var user = db.Users.FirstOrDefault(u => u.Id.ToString() == id);

            return View(user);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
