using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context db = new Context();
        public ActionResult Index()
        {
            var value1 = db.Currents.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = db.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = db.Employees.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = db.Categories.Count().ToString();
            ViewBag.d4 = value4;

            var value5 = db.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = value5;

            var value6 = (from x in db.Products select x.Branch).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value7 = db.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = value7;
            var value8 = (from x in db.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in db.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;


            var value10 = db.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = value10;

            var value11 = db.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = value11;

            var value12 = db.Products.GroupBy(x => x.Branch).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = value12;

            var value13 = db.Products.Where(p => p.ProductID == (db.SalesMovements.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;

            var value14 = db.SalesMovements.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = value14;

            DateTime today = DateTime.Today;
            var value15 = db.SalesMovements.Count(x => x.Date == today).ToString();
            ViewBag.d15 = value15;

            var value16 = db.SalesMovements.Where(x => x.Date == today).Sum(y => (decimal?)y.TotalPrice).ToString();

            ViewBag.d16 = (!string.IsNullOrEmpty(value16) ? value16 : "0.00");
            return View();
        }


        public ActionResult SimplesTables()
        {
            var query = from x in db.Currents
                        group x by x.CurrentCity into g
                        select new SimpleGrup
                        {
                            City = g.Key,
                            Count = g.Count()

                        };
            return View(query.ToList());
        }



        public ActionResult PartialOne()
        {
            var query2 = (from x in db.Employees
                          group x by x.Department.DepartmentName into g
                          select new SimpleGrup2
                          {
                              Department = g.Key,
                              Count = g.Count(),
                          }).ToList();
            return PartialView("_PartialOne", query2);
        }

        public ActionResult PartialTwo()
        {
            var query = db.Currents.ToList();
            return PartialView("_PartialTwo", query);
        }
        public ActionResult PartialThree()
        {
            var query = db.Products.ToList();
            return PartialView("_PartialThree", query);
        }

        public ActionResult PartialFour()
        {
            var query = (from x in db.Products
                         group x by x.Branch into g
                         select new SimpleGrup3
                         {
                             Branch = g.Key,
                             Count = g.Count(),
                         }).ToList();
            return PartialView("_PartialFour", query);
        }
    }
}