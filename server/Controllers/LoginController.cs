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

namespace server.Controllers
{

    [Route("auth")]
    public class LoginController : Controller
    {
        
        // POST auth/logout
        [HttpPost("logout")]
        public string Logout([FromBody]string username)
        {
            return "";
        }

        // POST auth/login
        [HttpPost("login")]
        public void Login([FromBody]LoginCredentials login)
        {
            
        }
    }
}
