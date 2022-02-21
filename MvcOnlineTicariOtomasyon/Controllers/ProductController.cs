using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Context db = new Context();
        public ActionResult Index(string p)
        {
            var products = from x in db.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.ProductName.Contains(p));

            }
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> categoryList = (from x in db.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString(),
                                                 }).ToList();

            ViewBag.CategoryList = categoryList;

            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductDelete(int id)
        {
            var value = db.Products.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductGet(int id)
        {
            List<SelectListItem> categoryList = (from x in db.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString(),
                                                 }).ToList();

            ViewBag.CategoryList = categoryList;

            var product = db.Products.Find(id);
            return View("ProductGet", product);
        }

        public ActionResult ProductUpdate(Products products)
        {
            var product = db.Products.Find(products.ProductID);
            product.ProductName = products.ProductName;
            product.Branch = products.Branch;
            product.Stock = products.Stock;
            product.Status = products.Status;
            product.SalePrice = products.SalePrice;
            product.PurchasePrice = products.PurchasePrice;
            product.ProductImage = products.ProductImage;
            product.CategoryId = products.CategoryId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var list = db.Products.ToList();
            return View(list);
        }

        /// <summary>
        /// Satış Yap
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SellProduct(int id)
        {

            List<SelectListItem> employees = (from x in db.Employees.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeName + x.EmployeeSurname,
                                                  Value = x.EmployeeID.ToString()
                                              }).ToList();
            ViewBag.employeeList = employees;
            var getProduct = db.Products.Find(id);
            ViewBag.productID = getProduct.ProductID;
            ViewBag.SalePrice = getProduct.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult SellProduct(SalesMovements sell)
        {
            sell.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SalesMovements.Add(sell);
            db.SaveChanges();
            return RedirectToAction("Index","Sales");
        }
    }
}