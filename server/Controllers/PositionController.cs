using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class PositionController: Controller
    {
        // GET api/position
        [HttpGet]
        public IEnumerable<Position> GetPositions(){
            IEnumerable<Position> positions = PositionDAO.ReadAllPositions();
            return positions;
        }

        // POST api/position
        [HttpPost]
        public void AddPosition([FromBody] Position position){
            PositionDAO.AddPosition(new Position());
        }        
    }
}