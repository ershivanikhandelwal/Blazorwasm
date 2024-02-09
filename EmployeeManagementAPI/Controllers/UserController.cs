using EmployeeManagementAPI.Services;
using EmployeeManagementModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService) { 
            this._userService = userService;
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register(Users user)
        {
            return Ok(await _userService.RegisterUser(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel user)
        {
            return Ok(await _userService.LoginUser(user));
        }
    }
}
