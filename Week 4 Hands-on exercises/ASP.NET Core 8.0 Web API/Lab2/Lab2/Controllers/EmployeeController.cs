using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers 
{
    [ApiController]
    [Route("api/Emp")]  // 👈 renamed route
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new[]
            {
                new { Id = 1, Name = "Nirupam" },
                new { Id = 2, Name = "Aditya" }
            };

            return Ok(employees);
        }
    }
}
