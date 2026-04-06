using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var students = new List<string>
            {
                "Khushi",
                "Diksha",
                "Chitransh"
            };

            return View(students);
        }
    }
}