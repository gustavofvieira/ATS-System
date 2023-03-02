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

        public async Task Add(JobVacancy jobVacancy) => await _jobVacancyRepository.Add(jobVacancy);
        
        public async Task<List<JobVacancy>> GetAll() => await _jobVacancyRepository.GetAll();

        public async Task<JobVacancy> GetById(Guid id) => await _jobVacancyRepository.GetById(id);

        public async Task Remove(Guid id) => await _jobVacancyRepository.Remove(id);

        public async Task Update(JobVacancy jobVacancy) => await _jobVacancyRepository.Update(jobVacancy);
    }
}
