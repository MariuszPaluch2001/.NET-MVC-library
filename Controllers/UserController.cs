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

        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(string username, string password)
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string login, string password)
        {
            UserModel user = userService.Login(login, password);
            if (user != null)
            {
                HttpContext.Session.SetString("login", login);
                return RedirectToAction(nameof(welcome));
            }
            else
            {
                ViewBag.msg = "Invalid";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public ActionResult welcome()
        {
            return View();
        }


    }
}
