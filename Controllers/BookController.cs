using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

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
                user="",
                reserved="2022-10-12",
                leased =""
            },
            new BookModel(){
                id = 2,
                author = "Autor2",
                title="title2",
                date=2022,
                publisher="publisher2",
                user="",
                reserved="2022-10-12",
                leased =""
            },
            new BookModel(){
                id = 3,
                author = "Autor3",
                title="title3",
                date=2022,
                publisher="publisher3",
                user="",
                reserved="2022-10-12",
                leased =""
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
            return View();
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
                return RedirectToAction(nameof(Index));

        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
