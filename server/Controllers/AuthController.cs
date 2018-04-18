using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using server.Utils;

namespace server.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        
        private IConfiguration _config;

        public AuthController(IConfiguration configuration){
            _config = configuration;
        }

        // POST auth/logout
        [HttpPost("logout")]
        public string Logout([FromBody]string username)
        {
            return "";
        }

        // POST auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody]JObject login)
        {
            JObject res = new JObject();

            if(PasswordUtil.VerifyPassword(login.Value<string>("Pw"), AuthDAO.ReadAccount(login.Value<string>("Username")).HashedPw)){
                string token = GenerateJwtToken(login.Value<string>("Username"));
                res["status"] = "SUCCESS";
                res["message"] = "successfully logged in";
                res["token"] = token; 
            }else{
                res["status"] = "FAILURE";
                res["message"] = "Invalid username or password";
            }
            
            return Json(res);
        }

        [HttpGet("current-user")]
        public string GetCurrentUser(){
            return "";
        }

        private string GenerateJwtToken(string username){
            var claims = new List<Claim>{
                new Claim("Username", username.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["Jwt:JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _config["Jwt:JwtIssuer"],
                _config["Jwt:JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
