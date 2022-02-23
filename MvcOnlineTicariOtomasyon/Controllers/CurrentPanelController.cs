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
            var emailControl = db.Currents.FirstOrDefault(x => x.CurrentEmail == mail);
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
    }
}