using FluentValidation;
using MovieRestApi.Models;
namespace MovieRestApi.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
