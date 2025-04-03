using FluentValidation;
using MovieRestApi.Models;
namespace MovieRestApi.Validators
{

    public class DirectorValidator : AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty()
                .Must(name => name.Length >= 2)
                .WithMessage("First name must be at least 2 characters long.");
            RuleFor(d => d.LastName).NotEmpty().MinimumLength(2);
        }
    }
}
