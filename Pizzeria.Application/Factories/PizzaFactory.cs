using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;

namespace Pizzeria.Application.Factories
{
    public class PizzaFactory : IPizzaFactory
    {
        private readonly ICloudinaryService _cloudinaryService;

        public PizzaFactory(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Pizza> Create(PizzaCreateDto dto)
        {
            var imgUploadResult = await _cloudinaryService.UploadAsync(dto.PizzaImg);

            var pizza = new Pizza
            {
                Name = dto.Name,
                PublicImageId = imgUploadResult.PublicId
            };
            pizza.PizzaIngredients = new HashSet<PizzaIngredient>();
            pizza.PizzaPrices = new HashSet<PizzaPrice>();

            foreach (var ingredientId in dto.IngredientIds)
            {
                pizza.PizzaIngredients.Add(new PizzaIngredient
                {
                    IngredientId = ingredientId
                });
            }

            foreach (var sizeWithPrice in dto.SizesWithPrice)
            {
                pizza.PizzaPrices.Add(new PizzaPrice
                {
                    SizeId = sizeWithPrice.Id,
                    Price = new Price
                    {
                        Value = decimal.Parse(sizeWithPrice.Price)
                    }
                });
            }

            return pizza;
        }
    }
}
