using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Services.Services
{
    public class JobVacancyService : IJobVacancyService
    {

        private readonly IJobVacancyRepository _jobVacancyRepository;

        public JobVacancyService(IJobVacancyRepository jobVacancyRepository) =>
        _jobVacancyRepository = jobVacancyRepository;

        public async Task Add(JobVacancy jobVacancy)
        {
           await _jobVacancyRepository.Add(jobVacancy);
        }

        public async Task<IEnumerable<JobVacancy>> GetAll() => await _jobVacancyRepository.GetAll();

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
