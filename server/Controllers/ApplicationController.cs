using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace server.Controllers
{

    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        // GET api/application
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<Application> applications  = (List<Application>) ApplicationDAO.ReadAllApplications();
            IEnumerable<string> serializedApplications = new List<string>();
            applications.ForEach(a => {
              serializedApplications.Append(JsonConvert.SerializeObject(a));
            });

            return serializedApplications;
        }

        // GET api/application/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(ApplicationDAO.ReadApplication(id));
        }

        // POST api/application
        [HttpPost]
        public void Post([FromBody]string jsonApplication)
        {
            Application application = JsonConvert.DeserializeObject<Application>(jsonApplication);
            ApplicationDAO.CreateApplication(application);
        }

        // PUT api/application/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/application/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          ApplicationDAO.DeleteApplication(id);
        }
    }
}
