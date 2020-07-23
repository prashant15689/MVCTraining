using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using MVCTrainingProject.Models;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Employees> Get()
        {
            return new EmployeeDataLogic().GetAllEmployees();
        }

        // GET api/values/5
        public Employees Get(int id)
        {
            return new EmployeeDataLogic().GetEmployeById(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] Employees employee)
        {
            return Created(Request.RequestUri, new EmployeeDataLogic().CreateEmployee(employee));
        }

        // PUT api/values/
        public IHttpActionResult Put([FromBody] Employees employee)
        {
            new EmployeeDataLogic().UpdateEmployee(employee);
            return Ok(new {message = "Updated", status = "success", data = employee });
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
