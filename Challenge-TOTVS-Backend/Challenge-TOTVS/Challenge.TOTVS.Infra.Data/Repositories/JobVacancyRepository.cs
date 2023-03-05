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

        public async Task Remove(Guid id) => await _context.JobVacancy.DeleteOneAsync(j => j.JobVacancyId.Equals(id));

        public async Task Update(JobVacancy jobVacancy) =>
        await _context.JobVacancy.FindOneAndUpdateAsync(
                c => c.JobVacancyId.Equals(jobVacancy.JobVacancyId),
                Builders<JobVacancy>.Update.Combine(
                    Builders<JobVacancy>.Update.Set(j => j.Title, jobVacancy.Title),
                    Builders<JobVacancy>.Update.Set(j => j.Description, jobVacancy.Description),
                    Builders<JobVacancy>.Update.Set(j => j.StartDate, jobVacancy.StartDate),
                    Builders<JobVacancy>.Update.Set(j => j.ExpirateDate, jobVacancy.ExpirateDate),
                    Builders<JobVacancy>.Update.Set(j => j.UpdatedAt, DateTime.UtcNow),
                    Builders<JobVacancy>.Update.Set(j => j.CandidateIds, jobVacancy.CandidateIds)
                )
            );

        public async Task JobApplication(JobVacancy jobVacancy) =>
        await _context.JobVacancy.FindOneAndUpdateAsync(
                c => c.JobVacancyId.Equals(jobVacancy.JobVacancyId),
                Builders<JobVacancy>.Update.Combine(
                    Builders<JobVacancy>.Update.Set(j => j.CandidateIds, jobVacancy.CandidateIds)
                ));

        public async Task JobApplication2(Guid jobVacancyId, Guid candidateId) =>
            await _context
            .JobVacancy
            .UpdateOneAsync(c => c.JobVacancyId == jobVacancyId,
                Builders<JobVacancy>.Update.AddToSet(j => j.CandidateIds, candidateId));
    }
}
