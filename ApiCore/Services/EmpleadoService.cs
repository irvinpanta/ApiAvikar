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
    public class EmpleadoService : IBaseService<EmpleadoModel>
    {
        private readonly IBaseRepository<EmpleadoModel> _empleadoRepository;
        private readonly IMapper _mapper;
        public EmpleadoService(IBaseRepository<EmpleadoModel> empleadoRepository,
                                IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmpleadoModel>> GetAll(FiltersQuery filters)
        {
            var responseModel = await _empleadoRepository.GetAll();
            //var responseDto = _mapper.Map<IEnumerable<EmpleadoModel>>(responseModel);
            return responseModel;
        }

        public async Task<EmpleadoModel> GetById(int id)
        {
            var responseModel = await _empleadoRepository.GetById(id);
            //var responseDto = _mapper.Map<EmpleadoModel>(responseModel);
            return responseModel;
        }

        public Task<string> Save(EmpleadoModel entity)
        {
            return _empleadoRepository.Save(entity);
        }

        public Task<string> Update(EmpleadoModel entity)
        {
            throw new NotImplementedException();
        }
        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
