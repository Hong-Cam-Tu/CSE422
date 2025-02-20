using Library_Lab4.Models;

namespace Library_Lab4.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        void BorrowBook(int memberId, int bookId);
        void ReturnBook(int memberId, int bookId);
    }
}
