using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly UniversityDbContext _context;

        public EnrollmentController(UniversityDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Enrollments.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        public IActionResult Edit(int id)
        {
            var enroll = _context.Enrollments.Find(id);
            return View(enroll);
        }

        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var enroll = _context.Enrollments.Find(id);
            return View(enroll);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var enroll = _context.Enrollments.Find(id);
            _context.Enrollments.Remove(enroll);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var enroll = _context.Enrollments.Find(id);
            return View(enroll);
        }
    }
}