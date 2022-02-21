using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context db = new Context();
        public ActionResult Index()
        {
            var currents = db.Currents.Where(x => x.Status == true).ToList();
            return View(currents);
        }

        public ActionResult CurrentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current current)
        {
            db.Currents.Add(current);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CurrentGet(int id)
        {
            var cur = db.Currents.Find(id);
            return View("CurrentGet", cur);
        }

        public ActionResult CurrentUpdate(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentGet");
            }
            else
            {
                var cur = db.Currents.Find(current.CurrentID);
                cur.CurrentName = current.CurrentName;
                cur.CurrentSurname = current.CurrentSurname;
                cur.CurrentCity = current.CurrentCity;
                cur.CurrentEmail = current.CurrentEmail;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult CurrentDelete(int id)
        {
            var cur = db.Currents.Find(id);
            cur.Status = false;
            db.SaveChanges();
            return View("CurrentGet", cur);
        }

        public ActionResult CustomerSales(int id)
        {
            var SalesList = db.SalesMovements.Where(x => x.CurrentId == id).ToList();
            var cr = db.Currents.Where(x => x.CurrentID == id).Select(x => x.CurrentName + " " + x.CurrentSurname).FirstOrDefault();
            ViewBag.current = cr;
            return View(SalesList);
        }

    }
}