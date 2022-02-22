using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index2()
        {
            var graphicdraw = new Chart(600, 600);
            graphicdraw.AddTitle("Kategori-Ürün Stok Sayısı")
                       .AddLegend("Stok")
                       .AddSeries("Değerler",
                       xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                       yValues: new[] { 85, 66, 98 })
                       .Write();

            return File(graphicdraw.ToWebImage().GetBytes(), "image/jpeg");
        }

        Context db = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = db.Products.ToList();

            result.ToList().ForEach(x => xvalue.Add(x.ProductName));
            result.ToList().ForEach(x => yvalue.Add(x.Stock));
            var graphic = new Chart(width: 800, height: 800)
                          .AddTitle("Stoklar")
                          .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<ProductGraphicModel> ProductList()
        {
            List<ProductGraphicModel> prdct = new List<ProductGraphicModel>();
            prdct.Add(new ProductGraphicModel()
            {
                ProductName = "Bilgisayar",
                Stock = 120
            });
            prdct.Add(new ProductGraphicModel()
            {
                ProductName = "Beyaz Eşya",
                Stock = 150
            });
            prdct.Add(new ProductGraphicModel()
            {
                ProductName = "Mobilya",
                Stock = 70
            });
            prdct.Add(new ProductGraphicModel()
            {
                ProductName = "Küçük Ev Aletleri",
                Stock = 150
            });
            prdct.Add(new ProductGraphicModel()
            {
                ProductName = "Mobil Cihazlar",
                Stock = 90
            });

            return prdct;
        }


        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<ProductGraphicModel2> ProductList2()
        {
            List<ProductGraphicModel2> pdct = new List<ProductGraphicModel2>();
            using (var c = new Context())
            {
                pdct = c.Products.Select(x => new ProductGraphicModel2
                {
                    ProductName = x.ProductName,
                    Stock = x.Stock
                }).ToList();

            };
            return pdct;
        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }

    }
}