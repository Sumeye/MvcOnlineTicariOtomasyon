using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context db = new Context();
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }

        public ActionResult EmployeeAdd()
        {

            List<SelectListItem> DepartmentList = (from x in db.Departments.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DepartmentName,
                                                       Value = x.DepartmentID.ToString(),
                                                   }).ToList();

            ViewBag.DepartmentList = DepartmentList;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employees employees)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employees.EmployeeImage = "/Image/" + fileName + extension;

            }

            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeGet(int id)
        {
            List<SelectListItem> departmentlist = (from x in db.Departments.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DepartmentName,
                                                       Value = x.DepartmentID.ToString(),
                                                   }).ToList();

            ViewBag.DepartmentList = departmentlist;

            var emp = db.Employees.Find(id);
            return View("EmployeeGet", emp);
        }

        public ActionResult EmployeeUpdate(Employees emp)
        {

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                emp.EmployeeImage = "/Image/" + fileName + extension;

            }

            var employee = db.Employees.Find(emp.EmployeeID);
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeSurname = emp.EmployeeSurname;
            employee.EmployeeImage = emp.EmployeeImage;
            employee.DepartmentId = emp.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeList()
        {
            var query = db.Employees.ToList();
            return View(query);
        }

    }
}