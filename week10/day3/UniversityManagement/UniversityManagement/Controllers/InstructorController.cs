using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class InstructorController : Controller
    {
        private readonly UniversityDbContext _context;

        public InstructorController(UniversityDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Instructors.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            var inst = _context.Instructors.Find(id);
            return View(inst);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var inst = _context.Instructors.Find(id);
            return View(inst);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var inst = _context.Instructors.Find(id);
            _context.Instructors.Remove(inst);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var inst = _context.Instructors.Find(id);
            return View(inst);
        }
    }
}