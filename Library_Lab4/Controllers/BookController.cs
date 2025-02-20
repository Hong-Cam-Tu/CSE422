using Library_Lab4.Data;
using Library_Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Lab4.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public IActionResult Index()
        {
            var list = _context.Books.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
