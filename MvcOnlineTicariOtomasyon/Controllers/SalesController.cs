using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.SalesMovements.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            List<SelectListItem> products = (from x in db.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductID.ToString()
                                             }).ToList();
            List<SelectListItem> currents = (from x in db.Currents.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrentName + x.CurrentSurname,
                                                 Value = x.CurrentID.ToString()
                                             }).ToList();
            List<SelectListItem> employees = (from x in db.Employees.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeName + x.EmployeeSurname,
                                                  Value = x.EmployeeID.ToString()
                                              }).ToList();
            ViewBag.productList = products;
            ViewBag.currentList = currents;
            ViewBag.employeeList = employees;


            return View();

        }

        [HttpPost]
        public ActionResult NewSales(SalesMovements sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SalesMovements.Add(sales);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetSales(int id)
        {
            List<SelectListItem> products = (from x in db.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductID.ToString()
                                             }).ToList();
            List<SelectListItem> currents = (from x in db.Currents.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrentName + x.CurrentSurname,
                                                 Value = x.CurrentID.ToString()
                                             }).ToList();
            List<SelectListItem> employees = (from x in db.Employees.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeName + x.EmployeeSurname,
                                                  Value = x.EmployeeID.ToString()
                                              }).ToList();
            ViewBag.productList = products;
            ViewBag.currentList = currents;
            ViewBag.employeeList = employees;

            var list = db.SalesMovements.Find(id); ;
            return View("GetSales",list); 
        }

        public ActionResult SalesUpdate(SalesMovements sales)
        {
            var list = db.SalesMovements.Find(sales.SalesID);
            list.ProductId = sales.ProductId;
            list.CurrentId = sales.CurrentId;
            list.EmployeeId = sales.EmployeeId;
            list.Price = sales.Price;
            list.Count = sales.Count;
            list.Date = sales.Date;
            list.TotalPrice = sales.TotalPrice;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SalesDetail(int id)
        {
            var list = db.SalesMovements.Where(x => x.SalesID == id).ToList();
            return View(list);
        }


    }
}