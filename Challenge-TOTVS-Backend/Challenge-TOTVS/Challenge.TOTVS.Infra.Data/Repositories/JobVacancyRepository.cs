using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
        

        public async Task<List<JobVacancy>> GetAll()  =>
            await _context.JobVacancy.AsQueryable().ToListAsync();

        public async Task<JobVacancy> GetById(Guid id) => await _context.JobVacancy.AsQueryable().Where(c => c.JobVacancyId == id).FirstOrDefaultAsync();

        public async Task Remove(Guid id) => await _context.JobVacancy.DeleteOneAsync(id.ToString());

        public async Task Update(JobVacancy jobVacancy) =>
            await _context
            .JobVacancy
            .UpdateOneAsync(c => c.JobVacancyId == jobVacancy.JobVacancyId,
                Builders<JobVacancy>.Update.Set(j => j, jobVacancy));
    }
}
