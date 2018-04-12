using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/{controller}")]
    public class PositionController: Controller
    {
        [HttpPost]
        public void Apply([FromBody] Position position){
            
        }

        [HttpGet("all")]
        public IActionResult GetPositions(){
            return null;
        }
    }
}