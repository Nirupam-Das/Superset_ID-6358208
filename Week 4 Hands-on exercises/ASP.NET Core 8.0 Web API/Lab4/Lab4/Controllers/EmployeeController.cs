using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // In-memory employee list
        private static readonly List<Employee> _employees =
        [
            new() { Id = 1, Name = "Anil",  Email = "anil@corp.com",  Dept = "HR",    Salary = 35000 },
            new() { Id = 2, Name = "Beena", Email = "beena@corp.com", Dept = "IT",    Salary = 55000 },
            new() { Id = 3, Name = "Chirag",Email = "chirag@corp.com",Dept = "Sales", Salary = 42000 }
        ];

        // -------- PUT / Update Employee --------
        [HttpPut("{id:int}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee input)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = input.Name;
            emp.Email = input.Email;
            emp.Dept = input.Dept;
            emp.Salary = input.Salary;

            return Ok(emp);
        }
    }
}
