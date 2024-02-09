using EmployeeManagementAPI.Common;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementModel;

namespace EmployeeManagementAPI.Services
{
    public class UserService : IUserService
    {
        public readonly IRepository<Users> _repository;
        public readonly ITokenService _tokenService;
        private readonly AppDBContext _appDBContext;
        public UserService(AppDBContext appDBContext, ITokenService tokenService)
        {
            _appDBContext = appDBContext;
            this._repository = new Repository<Users>(_appDBContext);
            _tokenService = tokenService;
        }
        public async Task<ResponseDTO> RegisterUser(Users user)
        {
            ResponseDTO response= new ResponseDTO();
            Users usr =await _repository.GetSingle(a=>a.Username == user.Username);
            if(usr != null)
            {
                response.ErrorMessage = "Username already exists";
                response.isSuccess = false;
                return response;
            }
            else
            {
                user.Password= UtilityService.ComputeSha256Hash(user.Password);
                usr =await _repository.Add(user);
                response.Data = usr;
                response.isSuccess = true;
            }
            return response;
        }

        public async Task<ResponseDTO> LoginUser(LoginModel user)
        {
            ResponseDTO response = new ResponseDTO();
            string password = UtilityService.ComputeSha256Hash(user.Password);
            Users usr = await _repository.GetSingle(a => a.Username == user.UserName);
            if (usr == null)
            {
                response.ErrorMessage = "User does not exists.";
                response.isSuccess = false;
                return response;
            }
            else if(usr.Password!= password)
            {
                response.ErrorMessage = "Please enter correct password.";
                response.isSuccess = false;
                return response;
            }
            else
            {
                string token=await _tokenService.GenerateToke(usr);
                response.Data = token+";"+usr.Email;
                response.isSuccess = true;
            }
            return response;
        }
    }
}
