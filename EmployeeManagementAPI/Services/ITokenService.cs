using EmployeeManagementModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementAPI.Services
{
    public interface ITokenService
    {
        public Task<string> GenerateToke(Users user);
    }
}
