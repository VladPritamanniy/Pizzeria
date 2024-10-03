using AutoMapper;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Entities;
using Pizzeria.Core.Repositories;

namespace Pizzeria.Application.Services
{
    public class SizeService : ISizeService
    {
        private readonly IRepository<Size> _repository;
        private readonly IMapper _mapper;

        public SizeService(IRepository<Size> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SizeDto>> GetAllSizes()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<List<SizeDto>>(result);
        }
    }
}
