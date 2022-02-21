using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class TodoListController : Controller
    {
        // GET: TodoList
        Context db = new Context();
        public ActionResult Index()
        {
            var currentList = db.Currents.Count().ToString();
            ViewBag.d1 = currentList;
            var productList = db.Products.Count().ToString();
            ViewBag.d2 = productList;
            var categoryList= db.Categories.Count().ToString();
            ViewBag.d3 = categoryList;

            var currentCity = (from x in db.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.d4 = currentCity;

            var todoList = db.todoLists.ToList();
            return View(todoList);

        }
    }
}