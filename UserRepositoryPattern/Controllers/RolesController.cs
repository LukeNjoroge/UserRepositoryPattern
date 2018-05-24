using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using UserApp.Core;
using UserRepositoryPattern.DAL;
using UserRepositoryPattern.ViewModels;

namespace UserRepositoryPattern.Controllers
{
    public class RolesController : Controller
    {
        private Repository<Role> db = new Repository<Role>();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Get());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var roles = db.FindById(model => model.RoleID == id);

            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleName,RoleStatus")] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Add(role);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = new Role();
            
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleName,RoleStatus")] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Edit(role);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roles = db.FindById(model => model.RoleID == id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var roles = db.FindById(model => model.RoleID == id);

            return RedirectToAction("Index");
        }
    }
}
