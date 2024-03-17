using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab07_3.Models;

namespace lab07_3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.Email, model.Password);
            if (result && ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            else
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
            }
            return View(model);
        }
    }
}