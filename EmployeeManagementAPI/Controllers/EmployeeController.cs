using EmployeeManagementAPI.Services;
using EmployeeManagementModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService= employeeService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string? name, Gender? gender)
        {
            return Ok(await _employeeService.Search(name, gender));
        }

        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpGet("getEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddNewEmployee(Employee emp)
        {
            return Ok(await _employeeService.AddEmployee(emp));
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            return Ok(await _employeeService.UpdateEmployee(emp));
        }

        [HttpDelete("deleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
