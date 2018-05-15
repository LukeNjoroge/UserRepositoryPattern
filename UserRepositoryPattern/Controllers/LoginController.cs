using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserApp.Infrastructure;
using UserRepositoryPattern.Models;

namespace UserRepositoryPattern.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly UserAuthentification _authentification;
        public LoginController(UserAuthentification authentification)
        {
            _authentification = authentification;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginViewModel loginViewModel, string returnurl)
        {
            if(ModelState.IsValid)
            {
                if(_authentification.CheckLogin(loginViewModel.Username, loginViewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.Username, false);
                    return Redirect(returnurl ?? Url.Action("Index", "Home"));
                }
                ModelState.AddModelError("", "Incorect Username or Password");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}