using Challenge.TOTVS.Domain.Models;
using FluentValidation;

namespace Challenge.TOTVS.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 50);

            RuleFor(x => x.EmailAddress)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();

        }
    }
}
