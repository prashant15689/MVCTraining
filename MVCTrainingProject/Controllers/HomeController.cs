using MVCTrainingProject.Models;
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
    }
}