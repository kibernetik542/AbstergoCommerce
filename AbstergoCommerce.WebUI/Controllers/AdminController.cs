using AbstergoCommerce.WebUI.Models;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Image = System.Drawing.Image;

namespace AbstergoCommerce.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Products");
        }

        public ActionResult Brands()
        {
            return View(db.Brands.ToList());
        }

        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand brand, HttpPostedFileBase fileUpload)
        {
            int imgId = -1;
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["BrandWidth"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["BrandHeight"].ToString());

                string name = "/Content/BrandImage/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                Bitmap bmp = new Bitmap(img, width, height);
                bmp.Save(Server.MapPath(name));

                Models.Image pic = new Models.Image();
                pic.MedUrl = name;
                db.Images.Add(pic);
                db.SaveChanges();
                if (pic.Id != null)
                    imgId = pic.Id;
            }
            if (imgId != -1)
                brand.ImageID = imgId;
            db.Brands.Add(brand);
            db.SaveChanges();

            return RedirectToAction("Brands");
        }

        public ActionResult Categories()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        public ActionResult SpecTypes()
        {
            return View(db.SpecificationTypes.ToList());
        }

        public ActionResult SpecTypeCreate()
        {
            return View(db.Categories.ToList());
        }

        [HttpPost]
        public ActionResult SpecTypeCreate(SpecificationType type)
        {
            db.SpecificationTypes.Add(type);
            db.SaveChanges();
            return RedirectToAction("SpecTypes");

        }

        public ActionResult Specifications()
        {
            return View(db.Specifications.ToList());
        }

        public ActionResult SpecificationCreate()
        {
            return View(db.SpecificationTypes.ToList());
        }

        [HttpPost]
        public ActionResult SpecificationCreate(Specification spec)
        {
            db.Specifications.Add(spec);
            db.SaveChanges();
            return RedirectToAction("Specifications");
        }

        public ActionResult ProductSpecifications()
        {
            return View(db.ProductSpecifications.ToList());
        }

        public ActionResult ProductSpecDelete(int productId, int typeId, int specId)
        {
            ProductSpecification ps = db.ProductSpecifications
                .FirstOrDefault(x => x.ProductID == productId
                                     && x.SpecTypeID == typeId && x.SpecificationID == specId);

            db.ProductSpecifications.Remove(ps);
            db.SaveChanges();
            return RedirectToAction("ProductSpecifications");
        }

        public ActionResult ProductSpecCreate()
        {
            return View(db.Products.ToList());
        }

        public PartialViewResult ProductSpecTypeWidget(int? catId)
        {
            if (catId != null)
            {
                var data = db.SpecificationTypes.Where(x => x.CategoryID == catId).ToList();
                return PartialView(data);
            }
            else
            {
                var data = db.SpecificationTypes.ToList();
                return PartialView(data);
            }
        }

        public PartialViewResult ProdutSpecWidget(int? typeId)
        {
            if (typeId != null)
            {
                var data = db.Specifications.Where(x => x.SpecTypeID == typeId);
                return PartialView(data);
            }
            else
            {
                var data = db.Specifications.ToList();
                return PartialView(data);
            }
        }

        [HttpPost]
        public ActionResult ProductSpecCreate(ProductSpecification ps)
        {
            db.ProductSpecifications.Add(ps);
            db.SaveChanges();
            return RedirectToAction("ProductSpecifications");
        }


    }
}