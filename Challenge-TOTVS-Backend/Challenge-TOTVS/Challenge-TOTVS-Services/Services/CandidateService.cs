using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Challenge.TOTVS.Services.Services
{
    public class CandidateService : ICandidateService 
    {
        private readonly  ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository) =>
        _candidateRepository = candidateRepository;

        public void UploadCVFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Candidate candidate) => await _candidateRepository.Add(candidate);

        public Task<List<Candidate>> GetAll() => _candidateRepository.GetAll();

        public Task<Candidate> GetById(Guid id) => _candidateRepository.GetById(id);

        public async Task Remove(Guid id) => await _candidateRepository.Remove(id);
        
        public Task Update(Candidate candidate) => _candidateRepository.Update(candidate);
    }
}
