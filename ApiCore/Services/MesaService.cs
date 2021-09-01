using Api.Core.Custom;
using Api.Core.Exceptions;
using Api.Core.Filters;
using Api.Core.Repositories;
using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public class MesaService : IMesaService
    {
        private readonly IBaseRepository<MesaModel> _mesaRepository;
        private readonly IBaseRepository<SalonModel> _salonRepository;

        private readonly IMapper _mapper;
        private readonly PaginationOptions _paginationOptions;
        private string message;
        public MesaService(IBaseRepository<MesaModel> mesaRepository, 
                            IMapper mapper, 
                            IBaseRepository<SalonModel> salonRepository,
                            IOptions<PaginationOptions> options)
        {
            _mesaRepository = mesaRepository;
            _salonRepository = salonRepository;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }
        
        public async Task<PaginatedList<MesaDto>> GetAll(FiltersQuery filters)
        {
            
            filters.PageIndex = filters.PageIndex == 0 ? _paginationOptions.DefaultPageIndex : filters.PageIndex;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaulttPageSize : filters.PageSize;

            var responseModel = await _mesaRepository.GetAll();

            if (filters.Descripcion != null)
            {
                responseModel = responseModel.Where(x => x.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
            }

            var responseDto = _mapper.Map<IEnumerable<MesaDto>>(responseModel); //Mappeamos de MesaModel a MesaDto
            var paginatedResponse = PaginatedList<MesaDto>.Create(responseDto, filters.PageIndex, filters.PageSize);

            return paginatedResponse;
        }

        public async Task<MesaDto> GetById(int id)
        {
            var responseModel = await _mesaRepository.GetById(id);

            var responseDto = _mapper.Map<MesaDto>(responseModel); //Mappeamos de MesaModel a MesaDto

            if (_mesaRepository.ExistsById(id)){
                return responseDto;
            }
            else{
                throw new MessageException("Registro no existe");
            }
        }

        public async Task<string> Save(MesaDto entity)
        {
            try{
                var responseModel = _mapper.Map<MesaModel>(entity); //Mappeamos de MesaDto a MesaModel

                if (!(_salonRepository.ExistsById(entity.Salon))){
                    message = "Salon no existe";
                }else if (_mesaRepository.ExistsByDescripcion(entity.Descripcion)){ //Verifica si no existe por Descripcion
                    message = "Registro ya existe";
                }else{
                    message = await _mesaRepository.Save(responseModel);
                }

                return message; //Retorna un mensaje

            }catch (Exception ex){
                return ex.Message;
            }
            
        }

        public async Task<string> Update(MesaDto entity)
        {
            try
            {
                var responseModel = _mapper.Map<MesaModel>(entity); //Mappeamos de MesaDto a MesaModel

                if (!(_salonRepository.ExistsById(entity.Salon))){
                    message = "Salon no existe";
                }else if (_mesaRepository.ExistsById(entity.Id)){ //Verificar si no existe por ID
                    message = await _mesaRepository.Update(responseModel);
                }else{
                    message = "Registro no existe";
                }

            }catch (Exception ex){
                message = ex.Message;
            }

            return message; //Retorna un mensaje
        }

        public async Task<string> Delete(int id)
        {
            if (_mesaRepository.ExistsById(id)){
                message = await _mesaRepository.Delete(id);
            }else{
                message = "Registro no existe";
            }

            return message;
        }
    }
}
