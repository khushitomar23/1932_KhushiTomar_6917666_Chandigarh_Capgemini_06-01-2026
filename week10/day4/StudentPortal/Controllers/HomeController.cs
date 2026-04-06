using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using Microsoft.AspNetCore.Http;

namespace StudentPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var students = new List<string>(); // populate from service/db, or leave empty
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("User", username);

            return RedirectToAction("Dashboard", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}