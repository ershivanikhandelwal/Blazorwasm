using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementAPI.Services
{
    public class TokenService: ITokenService
    {
        private readonly IRepository<Users> _repository;
        public IConfiguration _configuration;
        private readonly AppDBContext _appDBContext;
        public TokenService(AppDBContext appDBContext,IConfiguration configuration)
        {
            _appDBContext = appDBContext;
            _repository = new Repository<Users>(_appDBContext); ;
            _configuration = configuration;
        }
        public async Task<string> GenerateToke(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(Sectoken);
            //if (user != null && user.Email != null && user.Password != null)
            //{
            //    var userdetail = await _repository.GetSingle(a => a.Email.Equals(user.Email));

            //    if (userdetail != null)
            //    {
            //        var claims = new[] {
            //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //            new Claim("username", user.Username),
            //            new Claim("email", user.Email)
            //        };

            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            //        var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //        var token = new JwtSecurityToken(
            //            _configuration["jwt:issuer"],
            //            null,
            //            claims,
            //            expires: DateTime.UtcNow.AddMinutes(10),
            //            signingCredentials: signin);

            //        return new JwtSecurityTokenHandler().WriteToken(token);
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}
