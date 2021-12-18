using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicSemestrWork.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSemestrWork.Controllers
{
    public class PostController : Controller
    {
        readonly ApplicationContext db;
        public PostController(ApplicationContext options)
        {
            db = options;

        }

        [HttpGet]
        public IActionResult Post(int id)
        {
            var post = db.Posts.Where(x => x.Id == id).FirstOrDefault();
            return View(post);
        }
    }
}
