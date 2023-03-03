using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Challenge.TOTVS.Services.Services
{
    public class JobApplicationService : IJobApplicationService
    {

        private readonly ILogger<JobApplicationService> _logger;
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplicationService(ILogger<JobApplicationService> logger, IJobApplicationRepository jobApplicationRepository)
        {
            _logger = logger;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task Add(JobApplication jobApplication)
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(Add));
            await _jobApplicationRepository.Add(jobApplication);
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(Add));
        }

        public async Task<List<JobApplication>> GetAll()
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(GetAll));
            var allJobApplications = await _jobApplicationRepository.GetAll();
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(GetAll));
            return allJobApplications;
        }

        public async Task<JobApplication> GetById(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(GetById), id);
            var jobApplication = await _jobApplicationRepository.GetById(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(GetById), id);
            return jobApplication;
        }

        public async Task Update(JobApplication jobApplication)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Update), jobApplication.JobApplicationId);
            await _jobApplicationRepository.Update(jobApplication);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Update), jobApplication.JobApplicationId);
        }

        public async Task Remove(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(Remove), id);
            await _jobApplicationRepository.Remove(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(Remove), id);
        }
    }
}
