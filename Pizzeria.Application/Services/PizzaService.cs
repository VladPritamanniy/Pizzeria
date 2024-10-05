using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.Repositories;
using Pizzeria.Core.Specifications;

namespace Pizzeria.Application.Services
{
    public class PizzaService : IPizzaService
    {
        public readonly IRepository<Pizza> _repository;
        public readonly IMapper _mapper;
        private readonly IPizzaFactory _factory;

        public PizzaService(IRepository<Pizza> repository, IMapper mapper, IPizzaFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<List<PizzaDisplayOrderingDto>> GetPizzaForChangingDisplayOrder()
        {
            var spec = new PizzaSelectSpecification();
            var result = await _repository.ToListAsync(spec);
            return _mapper.Map<List<PizzaDisplayOrderingDto>>(result);
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

        public async Task ChangePizzaDisplayOrdering(List<PizzaDisplayOrderingDto> dto)
        {
            var pizzas = await _repository.GetAll();
            foreach (var pizza in pizzas)
            {
                var newPizzaOrder = dto.Find(p => p.Id == pizza.Id)?.DisplayOrder;

                if (newPizzaOrder != null)
                    pizza.DisplayOrder = newPizzaOrder;
            }

            await _repository.UpdateRangeAsync(pizzas);
        }
    }
}
