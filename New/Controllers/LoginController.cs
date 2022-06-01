using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using New.Models;
using New.RequestModel;

namespace cg_docs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _drive;
        private readonly DriveContext _driveContext;

        public LoginController(IConfiguration drive, DriveContext dv)
        {
            _drive = drive;
            _driveContext = dv;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private string BuildToken(UsersRequest user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_drive["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_drive["Jwt:Issuer"],
              _drive["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UsersRequest Authenticate(LoginModel login)
        {
            UsersRequest user = null;
            var result = _driveContext.Users.FirstOrDefault(obj => obj.Username == login.username);

            try
            {
                if (result.Username != null && result.UserPassword == login.password)
                {
                    user = new UsersRequest { Username = result.Username, UserPassword = result.UserPassword };
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }
        public class LoginModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }

     
    }

}