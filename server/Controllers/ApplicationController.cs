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

    [Route("api/[controller]"), Authorize]
    public class ApplicationController : Controller
    {
        // GET api/application
        [HttpGet]
        public IEnumerable<JObject> Get()
        {
            List<Application> applications  = ApplicationDAO.ReadAllApplications().ToList();
            List<JObject> serializedApplications = new List<JObject>();
            foreach(Application a in applications){
              serializedApplications.Add(JObject.FromObject(a));
            }

            return serializedApplications;
        }

        // GET api/application/5
        [HttpGet("{id}")]
        public JObject Get(int id)
        {
            return JObject.FromObject(ApplicationDAO.ReadApplication(id));
        }

        // POST api/application
        [HttpPost]
        public void Post([FromBody]string jsonBody)
        {
            JObject applicationJson = JObject.Parse(jsonBody).Value<JObject>("application");
            Application application = new Application{
                FirstName = applicationJson.Value<string>("first_name"),
                Lastname = applicationJson.Value<string>("last_name")
            };
            ApplicationDAO.CreateApplication(application);
        }

        // PUT api/application/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string jsonBody)
        {
            return "nice";
        }

        // DELETE api/application/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          ApplicationDAO.DeleteApplication(id);
        }
    }
}
