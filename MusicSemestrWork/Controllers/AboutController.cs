using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusicSemestrWork.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Developers()
        {
            return View();
        }

        public ActionResult GetMessage()
        {
            return PartialView("_GetMessage");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
