using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context db = new Context();
        public ActionResult Index()
        {
            ProductDetailViewModel model = new ProductDetailViewModel();
            model.products = db.Products.Where(x => x.ProductID == 1).ToList();
            model.productDetails = db.ProductDetails.Where(x => x.DetailID == 1).ToList();
            return View(model);
        }
    }
}