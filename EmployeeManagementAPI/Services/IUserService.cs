using EmployeeManagementModel;

namespace EmployeeManagementAPI.Services
{
    public interface IUserService
    {
        public Task<ResponseDTO> RegisterUser(Users user);
        public Task<ResponseDTO> LoginUser(LoginModel user);
    }
}
