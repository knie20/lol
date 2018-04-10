using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("apply")]
    public class ApplyController: Controller
    {
        [HttpPost]
        public string Apply([FromBody] Application application){
            return "";
        }
    }
}