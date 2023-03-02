using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        // GET: api/<JobApplicationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("UploadCVFile")]
        public IActionResult UploadCVFile(IFormFile formFile)
        {
            //_logger.LogInformation("UploadFile" + formFile.FileName);
            return Ok(formFile.FileName);
        }


        // GET api/<JobApplicationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobApplicationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobApplicationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobApplicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
