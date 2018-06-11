using MVCRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRazor.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB db = new EmployeeDB();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> empList = db.Employee.ToList();
            return View(empList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                db.Employee.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);
        }
        public ActionResult Details(int Id)
        {
            Employee employee = db.Employee.Where(x => x.ID == Id).Single();
            return View(employee);
        }
        public ActionResult Edit(int Id)
        {
            Employee employee = db.Employee.Where(x => x.ID == Id).Single();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee employee = db.Employee.Where(x => x.ID == emp.ID).Single();
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.Gender = emp.Gender;
                employee.Salary = emp.Salary;
                db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);
        }
        public ActionResult Delete(int? Id)
        {
            Employee employee = db.Employee.Where(x => x.ID == Id).Single();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Employee employee = db.Employee.Where(x => x.ID == Id).Single();
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}