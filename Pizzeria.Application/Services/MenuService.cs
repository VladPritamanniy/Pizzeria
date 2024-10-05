using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;
using Pizzeria.Core.Repositories;
using Pizzeria.Core.Specifications;

namespace Pizzeria.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Pizza> _repository;
        private readonly IMapper _mapper;

        public MenuService(IRepository<Pizza> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MenuDto> GetAllPizzas()
        {
            var spec = new PizzaSpecification();
            var result = await _repository.ToListAsync(spec);
            var menu = new MenuDto
            {
                Pizzas = _mapper.Map<List<PizzaDto>>(result),
            };
            return menu;
        }
    }
}
