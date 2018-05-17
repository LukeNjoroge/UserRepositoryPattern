using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApp.core;
using UserApp.Core;
using UserApp.Infrastructure;
using UserRepositoryPattern.Models;

namespace UserRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository<User> _repository = new UserRepository<User>();

        public ActionResult Index()
        {
            return View(_repository.GetUsers());
        }
    }
}