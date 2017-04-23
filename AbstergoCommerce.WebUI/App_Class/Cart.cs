using AbstergoCommerce.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbstergoCommerce.WebUI.App_Class
{
    public class Cart
    {
        public static Cart ActiveCart
        {
            get
            {
                HttpContext ctx = HttpContext.Current;
                if (ctx.Session["ActiveCart"] == null)
                    ctx.Session["ActiveCart"] = new Cart();

                return (Cart)ctx.Session["ActiveCart"];

            }
        }

        public List<CartItem> products = new List<CartItem>();

        public List<CartItem> Products
        {
            get { return products; }
            set { products = value; }
        }

        public void AddtoCart(CartItem ci)
        {
            if (Products.Any(x => x.Product.Id == ci.Product.Id))
                Products.FirstOrDefault(x => x.Product.Id == ci.Product.Id).Item++;
            else
                Products.Add(ci);
        }

        public decimal TotalAmount => Products.Sum(x => x.Total);
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Item { get; set; }
        public double Discount { get; set; }

        public decimal Total => Product.Price * Item * (decimal)(1 - Discount);
    }
}