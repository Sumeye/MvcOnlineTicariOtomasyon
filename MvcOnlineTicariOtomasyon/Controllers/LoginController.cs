using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Current current)
        {
            db.Currents.Add(current);
            db.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CurrentLogin1(Current current)
        {
            var userControl = db.Currents.FirstOrDefault(x => x.CurrentEmail == current.CurrentEmail && x.CurrentPassword == current.CurrentPassword);
            if (userControl != null)
            {
                FormsAuthentication.SetAuthCookie(userControl.CurrentEmail, false);
                Session["CurrentEmail"] = userControl.CurrentEmail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var userControl = db.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (userControl != null)
            {
                FormsAuthentication.SetAuthCookie(userControl.UserName, false);
                Session["UserName"] = userControl.UserName.ToString();
                return RedirectToAction("Index","Category");
            }
            else
            {
              return  RedirectToAction("Index", "Login");
            }
        }

    }
}