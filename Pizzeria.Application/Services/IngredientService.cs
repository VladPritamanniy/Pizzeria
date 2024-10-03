using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.Repositories;

namespace Pizzeria.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> _repository;
        private readonly IMapper _mapper;

        public IngredientService(IRepository<Ingredient> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<IngredientDto>> GetAllIngredients()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<List<IngredientDto>>(result);
        }

        public async Task<IngredientDto> CreateIngredient(IngredientDto dto)
        {
            var entity = await _repository.AddAsync(_mapper.Map<Ingredient>(dto));
            if (entity.Id <= 0)
            {
                throw new IngredientNotCreatedException();
            }

            return _mapper.Map<IngredientDto>(entity);
        }
    }
}
