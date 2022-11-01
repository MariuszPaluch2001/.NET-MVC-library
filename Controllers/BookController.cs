using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System;
using LibraryManagement.Services;
using LibraryManagement.Repositories;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {

        private IUserRepository userRepository;
        private IBookRepository bookRepository;
        public BookController(IBookRepository _bookRepository, IUserRepository _userRepository)
        {
            bookRepository = _bookRepository;
            userRepository = _userRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(bookRepository.getBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bookModel)
        {
                bookRepository.Add(bookModel);
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book bookModel)
        {
                bookRepository.Update(id, bookModel);
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book bookModel)
        {
            bookRepository.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult EditDeleteList()
        {
            return View(bookRepository.getBooks());
        }
        public ActionResult BooksToReserve()
        {
            return View(bookRepository.getBooks());
        }
        public ActionResult Reserve(int id)
        { 

            string? login = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(login))
            {
                User user = userRepository.GetUser(login);
                bookRepository.ReserveBook(id, user);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
                return View();

        }

        public ActionResult BooksToLease()
        {
            return View(bookRepository.getBooks());
        }

        public ActionResult Lease(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Lease(int id, Book bookModel)
        {

            bookRepository.LeaseBook(id, bookModel);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult BooksToReturn()
        {
            return View(bookRepository.getBooks());
        }
        public ActionResult ReturnBook(int id)
        {
            bookRepository.ReturnBook(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult SearchBook(string? searching)
        {
            return View(bookRepository.Searching(searching));
        }

        public ActionResult UserReservedBooks()
        {
             string? login = HttpContext.Session.GetString("login");
             return View(bookRepository.GetReservedBooks(login));
        }
        public ActionResult UndoReserve(int id)
        {
            bookRepository.UndoReserve(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
