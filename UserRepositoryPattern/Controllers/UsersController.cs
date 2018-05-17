using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UserApp.Core;
using UserApp.Infrastructure;
using UserRepositoryPattern.ViewModels;

namespace UserRepositoryPattern.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository<User> db = new UserRepository<User>();

        public ActionResult Index()
        {
            return View(db.GetUsers());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.FindById(model => model.UserID == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MainPage = "User Management";
            ViewBag.SubPage = "Add User";

            UserViewModel userViewModel = new UserViewModel();
            using (UserContext dataBase = new UserContext())
            {
                userViewModel.RoleList = dataBase.Roles.ToList<Role>();
                userViewModel.GenderList = dataBase.Gender.ToList<Gender>();
            }
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,PhoneNo,Email,Username,Password,Dob,RoleID,GenderID,UserStatus")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                db.Add(user.UserAdd);
                
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            ViewBag.MainPage = "User Management";
            ViewBag.SubPage = "Edit User";

            UserViewModel userViewModel = new UserViewModel();
            using (UserContext dataBase = new UserContext())
            {
                userViewModel.RoleList = dataBase.Roles.ToList<Role>();
                userViewModel.GenderList = dataBase.Gender.ToList<Gender>();
            }
            return View(userViewModel);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.FindById(model => model.RoleID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.FindById(model => model.UserID == id);

            return RedirectToAction("Index");
        }
    }
}