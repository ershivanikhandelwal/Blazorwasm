using EmployeeManagementAPI.Services;
using EmployeeManagementModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("getDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            return Ok(await _departmentService.GetDepartmentById(id));
        }

        [HttpGet("getDepartmentByName/{name}")]
        public async Task<IActionResult> GetDepartmentByName(string name)
        {
            return Ok(await _departmentService.GetDepartmentByName(name));
        }

        [HttpPost("addDepartment")]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            return Ok(await _departmentService.AddDepartment(department));
        }

        [HttpPut("updateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            return Ok(await _departmentService.UpdateDepartment(department));
        }

        [HttpDelete("deleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();            
        }
    }
}
