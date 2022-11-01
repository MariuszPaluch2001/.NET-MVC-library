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
            if (user.login is not null)
            {
                HttpContext.Session.SetString("login", login);
                HttpContext.Session.SetString("isSuperUser", user.isSuperUser ? "true" : "false");
                return RedirectToAction(nameof(Welcome));
            }
            else
            {
                ViewBag.msg = "Invalid";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
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
                HttpContext.Session.SetString("login", login);
                HttpContext.Session.SetString("isSuperUser", user.isSuperUser ? "true" : "false");
            }
            else
            {
                ViewBag.msg = "Invalid";
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
                userRepository.Delete(userRepository.GetUser(login).UserID);
                HttpContext.Session.Clear();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
 
        }
        public ActionResult Welcome()
        {
            return View();
        }


    }
}
