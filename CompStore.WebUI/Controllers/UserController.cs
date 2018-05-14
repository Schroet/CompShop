using CompShop.Domain.Abstract;
using CompShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompStore.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        IUserRepository repository;

        public UserController(IUserRepository repo)
        {
            repository = repo;
        }

       // [AllowAnonymous]
        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            repository.SaveUser(user);
            TempData["message"] = string.Format("{0} has been saved", user.UserId);
            return RedirectToAction("Success", "Account");
        }
    }
}