using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordHashing.Models;

namespace PasswordHashing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPasswordHasher<User> passwordHasher;

        public HomeController(IPasswordHasher<User> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string password, IFormCollection collection)
        {
            var user = new User();

            ViewBag.Hash = passwordHasher.HashPassword(user, password);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validate(string hash, string password)
        {
            var user = new User();

            ViewBag.HashResult = passwordHasher.VerifyHashedPassword(user,hash, password);
            return View("Index");
        }

    }
}