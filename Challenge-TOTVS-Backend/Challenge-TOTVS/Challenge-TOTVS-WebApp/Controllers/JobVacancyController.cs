using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {
        private readonly IJobVacancyService _jobVacancyService;

        public JobVacancyController(IJobVacancyService jobVacancyService) => _jobVacancyService = jobVacancyService;
        // GET: api/<VacancyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VacancyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("getAllJobVacancy")]
        public async Task<IActionResult> GetAll()
        {

            var totalOrders = await _jobVacancyService.GetAll();
            return Ok(totalOrders);
        }

        // POST api/<VacancyController>
        [HttpPost]
        public async Task Post(JobVacancy value)
        {
            await _jobVacancyService.Add(value);
        }

        // PUT api/<VacancyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VacancyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
