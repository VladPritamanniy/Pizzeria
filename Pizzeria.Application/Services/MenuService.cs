using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.Repositories;
using Pizzeria.Core.Specifications;

namespace Pizzeria.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Pizza> _repository;
        private readonly IMapper _mapper;
        private readonly IPizzaFactory _factory;

        public MenuService(IRepository<Pizza> repository, IMapper mapper, IPizzaFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _factory = factory;
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

        public async Task CreatePizza(PizzaCreateDto dto)
        {
            var pizza = await _factory.Create(dto);
            var result = await _repository.AddAsync(pizza);
            if (result.Id <= 0)
            {
                throw new PizzaNotCreatedException();
            }
        }
    }
}
