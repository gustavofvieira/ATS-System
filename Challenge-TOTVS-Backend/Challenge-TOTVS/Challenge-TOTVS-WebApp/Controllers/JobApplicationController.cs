using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly ILogger<JobApplicationController> _logger;
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationController(ILogger<JobApplicationController> logger, IJobApplicationService jobApplicationService)
        {
            _logger = logger;
            _jobApplicationService = jobApplicationService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(GetAll));
            var jobApps = await _jobApplicationService.GetAll();
            return Ok(jobApps);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(GetById));
            var jobApp = await _jobApplicationService.GetById(id);
            return Ok(jobApp);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JobApplication jobApplication)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Create));
            await _jobApplicationService.Add(jobApplication);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(JobApplication jobApplication)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Update));
            await _jobApplicationService.Update(jobApplication);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(Delete));
            await _jobApplicationService.Remove(id);
            return Ok();
        }
    }
}
