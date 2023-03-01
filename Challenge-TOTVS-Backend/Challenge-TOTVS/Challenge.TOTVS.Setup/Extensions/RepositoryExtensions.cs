using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.TOTVS.Setup.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddScoped<IJobVacancyRepository, JobVacancyRepository>()
                .AddScoped<IJobApplicationRepository, JobApplicationRepository>()
                .AddScoped<ICandidateRepository, CandidateRepository>();
        }
    }
}
