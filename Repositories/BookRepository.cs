using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Add(BookModel user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int bookId)
        {
            throw new NotImplementedException();
        }

        public BookModel GetBook(int book)
        {
            throw new NotImplementedException();
        }

        public BookModel GetBook(string title)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BookModel> getBooks()
        {
            throw new NotImplementedException();
        }

        public void Update(int bookId, BookModel book)
        {
            throw new NotImplementedException();
        }
    }
}
