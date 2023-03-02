using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
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
        public async Task Add(JobVacancy jobVacancy)
        {
            await _context.JobVacancy.InsertOneAsync(jobVacancy);
        }

        public IEnumerable<JobVacancy> GetAll()
        {
            throw new NotImplementedException();
        }

        public JobVacancy GetById(int id)
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
