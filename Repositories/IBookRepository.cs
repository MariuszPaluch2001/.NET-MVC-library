using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        BookModel GetBook(int book);
        BookModel GetBook(string title);
        IQueryable<BookModel> getBooks();
        void Add(BookModel user);
        void Update(int bookId, BookModel book);
        void Delete(int bookId);
    }
}
