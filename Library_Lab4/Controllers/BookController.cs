using Library_Lab4.Data;
using Library_Lab4.Models;
using Library_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Lab4.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) 
        { 
            _bookService=bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        public IActionResult SearchBooks(string key)
        {
            var book=_bookService.SearchBooks(key);
            return View("Index",book);
        }
    }
}
