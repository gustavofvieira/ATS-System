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

        //public void Configure()
        //{

        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(Configuration);
            services.AddRepositories(Configuration);
            services
                .AddMongoClientConfiguration(Configuration)
                .AddATSContext(Configuration);


        }
    }
}