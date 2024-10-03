using FluentValidation;
using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Validator
{
    public class PizzaValidator : AbstractValidator<PizzaDto>
    {
        public PizzaValidator()
        {
            RuleFor(pizza => pizza.Name)
                .NotEmpty()
                .WithMessage("Name is empty.");
        }
    }
}
