using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ATSContext _context;
        public JobApplicationRepository(
            ATSContext context) =>
            _context = context;

        public async Task Add(JobApplication jobApplication) => await _context.JobApplication.InsertOneAsync(jobApplication);

        public async Task<List<JobApplication>> GetAll() => await _context.JobApplication.AsQueryable().ToListAsync();

        public async Task<JobApplication> GetById(Guid id) => await _context.JobApplication.AsQueryable().Where(c => c.JobApplicationId == id).FirstOrDefaultAsync();

        public async Task Remove(Guid id) =>
            await _context
            .JobApplication
            .DeleteOneAsync(c => c.JobApplicationId == id);

        public async Task Update(JobApplication jobApplication) =>
            await _context
            .JobApplication
            .UpdateOneAsync(c => c.JobApplicationId == jobApplication.JobApplicationId,
                Builders<JobApplication>.Update.Set(j => j, jobApplication));
    }
}
