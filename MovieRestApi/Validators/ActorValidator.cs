using FluentValidation;
using MovieRestApi.Models;
namespace MovieRestApi.Validators
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
        }
    }
}
