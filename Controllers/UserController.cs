using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace LibraryManagement.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        public ActionResult Index()
        {
            return View(userService.getUsers());
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string login, string password, string password_repeat)
        {
            UserModel user = userService.Register(login, password, password_repeat);
            if (user != null)
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            UserModel user = userService.Login(login, password);
            if (user != null)
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
        public ActionResult Welcome()
        {
            return View();
        }


    }
}
