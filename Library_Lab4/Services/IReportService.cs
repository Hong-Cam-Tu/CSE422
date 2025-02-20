using Library_Lab4.Models;

namespace Library_Lab4.Services
{
    public interface IReportService
    {
        IEnumerable<Transaction> GetTransactionsByMember(int memberId);
        IEnumerable<Transaction> GetAllBorrowedBooks();
    }
}
