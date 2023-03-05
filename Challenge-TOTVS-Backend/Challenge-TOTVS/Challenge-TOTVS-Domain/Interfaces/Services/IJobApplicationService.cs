using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IJobApplicationService
    {
        Task<List<JobApplication>> JobApplications();
    }
}
