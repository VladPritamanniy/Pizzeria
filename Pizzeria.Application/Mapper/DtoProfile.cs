using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Core.Entities;

namespace Pizzeria.Application.Mapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Pizza, PizzaDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Price, PriceDto>().ReverseMap();
            CreateMap<Size, SizeDto>().ReverseMap();
            CreateMap<PizzaIngredient, PizzaIngredientDto>().ReverseMap();
            CreateMap<PizzaPrice, PizzaPriceDto>().ReverseMap();
            CreateMap<Pizza, PizzaDisplayOrderingDto>().ReverseMap();
        }
    }
}
