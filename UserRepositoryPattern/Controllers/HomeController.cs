using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApp.core;
using UserApp.Core;

namespace UserRepositoryPattern.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserLoginRepository _repository;

        public HomeController(IUserLoginRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(_repository.GetUsers());
        }
    }
}