﻿using LibraryManagement.Models;
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
            UserModel user = userService.Login(login, password);
            if (user != null)
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
        public ActionResult DeleteAccount(string login)
        {
            return View(userService.getUsers().FirstOrDefault(x => x.login == login));
        }
        [HttpPost]
        public ActionResult DeleteAccount(string login, UserModel user)
        {
            
            if (userService.DeleteAccount(HttpContext.Session.GetString("login")))
            {
                HttpContext.Session.Clear();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
                return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }


    }
}
