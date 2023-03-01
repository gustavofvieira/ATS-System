using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class JobApplicationRepository : IJobApplicationRepository
    {
        public Task Add(JobApplication obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        public JobApplication GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(JobApplication obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(JobApplication obj)
        {
            throw new NotImplementedException();
        }
    }
}
