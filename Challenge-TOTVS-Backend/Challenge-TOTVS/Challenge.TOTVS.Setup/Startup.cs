using Challenge.TOTVS.Setup.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Setup
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
            services
                .AddMongoClientConfiguration(Configuration)
                .AddATSContext(Configuration);


        }
    }
}