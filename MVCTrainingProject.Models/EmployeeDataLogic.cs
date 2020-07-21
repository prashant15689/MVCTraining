using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTrainingProject.Models
{
    public class EmployeeDataLogic
    {
        public string Get()
        {
            return "Hello";
        }
        public string Get(string name)
        {
            return name;
        }

        public string Get(string name, int Id)
        {
            return name + " - ID: " + Id.ToString();
        }

        public void Get(string name, object model)
        {
            // ksdj
        }
    }
}