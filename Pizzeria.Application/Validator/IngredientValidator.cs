using FluentValidation;
using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Validator
{
    public class IngredientValidator : AbstractValidator<IngredientDto>
    {
        public IngredientValidator()
        {
            RuleFor(ingredient => ingredient.Name)
                .NotEmpty().WithMessage("Name is empty.");

            RuleFor(ingredient => ingredient.BaseCost)
                .GreaterThan(0).WithMessage("BaseCost must be greater than 0.");
        }
    }
}
