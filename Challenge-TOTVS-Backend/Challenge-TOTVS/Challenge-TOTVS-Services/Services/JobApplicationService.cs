using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Services.Services
{
    public class JobApplicationService : IJobApplicationService
    {

        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplicationService(IJobApplicationRepository jobApplicationRepository) =>
        _jobApplicationRepository = jobApplicationRepository;

        public async Task Add(JobApplication jobApplication) => await _jobApplicationRepository.Add(jobApplication);

        public async Task<List<JobApplication>> GetAll() => await _jobApplicationRepository.GetAll();

        public async Task<JobApplication> GetById(Guid id) => await _jobApplicationRepository.GetById(id);

        public async Task Remove(Guid id) => await _jobApplicationRepository.Remove(id);

        public async Task Update(JobApplication jobApplication) => await _jobApplicationRepository.Update(jobApplication);
    }
}
