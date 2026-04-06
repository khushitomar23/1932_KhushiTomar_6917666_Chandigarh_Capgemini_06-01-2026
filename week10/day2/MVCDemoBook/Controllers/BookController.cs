using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemoBook.Models;

namespace MVCDemoBook.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;

        // Constructor Injection
        public BookController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.books.ToList();
            return View(books);
        }

        // GET: BookController/Details/5
        public IActionResult Details(int id)
        {
            var book = _context.books.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel book)
        {
            try
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(book);
            }
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookModel book)
        {
            if (id != book.BookModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookModelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.books.Find(id);
            _context.books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.books.Any(e => e.BookModelId == id);
        }
    }
}