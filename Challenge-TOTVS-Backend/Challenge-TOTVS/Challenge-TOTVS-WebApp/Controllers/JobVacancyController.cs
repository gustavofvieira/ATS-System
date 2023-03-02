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
        private readonly ILogger<JobVacancyController> _logger;
        private readonly IJobVacancyService _jobVacancyService;

        public JobVacancyController(ILogger<JobVacancyController> logger, IJobVacancyService jobVacancyService)
        {
            _logger = logger;
            _jobVacancyService = jobVacancyService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(GetAll));
            var jobApps = await _jobVacancyService.GetAll();
            return Ok(jobApps);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(GetById));
            var jobApp = await _jobVacancyService.GetById(id);
            return Ok(jobApp);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JobVacancy jobVacancy)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Create));
            await _jobVacancyService.Add(jobVacancy);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(JobVacancy jobVacancy)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Update));
            await _jobVacancyService.Update(jobVacancy);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Delete));
            await _jobVacancyService.Remove(id);
            return Ok();
        }
    }
}
