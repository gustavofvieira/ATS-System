using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private readonly ATSContext _context;
        public JobVacancyRepository(
            ATSContext context) =>
            _context = context;
        public async Task Add(JobVacancy jobVacancy) =>        
            await _context.JobVacancy.InsertOneAsync(jobVacancy);
        

        public async Task<IEnumerable<JobVacancy>> GetAll()  =>
            await _context.JobVacancy.AsQueryable().ToListAsync();

        public Task<JobVacancy> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(JobVacancy obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(JobVacancy obj)
        {
            throw new NotImplementedException();
        }
    }
}
