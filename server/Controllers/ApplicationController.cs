using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Persistence;
using server.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace server.Controllers
{

    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        // GET api/application
        [HttpGet]
        public IEnumerable<JObject> GetAllApplications()
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

        //GET api/application/file/4
        [HttpGet("file/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var path = ApplicationDAO.ReadApplication(id).ResumePath;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, FileUtil.GetContentType(path), path);
        }

        // POST api/application
        [HttpPost]
        public void Post([FromBody]JObject body)
        {
            JObject applicationJson = body.Value<JObject>("application");

            Application application = new Application{
                ApplicationId = ApplicationDAO.ReadApplication().ApplicationId + 1,
                FirstName = applicationJson.Value<string>("FirstName"),
                Lastname = applicationJson.Value<string>("LastName"),
                Email = applicationJson.Value<string>("Email"),
                PositionId = PositionDAO.ReadPosition(applicationJson.Value<string>("PositionName")).PositionId,
                ResumePath = Path.Combine(Directory.GetCurrentDirectory(), "../files", applicationJson.Value<string>("ResumePath"))
            };

            ApplicationDAO.CreateApplication(application);
        }

        // POST api/application/file
        [HttpPost("file")]
        public void PostFile([FromForm] IFormFile file) 
        {
            
            string path = Path.Combine(
                        Directory.GetCurrentDirectory(), "../files", 
                        file.FileName);

            if(!Directory.Exists(path)){
                Directory.CreateDirectory(path);
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        // DELETE api/application/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          ApplicationDAO.DeleteApplication(id);
        }
    }
}
