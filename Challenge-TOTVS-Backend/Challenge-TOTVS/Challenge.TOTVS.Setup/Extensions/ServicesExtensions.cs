using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.TOTVS.Setup.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IJobVacancyService, JobVacancyService>()
                .AddScoped<IJobApplicationService, JobApplicationService>()
                .AddScoped<ICandidateService, CandidateService>();
        }
    }
}
