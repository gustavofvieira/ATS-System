using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Services.Services
{
    public class CandidateService : ICandidateService // BaseService<Candidate>, 
    {
        private readonly  ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository) =>
        _candidateRepository = candidateRepository;

        public async Task Add(Candidate obj)
        {
            await _candidateRepository.Add(obj);
        }

        public IEnumerable<Candidate> GetAll()
        {
            throw new NotImplementedException();
        }

        public Candidate GetById(int id)
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
        //public async Task Add(Candidate candidate)
        //{
        //    await _candidateRepository.Add(candidate);
        //}

        //public IEnumerable<Candidate> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Candidate GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Remove(Candidate obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(Candidate obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
