using Microsoft.AspNetCore.Mvc;
using HotelBookingSystem.Models;
using System.Linq;

namespace HotelBookingSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Rooms.ToList();
            return View("Index", model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
