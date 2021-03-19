using Microsoft.AspNetCore.Mvc;
using MiddlewareLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public List<Employee> _data = new List<Employee>();

        [HttpGet]
        public List<Employee> Get()
        {
            return _data.ToList();
        }


        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            Console.WriteLine("POST");
            Console.WriteLine(employee);
            var employeeInfo = new Employee()
            {
                ID = employee.ID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
            };
            _data.Add(employeeInfo);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var data = _data.FirstOrDefault(c => c.ID == id);
            _data.Remove(data);
            return "Deleted";
        }

        [HttpPut("{id}")]
        public Employee Put([FromBody] Employee employee, int id)
        {
            var data = _data.FirstOrDefault(c => c.ID == id);
            data.ID = employee.ID != null ? employee.ID : data.ID;
            data.FirstName = employee.FirstName != null ? employee.FirstName : data.FirstName;
            data.LastName = employee.LastName != null ? employee.LastName : data.LastName;
            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetByID(int id)
        {
            var employee = new Employee()
            {
                ID = id,
                FirstName = "duygu",
                LastName = "odabaş",
            };

            return Ok(employee);
        }
    }
}
