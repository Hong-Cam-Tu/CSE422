using Library_Lab4.Data;
using Library_Lab4.Models;
using Microsoft.EntityFrameworkCore;


namespace Library_Lab4.Services
{
    public class TransactionService:ITransactionService
    {
        private readonly LibraryContext _context;

        public TransactionService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.Member).Include(t => t.Book).ToList();
        }

        public void BorrowBook(int memberId, int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null || book.Quantity <= 0) return;

            var transaction = new BorrowTransaction
            {
                BookId = bookId,
                MemberId = memberId,
                TransactionDate = DateTime.Now,
                Book = book
            };

            transaction.Execute();
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void ReturnBook(int memberId, int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null) return;

            var transaction = new ReturnTransaction
            {
                BookId = bookId,
                MemberId = memberId,
                TransactionDate = DateTime.Now,
                Book = book
            };

            transaction.Execute();
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
