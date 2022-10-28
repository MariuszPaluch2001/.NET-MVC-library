using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System;
namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private static IList<BookModel> books = new List<BookModel>()
        {
            new BookModel(){
                id = 1,
                author = "Autor",
                title="title",
                date=2022,
                publisher="publisher",
            },
            new BookModel(){
                id = 2,
                author = "Autor2",
                title="title2",
                date=2022,
                publisher="publisher2",
            },
            new BookModel(){
                id = 3,
                author = "Autor3",
                title="title3",
                date=2022,
                publisher="publisher3",
            }
        };
        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault( x=> x.id == id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(new BookModel());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookModel bookModel)
        {
                bookModel.id = books.Count + 1;
                books.Add(bookModel);
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(books.FirstOrDefault(x => x.id == id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookModel bookModel)
        {
                BookModel book = books.FirstOrDefault(x => x.id == id);
                book.author = bookModel.author;
                book.publisher = bookModel.publisher;
                book.title = bookModel.title;
                book.date = bookModel.date;
                book.reserved = bookModel.reserved;
                book.leased = bookModel.leased;
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(books.FirstOrDefault(x => x.id == id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,BookModel bookModel)
        {
           BookModel book = books.FirstOrDefault(x => x.id == id);
           books.Remove(book);
           return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult EditDeleteList()
        {
            return View(books);
        }
        public ActionResult BooksToReserve()
        {
            return View(books);
        }
        public ActionResult Reserve(int id)
        {
            BookModel book = books.FirstOrDefault(x => x.id == id);
            book.reserved = DateTime.Today.Date;
            book.user = "UserTemporary";
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

        public ActionResult BooksToLease()
        {
            return View(books);
        }

        public ActionResult Lease(int id)
        {
            return View(books.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Lease(int id, BookModel bookModel)
        {
            BookModel book = books.FirstOrDefault(x => x.id == id);
            if (book.reserved is not null && bookModel.leased > DateTime.Today.Date)
            {
                book.leased = bookModel.leased;
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult BooksToReturn()
        {
            return View(books);
        }
        public ActionResult ReturnBook(int id)
        {
            BookModel book = books.FirstOrDefault(x => x.id == id);
            book.reserved = null;
            book.leased = null;
            book.user = null;
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult SearchBook(String? searching)
        {
            return View(books.Where(x => searching is null || x.title.Contains(searching)).ToList());
        }

    }
}
