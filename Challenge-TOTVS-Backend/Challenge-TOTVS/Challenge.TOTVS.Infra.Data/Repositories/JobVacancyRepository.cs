using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class JobVacancyRepository : IJobVacancyRepository
    {
        public Task Add(JobVacancy obj)
        {
            throw new NotImplementedException();
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
