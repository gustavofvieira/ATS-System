using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Challenge.TOTVS.Services.Services
{
    public class JobApplicationService : IJobApplicationService
    {

        private readonly ILogger<JobApplicationService> _logger;
        private readonly IJobVacancyRepository _jobVacancyRepository;
        private readonly ICandidateRepository _candidateRepository;

        public JobApplicationService(ILogger<JobApplicationService> logger, IJobVacancyRepository jobVacancyRepository, ICandidateRepository candidateRepository)
        {
            _logger = logger;
            _jobVacancyRepository = jobVacancyRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task<List<JobApplication>> JobApplications()
        {
            _logger.LogInformation("[{Mehtod}] - Started", nameof(JobApplications));
            var jobApplications = new List<JobApplication>();
            var jobvacs = await _jobVacancyRepository.GetAll();

            foreach (var job in jobvacs)
            {
                var jobApp = new JobApplication();
                jobApp.Title = job.Title;
                jobApp.Candidates = new List<Candidate>();
                foreach (var candidateId in job.CandidateIds)
                {
                    var candidate = await _candidateRepository.GetById(candidateId);
                    jobApp.Candidates.Add(candidate);
                }

                jobApplications.Add(jobApp);
            }
            _logger.LogInformation("[{Mehtod}] - Finish", nameof(JobApplications));

            return jobApplications;
        }
    }
}
