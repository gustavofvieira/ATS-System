using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
  
        public Task<IEnumerable<Candidate>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetById(string id) => await _context.Candidate.AsQueryable().Where(c => c._id == id).FirstOrDefaultAsync();

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
