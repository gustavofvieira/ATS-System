using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Repositories
{
    public interface IJobVacancyRepository : IBaseRepository<JobVacancy>
    {
        Task JobApplication(JobVacancy jobVacancy);
        Task JobApplication2(Guid jobVacancyId, Guid candidateId);
    }
}
