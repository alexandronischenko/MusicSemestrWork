using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSemestrWork.Controllers
{
    public class GenreController : Controller
    {
        readonly ApplicationContext db;
        public GenreController(ApplicationContext options)
        {
            db = options;

        }
        [HttpGet]
        public IActionResult Genre(int id)
        {
            var genre = db.Genres.Where(x => x.Id == id).FirstOrDefault();
            return View(genre);
        }
    }
}
