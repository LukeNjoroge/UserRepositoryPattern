using System;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using UserApp.Core;
using UserApp.Infrastructure;

namespace UserRepositoryPattern.Content
{
    public class UsersController : Controller
    {
        private UserRepository<User> db = new UserRepository<User>();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.GetUsers());
        }

       /* // GET: Users/Details/5
       public ActionResult Details(int? UserID)
        {
            if (UserID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.FindById(Convert.ToInt32(id));
            var user = db.FindById(predicate: Expression<Func<User, bool>> UserID);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }*/

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,PhoneNo,Email,Dob,RoleID,GenderID,UserStatus")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        /* public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.FindById(Convert.ToBoolean(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FullName,PhoneNo,Email,Dob,RoleID,GenderID,UserStatus")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.FindById(Convert.ToBoolean(id));
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
            User user = db.FindById(Convert.ToBoolean(id));
            db.Remove(Convert.ToBoolean(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
