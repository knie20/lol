using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Persistence;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class PositionController: Controller
    {
        [HttpPost]
        public void AddPosition([FromBody] string position){
            PositionDAO.AddPosition(new Position());
        }

        [HttpGet("all")]
        public IActionResult GetPositions(){
            return null;
        }
    }
}