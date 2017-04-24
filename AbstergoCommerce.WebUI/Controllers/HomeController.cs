using AbstergoCommerce.WebUI.App_Class;
using AbstergoCommerce.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace AbstergoCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index() => View();

        public PartialViewResult Cart()
        {
            if (HttpContext.Session["ActiveCart"] != null)
                return PartialView((Cart)HttpContext.Session["ActiveCart"]);
            else
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

        public PartialViewResult Services() => PartialView();


        public PartialViewResult Brands()
        {
            var data = db.Brands.ToList();
            return PartialView(data);
        }

        public void AddtoCart(int id)
        {
            CartItem ci = new CartItem();
            Product p = db.Products.FirstOrDefault(x => x.Id == id);

            ci.Product = p;
            ci.Item = 1;
            ci.Discount = 0;
            Cart c = new Cart();
            c.AddtoCart(ci);


        }

        public ActionResult ProductDetail()
        {
            return View();
        }

        public void DeleteFromCart(int id)
        {
            if (HttpContext.Session["ActiveCart"] != null)
            {
                App_Class.Cart c = (App_Class.Cart)HttpContext.Session["ActiveCart"];

                if (c.Products.FirstOrDefault(x => x.Product.Id == id).Item > 1)
                {
                    c.Products.FirstOrDefault(x => x.Product.Id == id).Item--;
                }
                else
                {
                    CartItem ci = c.Products.FirstOrDefault(x => x.Product.Id == id);
                    c.Products.Remove(ci);
                }


            }
        }
    }
}