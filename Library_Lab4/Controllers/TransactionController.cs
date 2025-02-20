using Library_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Lab4.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;

        public TransactionController(ITransactionService transactionService, IMemberService memberService, IBookService bookService)
        {
            _transactionService = transactionService;
            _memberService = memberService;
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View(_transactionService.GetAllTransactions());
        }

        public IActionResult Borrow() 
        {
            ViewBag.Members = new SelectList(_memberService.GetAllMembers(), "Id", "Name");
            ViewBag.Books = new SelectList(_memberService.GetAllMembers(), "Id", "Title");

            return View();
        }

        [HttpPost]
        public IActionResult Borrow(int memberID, int bookID)
        {
            _transactionService.BorrowBook(memberID, bookID);
            return RedirectToAction("Index");
        }

        public IActionResult Return()
        {
            ViewBag.Members = new SelectList(_memberService.GetAllMembers(), "Id", "Name");
            ViewBag.Books = new SelectList(_memberService.GetAllMembers(), "Id", "Title");

            return View();
        }
        [HttpPost]
        public IActionResult Return(int memberID, int bookID)
        {
            _transactionService.ReturnBook(memberID, bookID);
            return RedirectToAction("Index");
        }
    }
}
