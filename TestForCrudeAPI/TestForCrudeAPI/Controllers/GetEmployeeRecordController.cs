using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestForCrudeAPI.Models;

namespace TestForCrudeAPI.Controllers
{
    public class GetEmployeeRecordController : ApiController
    {
        Entities db = new Entities();
        //Insert record
        public string Post(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return "New employee Added";

        }
        //Get all Records
        public IEnumerable<Employee> Get()
        {
            return db.Employees.ToList();
        }

        //Get signle record
        public Employee Get(int ID)
        {
           Employee employee =  db.Employees.Find(ID);
            return employee;        
        }
        //Update record
        public string Put(int ID, Employee employee)
        {
            var employee_ = db.Employees.Find(ID);
            employee_.FirstName = employee.FirstName;
            employee_.MiddleName = employee.MiddleName;
            employee_.LastName = employee.LastName;

            db.Entry(employee_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Employee Record Updated.";
        }


        //Delete record
        public string Delete(int ID)
        {
            Employee employee = db.Employees.Find(ID);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return "Successfully Deleted";
        }
    }
}
