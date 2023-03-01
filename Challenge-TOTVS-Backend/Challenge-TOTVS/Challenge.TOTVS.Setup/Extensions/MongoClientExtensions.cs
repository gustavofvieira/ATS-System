using Challenge.TOTVS.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Challenge.TOTVS.Setup.Extensions
{
    public static class MongoClientExtensions
    {
        public static IServiceCollection AddMongoClientConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        => services.AddSingleton(_ =>
        {
            var settings = MongoClientSettings.FromUrl(
                new MongoUrl(configuration.GetConnectionString("DatabaseServer"))
            );

            var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return new MongoClient(settings);
        });

        public static IServiceCollection AddATSContext(this IServiceCollection services, IConfiguration config)
        {
            return services
                 .AddScoped(sp =>
                    new ATSContext(
                        sp.GetRequiredService<MongoClient>().GetDatabase(config.GetConnectionString("ChallengeATS"))
                    )
                );
        }
    }
}
