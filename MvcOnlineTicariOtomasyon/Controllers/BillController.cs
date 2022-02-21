using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill

        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.Bills.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBill(Bills bills)
        {
            db.Bills.Add(bills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBill(int id)
        {
            var bill = db.Bills.Find(id);
            return View("GetBill", bill);
        }

        public ActionResult UpdateBill(Bills bills)
        {
            var bill = db.Bills.Find(bills.BillID);

            bill.BillSerialNo = bills.BillSerialNo;
            bill.BillRowNumber = bills.BillRowNumber;
            bill.CreateDate = bills.CreateDate;
            bill.Time = bills.Time;
            bill.DeliveryPerson = bills.DeliveryPerson;
            bill.Receiver = bills.Receiver;
            bill.TaxOffice = bills.TaxOffice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailBills(int id)
        {
            var detailBills = db.ExpenseItems.Where(x => x.BillID == id).ToList();
            return View(detailBills);
        }

        public ActionResult NewExpenseItems()
        {
            return View();
        }

        /// <summary>
        /// Yeni Fatura Girişi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewExpenseItems(ExpenseItems items)
        {
            db.ExpenseItems.Add(items);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}