using System.Web.Mvc;

namespace AbstergoCommerce.WebUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Login()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Logout()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Register()
        {
            throw new System.NotImplementedException();
        }
    }
}