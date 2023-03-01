using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CandidateRepository : ICandidateRepository
    {

        private readonly ATSContext _context;
        public CandidateRepository(
            ATSContext context) =>
            _context = context;
        

        public async Task Add(Candidate candidate) => await _context.Candidate.InsertOneAsync(candidate);
  
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
    }
}
