using MVCTrainingProject.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCTrainingProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            IEnumerable<Employees> employees = dbContext.Employees;
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            Employees employee = dbContext.Employees.Find(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employees empData)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            Employees employee = dbContext.Employees.Find(empData.Id);
            employee.EmpName = empData.EmpName;
            employee.Email = empData.Email;
            employee.Phone = empData.Phone;
            employee.Address = empData.Address;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateModel empData)
        {
            if (ModelState.IsValid)
            {
                MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();

                Employees employee = new Employees
                {
                    EmpName = empData.EmpName,
                    Email = empData.Email,
                    Phone = empData.Phone,
                    Address = empData.Address
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();

            Employees employeeDelete = dbContext.Employees.Find(Id);
            if (employeeDelete != null)
            {
                dbContext.Employees.Remove(employeeDelete);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}