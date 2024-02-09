using EmployeeManagementModel;
using Refit;

namespace EmployeeManagementWeb.Services
{
    public interface IUserService
    {
        [Post("/User/registerUser")]
        public Task<ResponseDTO> RegisterUser(Users user);
        [Post("/User/login")]
        public Task<ResponseDTO> LoginUser(LoginModel user);
    }
}
