using System.Linq;
using System.Web.Mvc;
using UserApp.Core;
using UserApp.Infrastructure;

namespace UserRepositoryPattern.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            using (UserContext db = new UserContext())
            {
                var usr = db.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Wrong");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}