using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail =(string)Session["CurrentEmail"];
            var emailControl = db.Currents.FirstOrDefault(x=>x.CurrentEmail==mail);
            ViewBag.m = mail;
            return View(emailControl);
        }


        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentEmail"];
            var id = db.Currents.Where(x => x.CurrentEmail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var result = db.SalesMovements.Where(x => x.CurrentId == id).ToList();
            return View(result);
        }
    }
}