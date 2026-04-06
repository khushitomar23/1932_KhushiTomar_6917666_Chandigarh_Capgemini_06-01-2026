using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}