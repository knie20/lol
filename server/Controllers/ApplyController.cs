using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/apply")]
    public class ApplyController: Controller
    {
        [HttpPost]
        public string Apply([FromBody] Application application){
            return "";
        }

        [HttpGet("positions")]
        public IActionResult GetPositions(){
            return null;
        }
    }
}