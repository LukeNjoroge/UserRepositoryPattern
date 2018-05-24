using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UserApp.Core;
using UserApp.Infrastructure;
using UserRepositoryPattern.DAL;
using UserRepositoryPattern.ViewModels;

namespace UserRepositoryPattern.Controllers
{
    public class UsersController : Controller
    {
        private Repository<User> db = new Repository<User>();

        public ActionResult Index()
        {
            return View(db.Get());
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
        public ActionResult Create([Bind(Include = "UserID,FullName,PhoneNo,Email,Username,Password,Dob,RoleID,GenderID,UserStatus")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Add(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
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

        public ActionResult Edit([Bind(Include = "UserID,FullName,PhoneNo,Email,Username,Password,Dob,RoleID,GenderID,UserStatus")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Edit(user);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
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