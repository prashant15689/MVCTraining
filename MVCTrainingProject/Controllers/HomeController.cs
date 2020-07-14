using MVCTrainingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult About()
        {
            ViewBag.Message = "This is an MVC application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact is - 9560348122.";

            return View();
        }
    }
}