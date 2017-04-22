using System.Web.Mvc;

namespace AbstergoCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Cart()
        {
            return PartialView();
        }

        public ActionResult Categories()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult About()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Contact()
        {
            throw new System.NotImplementedException();
        }

        public PartialViewResult Slider()
        {
            return PartialView();
        }

        public PartialViewResult NewProducts()
        {
            return PartialView();
        }

        public PartialViewResult Services()
        {
            return PartialView();
        }

        public PartialViewResult Fashion()
        {
            return PartialView();
        }

        public PartialViewResult Brands()
        {
            return PartialView();
        }
    }
}