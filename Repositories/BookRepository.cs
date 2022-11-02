using LibraryManagement.Models;
namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ManagerContext _context;
        public BookRepository(ManagerContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            book.bookAddTimestamp = System.DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            var result = _context.Books.SingleOrDefault(x => x.id == bookId);
            if (result is not null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }

        public Book GetBook(int bookId) 
            => _context.Books.SingleOrDefault(x => x.id == bookId);

        public Book GetBook(string title)
            => _context.Books.SingleOrDefault(x => x.title == title);

        public IList<Book> getBooks()
            => _context.Books.ToList();

        public void Update(int bookId, Book book)
        {
            var result = _context.Books.SingleOrDefault(x => x.id == bookId);
            if (result is not null)
            {
                result.author = book.author;
                result.publisher = book.publisher;
                result.title = book.title;
                result.date = book.date;
                result.reserved = book.reserved;
                result.leased = book.leased;
                _context.SaveChanges();
            }
        }

        public IList<Book> Searching(string? searching)
        {
                return _context.Books.Where( x => searching == null || x.title.Contains(searching)).ToList();
        }

        public void UndoReserve(int bookId)
        {
            Book? book = GetBook(bookId);
            book.user = null;
            book.user.books.Remove(book);
            book.reserved = null;
            _context.SaveChanges();
        }
        public void ReturnBook(int bookId)
        {
            Book? book = GetBook(bookId);
            book.reserved = null;
            book.leased = null;
            book.user = null;
            book.user.books.Remove(book);
            _context.SaveChanges();
        }

        public void ReserveBook(int bookId, User user)
        {
            Book book = GetBook(bookId);
            book.reserved = DateTime.Today.Date;
            book.user = user;
            _context.SaveChanges();
        }

        public IList<Book> GetReservedBooks(string? login)
        {
            return _context.Books.Where(x => x.user != null && x.user.login == login).ToList();
        }

        public void LeaseBook(int bookId, Book book)
        {
            var result = _context.Books.FirstOrDefault(x => x.id == bookId);
            if (result is not null && result.reserved is not null && book.leased > DateTime.Today.Date)
            {
                result.leased = book.leased;
                _context.SaveChanges();
            }
        }
    }
}
