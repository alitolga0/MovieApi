using FluentValidation;
using MovieRestApi.Models;
namespace MovieRestApi.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MinimumLength(2);
            RuleFor(m => m.DirectorId).NotEmpty();
        }
    }
}
