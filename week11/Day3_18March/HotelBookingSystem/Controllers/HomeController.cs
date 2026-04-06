using System.Diagnostics;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalRooms = _context.Rooms.Count();
            ViewBag.TotalBookings = _context.Bookings.Count();
            return View();
        }
    }
}
