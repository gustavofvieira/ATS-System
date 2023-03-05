using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Services.Services
{
    public class CandidateService : ICandidateService 
    {
        private readonly  ILogger<CandidateService> _logger;
        private readonly  ICandidateRepository _candidateRepository;

        public CandidateService(ILogger<CandidateService> logger, ICandidateRepository candidateRepository)
        {
            _logger = logger;
            _candidateRepository = candidateRepository;
        }

        public async Task UploadCVFile(Guid id, IFormFile formFile)
        {
            var filePath = $@"c:\CVsUploads\{Guid.NewGuid().ToString().Replace("-","")}-{formFile.FileName}";
            ExistsPathCVsUploads();
            await using var stream = new FileStream(filePath, FileMode.CreateNew);
            await formFile.CopyToAsync(stream);
            var candidate = await _candidateRepository.GetById(id);
            candidate.FilePath = filePath;
            await _candidateRepository.UploadCVFile(candidate);
        }

        private void ExistsPathCVsUploads()
        {
            if (!Directory.Exists($@"c:\CVsUploads"))
            {
                Directory.CreateDirectory($@"c:\CVsUploads");
            }
        }

        public async Task Add(Candidate candidate) 
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(Add));
            await _candidateRepository.Add(candidate);
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(Add));
        }

        public async Task<List<Candidate>> GetAll()
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(GetAll));
            var allCandidates = await _candidateRepository.GetAll();
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(GetAll));
            return allCandidates;
        } 

        public async Task<Candidate> GetById(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(GetById),id);
            var candidate =  await _candidateRepository.GetById(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(GetById), id);
            return candidate;
        }
        
        public async Task Update(Candidate candidate)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Update), candidate.CandidateId);
            await _candidateRepository.Update(candidate);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Update), candidate.CandidateId);
        }

        public async Task Remove(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Remove), id);
            await _candidateRepository.Remove(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Remove), id);
        }
    }
}
