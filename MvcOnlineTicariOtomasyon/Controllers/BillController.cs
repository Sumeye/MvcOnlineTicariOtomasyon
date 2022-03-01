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


        public ActionResult DynamicBill()
        {
            BillDynamicViewModel dynamicViewModel = new BillDynamicViewModel();
            dynamicViewModel.Bills = db.Bills.ToList();
            dynamicViewModel.ExpenseItems = db.ExpenseItems.ToList();
            return View(dynamicViewModel);
        }

        public ActionResult BillSave(Bills bills,ExpenseItems[] expenseItems)
        {
            Bills b = new Bills();
            b.BillSerialNo = bills.BillSerialNo;
            b.BillRowNumber = bills.BillRowNumber;
            b.CreateDate = bills.CreateDate;
            b.TaxOffice = bills.TaxOffice;
            b.Time = bills.Time;
            b.Receiver = bills.Receiver;
            b.DeliveryPerson = bills.DeliveryPerson;
            b.TotalPrice = bills.TotalPrice;
            db.Bills.Add(b);
            foreach (var item in expenseItems)
            {
                ExpenseItems eI = new ExpenseItems();
                eI.Description = item.Description;
                eI.UnitPrice = item.UnitPrice;
                eI.BillID = item.BillID;
                eI.Quantity = item.Quantity;
                eI.Amount = item.Amount;
                db.ExpenseItems.Add(eI);
            }
            db.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);



        }

    }
}