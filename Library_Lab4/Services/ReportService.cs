using Library_Lab4.Data;
using Library_Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Lab4.Services
{
    public class ReportService:IReportService
    {
        private readonly LibraryContext _context;

        public ReportService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetTransactionsByMember(int memberId)
        {
            return _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .Where(t => t.MemberId == memberId && t is BorrowTransaction)
                .ToList();
        }
        public IEnumerable<Transaction> GetAllBorrowedBooks()
        {
            return _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .Where(t => t is BorrowTransaction)
                .ToList();
        }
    }
}
