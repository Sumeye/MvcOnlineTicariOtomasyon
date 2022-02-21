using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context db = new Context();
        public ActionResult Index(string p)
        {
            List<CargoDetail> cargo = new List<CargoDetail>();
            cargo = db.CargoDetails.ToList();
            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(x => x.TrackingCode == p).ToList();
                if (!cargo.Any())
                {
                    ViewBag.HataMesaji = "Kargo takip Kodu bulunamadı.";
                    return View();
                }

            }
            return View(cargo);
        }




        public ActionResult CargoAdd()
        {
            Random rnd = new Random();
            string[] characters = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10  
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string randomCode = s1.ToString() + characters[k1] + s2 + characters[k2] + s3 + characters[k3];
            ViewBag.TrackingCode = randomCode;

            return View();
        }

        [HttpPost]
        public ActionResult CargoAdd(CargoDetail cargoDetail)
        {
            db.CargoDetails.Add(cargoDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CargoTracking(string id)
        {
        var list=db.cargoTrackings.Where(x=>x.TrackingCode==id).ToList();

            return View(list);

        }


    }
}