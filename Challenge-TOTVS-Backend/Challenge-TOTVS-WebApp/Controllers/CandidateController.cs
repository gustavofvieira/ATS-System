using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateService _candidateService;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        [HttpPost("UploadCVFile")]
        public async Task<ActionResult> UploadCVFile(Guid id, IFormFile formFile)
        {
            await _candidateService.UploadCVFile(id,formFile);
            _logger.LogInformation("UploadFile" + formFile.FileName);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var candidates = await _candidateService.GetAll();
            return Ok(candidates);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var candidate = await _candidateService.GetById(id);
            return Ok(candidate);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(Candidate candidate)
        {
            await _candidateService.Add(candidate);
            return Ok();
        }

        [HttpPost("CreateCandidate")]
        public async Task<IActionResult> Post(CandidateVM candidate)
        {
            await _candidateService.CreateCandidate(candidate);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(Candidate candidate)
        {
            await _candidateService.Update(candidate);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _candidateService.Remove(id);
            return Ok();
        }
    }
}
