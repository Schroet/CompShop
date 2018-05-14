using CompShop.Domain.Abstract;
using CompShop.Domain.Entities;
using CompStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAuthentication authentication;
        IUserRepository repository;

        public AccountController(IAuthentication authentication, IUserRepository repo)
        {
            this.authentication = authentication;
            repository = repo;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authentication.Authenticate(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Success", "Account"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

       // [AllowAnonymous]
        public ActionResult Success()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Create()
        {
            return View(new User());
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(User user)
        {
            repository.SaveUser(user);
            TempData["message"] = string.Format("{0} has been saved", user.UserId);
            return RedirectToAction("Success", "Account");
        }

    }
}