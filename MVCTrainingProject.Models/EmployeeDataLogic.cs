using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTrainingProject.Models
{
    public class EmployeeDataLogic
    {
        public IEnumerable<Employees> GetAllEmployees()
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            IEnumerable<Employees> employees = dbContext.Employees;
            return employees;
        }

        public Employees GetEmployeById(int id)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            return dbContext.Employees.Find(id);            
        }

        public void UpdateEmployee(Employees empData)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();
            Employees employee = dbContext.Employees.Find(empData.Id);
            employee.EmpName = empData.EmpName;
            employee.Email = empData.Email;
            employee.Phone = empData.Phone;
            employee.Address = empData.Address;
            dbContext.SaveChanges();
        }

        public Employees CreateEmployee(Employees empData)
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
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            MVCTrainingDBEntities dbContext = new MVCTrainingDBEntities();

            Employees employeeDelete = dbContext.Employees.Find(id);
            if (employeeDelete != null)
            {
                dbContext.Employees.Remove(employeeDelete);
                dbContext.SaveChanges();
            }
        }
    }
}