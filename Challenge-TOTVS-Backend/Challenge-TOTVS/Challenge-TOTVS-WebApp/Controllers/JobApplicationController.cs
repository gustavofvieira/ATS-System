using Challenge.TOTVS.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> JobApplications()
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(JobApplications));
            var list = await _jobApplicationService.JobApplications();
            return Ok(list);
        }

        [HttpGet("GetCandidatesByJobId")]
        public async Task<IActionResult> GetCandidatesByJobId(Guid jobId)
        {
            _logger.LogInformation("[{Method}] - Started ", nameof(GetCandidatesByJobId));
            var list = await _jobApplicationService.GetCandidatesByJobId(jobId);
            return Ok(list);
        }
    }
}
