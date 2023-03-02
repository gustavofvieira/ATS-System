﻿using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }


        // GET: api/<CandidateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Associar o arquivo ao collection Candidate
        [HttpPost("UploadCVFile")]
        public IActionResult UploadCVFile(IFormFile formFile)
        {
            //_logger.LogInformation("UploadFile" + formFile.FileName);
            return Ok(formFile.FileName);
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<CandidateController>
        //[HttpPost]
        //public void Post(Candidate candidate)
        //{

        //}

        // POST api/<CandidateController>
        [HttpPost]
        public async Task Post(Candidate candidate)
        {
            await _candidateService.Add(candidate);
        }

        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
