using Microsoft.Ajax.Utilities;
using MVCTrainingProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCTrainingProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44300/api/values");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                IEnumerable<Employees> employees = JsonConvert.DeserializeObject<IEnumerable<Employees>>(responseBody); ;
                return View(employees);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            EmployeeDataLogic dataLogic = new EmployeeDataLogic();

            if (Id != null)
            {
                return View(dataLogic.GetEmployeById(Id.Value));
            }
            else
            {
                //return RedirectToAction("Index");

                return Content("No employee found <br/> <a href='/Home/Index'>Employee List</a>");
            }
        }

        [HttpPost]
        public ActionResult Edit(Employees empData)
        {
            EmployeeDataLogic dataLogic = new EmployeeDataLogic();
            dataLogic.UpdateEmployee(empData);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateModel empData)
        {
            if (ModelState.IsValid)
            {
                Employees employee = new Employees
                {
                    Address = empData.Address,
                    Email = empData.Email,
                    EmpName = empData.EmpName,
                    Phone = empData.Phone
                };
                EmployeeDataLogic dataLogic = new EmployeeDataLogic();
                dataLogic.CreateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            new EmployeeDataLogic().DeleteEmployee(Id.Value);

            return RedirectToAction("Index");
        }
    }
}