using Library_Lab4.Data;
using Library_Lab4.Models;

namespace Library_Lab4.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges(); 
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public IEnumerable<Book> SearchBooks(string keyword)
        {
            return _context.Books.Where(b=>b.Title.Contains(keyword) || b.Author.Contains(keyword)).ToList();
        }
    }
}

