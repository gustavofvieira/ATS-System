using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Challenge.TOTVS.Services.Services
{
    public class JobVacancyService : IJobVacancyService
    {

        private readonly ILogger<JobVacancyService> _logger;
        private readonly IJobVacancyRepository _jobVacancyRepository;

        public JobVacancyService(ILogger<JobVacancyService> logger, IJobVacancyRepository jobVacancyRepository)
        {
            _logger = logger;
            _jobVacancyRepository = jobVacancyRepository;
        }

        public async Task Add(JobVacancy jobApplication)
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(Add));
            await _jobVacancyRepository.Add(jobApplication);
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(Add));
        }

        public async Task<List<JobVacancy>> GetAll()
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(GetAll));
            var allJobVacancys = await _jobVacancyRepository.GetAll();
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(GetAll));
            return allJobVacancys;
        }

        public async Task<JobVacancy> GetById(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(GetById), id);
            var jobVacancy = await _jobVacancyRepository.GetById(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(GetById), id);
            return jobVacancy;
        }

        public async Task Update(JobVacancy jobVacancy)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Update), jobVacancy.JobVacancyId);
            await _jobVacancyRepository.Update(jobVacancy);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Update), jobVacancy.JobVacancyId);
        }

        public async Task Remove(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Remove), id);
            await _jobVacancyRepository.Remove(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Remove), id);
        }
    }
}
