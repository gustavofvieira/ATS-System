using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IJobVacancyService :  IBaseService<JobVacancy>
    {
        Task JobApplication(Guid jobVacancyId, Guid candidateId);
    }
}
