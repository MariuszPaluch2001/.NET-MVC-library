using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            book.BookAddTimestamp = System.DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            var result = _context.Books.SingleOrDefault(x => x.BookId == bookId);
            if (result is not null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }

        public Book? GetBook(int bookId) 
            => _context.Books.SingleOrDefault(x => x.BookId == bookId);

        public Book? GetBook(string title)
            => _context.Books.SingleOrDefault(x => x.Title == title);

        public IList<Book> getBooks()
            => _context.Books.ToList();

        public void Update(int bookId, Book? book)
        {
            var result = GetBook(bookId);
            if (book is not null && result is not null)
            {
                result.Author = book.Author;
                result.Publisher = book.Publisher;
                result.Title = book.Title;
                result.Date = book.Date;
                result.Reserved = book.Reserved;
                result.Leased = book.Leased;
                var entry = _context.Entry(result);
                entry.OriginalValues["TimeStamp"] = book.TimeStamp;
                _context.Update(result);
                _context.SaveChanges();
            }
        }

        public IList<Book> Searching(string? searching)
        {
                return _context.Books.Where( x => searching == null || x.Title.Contains(searching)).ToList();
        }

        public void UndoReserve(int bookId)
        {
            Book? book = GetBook(bookId);
            if (book is not null &&
                book.user is not null && 
                book.user.Books is not null
            )
            {
                book.user.Books.Remove(book);
                book.Reserved = null;
                book.user = null;
                _context.SaveChanges();
            }
        }
        public void ReturnBook(int bookId)
        {
            Book? book = GetBook(bookId);
            if (book is not null && 
                book.user is not null && 
                book.user.Books is not null
            )
            {
                book.user.Books.Remove(book);
                book.Reserved = null;
                book.Leased = null;
                book.user = null;
                _context.SaveChanges();
            }
        }

        public void ReserveBook(int bookId, User? user, byte[] timestamp)
        {
            Book? book = GetBook(bookId);
            if (book is not null)
            {
                book.Reserved = DateTime.Today.Date;
                book.user = user;
                var entry = _context.Entry(book);
                entry.OriginalValues["TimeStamp"] = timestamp;
                entry.CurrentValues.SetValues(book);
                _context.Update(book);
                _context.SaveChanges();
            }
        }

        public IList<Book> GetReservedBooks(string? login)
        {
            return _context.Books.Where(x => x.user != null && x.user.Login == login).ToList();
        }

        public void LeaseBook(int bookId, Book? book)
        {
            var result = _context.Books.FirstOrDefault(x => x.BookId == bookId);
            if (result is not null && 
                result.Reserved is not null && 
                book is not null && 
                book.Leased > DateTime.Today.Date)
            {
                result.Leased = book.Leased;
                _context.SaveChanges();
            }
        }
    }
}
