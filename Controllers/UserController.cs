using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Web;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Controllers
{ 
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private UserService userService;

        public UserController(UserService _userService, IUserRepository _userRepository)
        {
            userService = _userService;
            userRepository = _userRepository;
        }

        public ActionResult Index()
        {
            return View(userRepository.getUsers());
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string login, string password, string password_repeat)
        {
            User user = userService.Register(login, password, password_repeat);
            if (user.Login is not null)
            {
                TempData["Message"] = "Zostałeś zarejestrowany.";
                HttpContext.Session.SetString("login", login);
                HttpContext.Session.SetString("isSuperUser", user.IsSuperUser ? "true" : "false");

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                TempData["MessageErr"] = "Rejestracja nie powiodła się.";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Zostałeś wylogowany.";
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            User user = userService.Login(login, password);
            if (user is not null)
            {
                TempData["Message"] = "Zostałeś zalogowany.";
                HttpContext.Session.SetString("login", login);
                HttpContext.Session.SetString("isSuperUser", user.IsSuperUser ? "true" : "false");
            }
            else
            {
                TempData["MessageErr"] = "Logowanie nie powiodło się.";
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public ActionResult DeleteAccountView()
        {
            return View();
        }

        public ActionResult DeleteAccount()
        {


            string? login = HttpContext.Session.GetString("login");
            if (!string.IsNullOrEmpty(login))
            {
                User user = userRepository.GetUser(login);
                if (user.Books.Count() == 0)
                {
                    TempData["Message"] = "Konto zostało usunięte.";
                    userRepository.Delete(userRepository.GetUser(login).UserID);
                    HttpContext.Session.Clear();
                }
                else
                {
                    TempData["MessageErr"] = "Nie można usunąć konta, bo są do niego przypisane książki.";
                }
            }
            else
            {
                TempData["MessageErr"] = "Nie udało się usunąć konta.";
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
 
        }


    }
}
