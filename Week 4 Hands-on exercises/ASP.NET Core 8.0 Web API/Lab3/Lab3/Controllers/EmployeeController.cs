using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using Lab3.Filters;

namespace Lab3.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthFilter] // Apply custom authorization filter
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> _employees;

    public EmployeeController()
    {
        _employees = GetStandardEmployeeList();
    }

    // GET: api/employee
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<Employee>> Get()
    {
        // Intentionally throw an exception to test the custom exception filter
        throw new Exception("Test Exception from GET method");

        // return Ok(_employees); // Commented for testing exception
    }

    // GET: api/employee/1
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> Get(int id)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);
        return emp == null ? NotFound() : Ok(emp);
    }

    // POST: api/employee
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] Employee employee)
    {
        employee.Id = _employees.Max(e => e.Id) + 1;
        _employees.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }

    // PUT: api/employee/1
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(int id, [FromBody] Employee updated)
    {
        var index = _employees.FindIndex(e => e.Id == id);
        if (index < 0) return NotFound();

        updated.Id = id;
        _employees[index] = updated;
        return NoContent();
    }

    // Private seed method
    private static List<Employee> GetStandardEmployeeList() =>
    [
        new Employee
        {
            Id = 1,
            Name = "Alice",
            Salary = 80000,
            Permanent = true,
            DateOfBirth = new DateTime(1990, 1, 5),
            Department = new Department { Id = 1, Name = "HR" },
            Skills = [ new Skill { Id = 1, Name = "Recruitment" } ]
        },
        new Employee
        {
            Id = 2,
            Name = "Nirupam",
            Salary = 60000,
            Permanent = false,
            DateOfBirth = new DateTime(1995, 3, 12),
            Department = new Department { Id = 2, Name = "IT" },
            Skills = [ new Skill { Id = 2, Name = "C#" }, new Skill { Id = 3, Name = "SQL" } ]
        }
    ];
}
