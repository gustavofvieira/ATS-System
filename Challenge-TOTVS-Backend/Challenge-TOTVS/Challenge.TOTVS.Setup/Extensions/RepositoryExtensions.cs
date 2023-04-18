using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Repositories.Auth;
using Challenge.TOTVS.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.TOTVS.Setup.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IJobVacancyRepository, JobVacancyRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRecoverPasswordRepository, RecoverPasswordRepository>()
                .AddScoped<ICandidateRepository, CandidateRepository>();
        }
    }
}
