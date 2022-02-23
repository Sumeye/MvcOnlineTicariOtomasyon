using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentEmail"];
            var emailControl = db.Messages.Where(x => x.Sender == mail).ToList();
            ViewBag.m = mail;
            var mailId = db.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentID).FirstOrDefault();
            ViewBag.CurrentMailCount = mailId;
            var totalSales = db.SalesMovements.Where(x => x.CurrentId == mailId).Count();
            ViewBag.TotalSales = totalSales;
            var totalAmount = db.SalesMovements.Where(x => x.CurrentId == mailId).Sum(y => (decimal?)y.TotalPrice) ?? 0;
            ViewBag.TotalAmount = totalAmount;
            var totalProductCount = db.SalesMovements.Where(x => x.CurrentId == mailId).Sum(y => (int?)y.Count) ?? 0;
            ViewBag.TotalProductCount = totalProductCount;
            var fullName = db.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.FullName = fullName;
            return View(emailControl);
        }


        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentEmail"];
            var id = db.Currents.Where(x => x.CurrentEmail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var result = db.SalesMovements.Where(x => x.CurrentId == id).ToList();
            return View(result);
        }
        /// <summary>
        /// Gelen Mesaj
        /// </summary>
        /// <returns></returns>
        public ActionResult InComingMessages()
        {
            var mail = (string)Session["CurrentEmail"];
            var messages = db.Messages.Where(x => x.Recipient == mail).OrderByDescending(x => x.MessageID).ToList();
            var incomingMessagesCount = db.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.InComingBox = incomingMessagesCount;
            var sentMessagesCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.SentBox = sentMessagesCount;
            return View(messages);
        }

        /// <summary>
        /// Gönderdiğim Mesaj
        /// </summary>
        /// <returns></returns>
        public ActionResult SentMessages()
        {
            var mail = (string)Session["CurrentEmail"];
            var messages = db.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageID).ToList();
            var sentMessagesCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.SentBox = sentMessagesCount;
            var incomingMessagesCount = db.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.InComingBox = incomingMessagesCount;
            return View(messages);
        }


        public ActionResult MessageDetail(int id)
        {
            var mesageDetail = db.Messages.Where(x => x.MessageID == id).ToList();

            var mail = (string)Session["CurrentEmail"];
            var sentMessagesCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.SentBox = sentMessagesCount;
            var incomingMessagesCount = db.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.InComingBox = incomingMessagesCount;
            return View(mesageDetail);
        }

        /// <summary>
        /// Yeni Mesaj
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentEmail"];
            var sentMessagesCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.SentBox = sentMessagesCount;
            var incomingMessagesCount = db.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.InComingBox = incomingMessagesCount;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Messages messages)
        {
            var mail = (string)Session["CurrentEmail"];
            messages.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            messages.Sender = mail;
            db.Messages.Add(messages);
            db.SaveChanges();
            return View();
        }


        public ActionResult CargoTracking(string p)
        {
            List<CargoDetail> cargo = new List<CargoDetail>();
            cargo = db.CargoDetails.ToList();
            cargo = cargo.Where(x => x.TrackingCode == p).ToList();
            return View(cargo);
        }

        public ActionResult CurrentCargoTracking(string id)
        {
            var list = db.cargoTrackings.Where(x => x.TrackingCode == id).ToList();

            return View(list);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public  PartialViewResult CurrentSetting()
        {
            var mail = (string)Session["CurrentEmail"];
            var id = db.Currents.Where(x => x.CurrentEmail == mail).Select(y => y.CurrentID).FirstOrDefault();
            var currentFind = db.Currents.Find(id);
            return PartialView("CurrentSetting", currentFind);
        }

        public PartialViewResult Notice()
        {
            var list = db.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(list);
        }

        public   ActionResult CurrentInformationUpdate(Current cr)
        {
            var current = db.Currents.Find(cr.CurrentID);
            current.CurrentName = cr.CurrentName;
            current.CurrentSurname = cr.CurrentSurname;
            current.CurrentEmail = cr.CurrentEmail;
            current.CurrentPassword = cr.CurrentPassword;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}