using Api.Core.Filters;
using Api.Core.Repositories;
using Api.Models.Dto;
using Api.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public class RolService : IBaseService<RolDto>
    {
        private readonly IBaseRepository<RolModel> _rolRepository;
        private readonly IMapper _mapper;

        private string message;
        public RolService(IBaseRepository<RolModel> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RolDto>> GetAll(FiltersQuery filters)
        {
            var responseModel = await _rolRepository.GetAll();

            if(filters.Descripcion != null){
                responseModel = responseModel.Where(x => x.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
            }

            var responseDto = _mapper.Map<IEnumerable<RolDto>>(responseModel);
            return responseDto;

        }

        public async Task<RolDto> GetById(int id)
        {
            var responseModel = await _rolRepository.GetById(id);
            var responseDto = _mapper.Map<RolDto>(responseModel);

            if (_rolRepository.ExistsById(id)){
                return responseDto;
            }else{
                return null;
            }
        }

        public Task<string> Save(RolDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(RolDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
