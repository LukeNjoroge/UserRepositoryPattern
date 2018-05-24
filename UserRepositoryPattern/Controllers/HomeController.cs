using System.Web.Mvc;
using UserApp.Core;
using UserRepositoryPattern.DAL;

namespace UserRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private Repository<User> _repository = new Repository<User>();

        public ActionResult Index()
        {
            return View(_repository.Get());
        }
    }
}