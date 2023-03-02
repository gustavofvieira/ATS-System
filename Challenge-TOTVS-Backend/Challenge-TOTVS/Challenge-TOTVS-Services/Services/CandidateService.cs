using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Services.Services
{
    public class CandidateService : ICandidateService 
    {
        private readonly  ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository) =>
        _candidateRepository = candidateRepository;

        public async Task Add(Candidate candidate)
        {
            await _candidateRepository.Add(candidate);
        }

        public Task<IEnumerable<Candidate>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Candidate obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Candidate obj)
        {
            throw new NotImplementedException();
        }
    }
}
