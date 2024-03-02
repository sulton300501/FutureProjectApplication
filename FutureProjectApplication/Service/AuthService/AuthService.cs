using FutureProject.Domain.Entities.DTOs;
using FutureProject.Domain.Entities.Models;
using FutureProjectApplication.Abstraction.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens.Configuration;

namespace FutureProjectApplication.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IUserService _userService;

        public AuthService(IConfiguration conf)
        {
            _conf = conf;
        }

        public async Task<ResponseLogin> GenerateToken(RequestLogin user)
        {
            if(user == null)
            {
                return new ResponseLogin()
                {
                    Token = "User not found"
                };
            }
            if (await UserExist(user))
            {
                var result = await _userService.GetByLogin(user.Login);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, result.Role),
                    new Claim("Login",result.Login),
                    new Claim("UserId",result.Id.ToString()),
                    new Claim("CreateDate", DateTime.UtcNow.ToString())
                



                };

                return await GenerateToken(claims);
             


            }
            return new ResponseLogin()
            {
                Token = "Un Authorize"
            };

        }




        public async Task<ResponseLogin> GenerateToken(IEnumerable<Claim> additionalClaims)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat , EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture))

            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);

            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new ResponseLogin()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };







        }















        public async Task<bool> UserExist(RequestLogin user)
        {
          

            var result = await _userService.GetByLogin(user.Login);

            if (user.Login == result.Login && user.Password == result.Password)
            {
                return true;
            }

            return false;
        }





    }
}
