using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.TOTVS.Setup.Extensions
{
    public static class ValidatorsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<User>, UserValidator>();
        }
    }
}
