using FluentValidation;
using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Validator
{
    public class PizzaCreateValidator : AbstractValidator<PizzaCreateDto>
    {
        public PizzaCreateValidator()
        {
            RuleFor(pizza => pizza.Name)
                .NotEmpty()
                .WithMessage("Name is empty.");
            RuleFor(pizza => pizza.PizzaImg)
                .NotEmpty()
                .WithMessage("PizzaImg is empty.");
            RuleFor(pizza => pizza.IngredientIds.Length)
                .GreaterThan(0)
                .WithMessage("IngredientIds Length <= 0.");
        }
    }
}
