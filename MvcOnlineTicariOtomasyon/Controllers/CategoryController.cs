using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context db = new Context();
        public ActionResult Index(int page=1)
        {
            var categoryList = db.Categories.ToList().ToPagedList(page,4);
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Categories categories)
        {
            db.Categories.Add(categories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryGet(int id)
        {
            var cat = db.Categories.Find(id);
            return View("CategoryGet",cat);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Categories categories)
        {
            var cat = db.Categories.Find(categories.CategoryID);
            cat.CategoryName = categories.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}