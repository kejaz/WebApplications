using MVCRazor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCRazor.Controllers
{
    public class PersonController : Controller
    {
        EmployeeDB db = new EmployeeDB();

        // GET: Person
        public ActionResult Index()
         {
            return View();
        }

        public JsonResult GetAllPersons()
        {
            List<Employee> personList = db.Employee.ToList();
            return Json(personList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeById(int EmployeeId)
        {
            Employee person = db.Employee.Where(x => x.ID == EmployeeId).Single();
            //string value = string.Empty;
            //value = JsonConvert.SerializeObject(person, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
              //});
            return Json(person, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int Id)
        {
            Employee person = db.Employee.Where(x => x.ID == Id).Single();
            return View(person);
        }
        public JsonResult UpdateEmployee(Employee emp)
        {
            var result = false;
            try
            {
                    Employee empObj = db.Employee.Where(x => x.ID == emp.ID).Single();
                    empObj.FirstName = emp.FirstName;
                    empObj.LastName = emp.LastName;
                    empObj.Gender = emp.Gender;
                    empObj.Salary = emp.Salary;
                    db.SaveChanges();
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddEmployee(Employee emp)
        {
            var result = false;
            try
            {
                 db.Employee.Add(emp);
                 db.SaveChanges();
                 result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEmployee(int EmployeeId)
        {
            bool result = false;
            Employee person = db.Employee.Where(x => x.ID == EmployeeId).Single();
            if (person != null)
            {
                db.Employee.Remove(person);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}