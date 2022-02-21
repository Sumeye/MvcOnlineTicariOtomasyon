using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context db = new Context();
        public ActionResult Index()
        {
            var departmentList = db.Departments.Where(x => x.Status == true).ToList();
            return View(departmentList);
        }

        public ActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentGet(int id)
        {
            var dep = db.Departments.Find(id);
            return View("DepartmentGet", dep);
        }

        [HttpPost]
        public ActionResult DepartmentUpdate(Department department)
        {
            var dep = db.Departments.Find(department.DepartmentID);
            dep.DepartmentName = department.DepartmentName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var dep = db.Departments.Find(id);
            dep.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var emp = db.Employees.Where(x => x.DepartmentId == id);
            var dpt = db.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.department = dpt;
            return View(emp);

        }

        public  ActionResult DepartmentEmployeeSales(int id)
        {
            var value = db.SalesMovements.Where(x => x.EmployeeId == id).ToList();
            var emp = db.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName +" "+ y.EmployeeSurname).FirstOrDefault();
            ViewBag.departmentEmployee = emp;
            return View(value);
        }
    }
}