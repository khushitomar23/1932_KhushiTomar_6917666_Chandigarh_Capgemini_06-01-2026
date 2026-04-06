using Microsoft.AspNetCore.Mvc;
using UniversityManagement;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityDbContext _context;

        public StudentController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        // POST: Student/Edit
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        // POST: Student/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
    }
}