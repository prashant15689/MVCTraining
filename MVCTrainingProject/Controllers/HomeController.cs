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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}