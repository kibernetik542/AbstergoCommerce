using AbstergoCommerce.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace AbstergoCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
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
            var data = db.Images.Where(x => x.BigUrl.Contains("Slider")).ToList();
            return PartialView(data);
        }

        public PartialViewResult NewProducts()
        {
            var data = db.Products.ToList();
            return PartialView(data);
        }

        public PartialViewResult Services()
        {
            return PartialView();
        }



        public PartialViewResult Brands()
        {
            var data = db.Brands.ToList();
            return PartialView(data);
        }


    }
}