using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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

        public void UploadCVFile(IFormFile formFile)
        {
            throw new NotImplementedException();
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
