using Microsoft.AspNetCore.Mvc;
using Middleware_Request_Tracking.Services;

namespace Middleware_Request_Tracking.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRequestLogService _logService;

        public StudentsController(IRequestLogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            var students = new List<string>
    {
        "Rahul",
        "Anita",
        "Karan"
    };

            ViewBag.Logs = _logService.GetLogs();

            return View(students);
        }
    }
}
