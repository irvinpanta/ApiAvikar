using Api.Core.Repositories;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Dto;
using Api.Models.Entities;
using AutoMapper;
using Api.Core.Filters;

namespace Api.Core.Services
{
    public class SalonService : IBaseService<SalonDto>
    {
        private readonly IBaseRepository<SalonModel> _salonRepository;
        private readonly IMapper _mapper;
        private string message;
               
        public SalonService(IBaseRepository<SalonModel> salonRepository, IMapper mapper)
        {
            _salonRepository = salonRepository;
            _mapper = mapper;
        }

        //Metodo para Mostrr todos los registros
        public async Task<IEnumerable<SalonDto>> GetAll(FiltersQuery filters)
        {
            var responseModel = await _salonRepository.GetAll(); //Cargamos todos los registros
            var responseDto = _mapper.Map<IEnumerable<SalonDto>>(responseModel); //Mappeamos de SalonModel a SalonDto
            return responseDto; //Retornamos el resultado mapeado
        }

        //Metodo para Mostrar los registros por Id
        public async Task<SalonDto> GetById(int id)
        {
            var responseModel = await _salonRepository.GetById(id);
            var responseDto = _mapper.Map<SalonDto>(responseModel); //Mappeamos de SalonModel a SalonDto

            if (_salonRepository.ExistsById(id)){
                return responseDto;
            }
            else{
                return null;
            }
        }

        //Metodo para Guardar registros
        public async Task<string> Save(SalonDto entity)
        {
            var entityModel = _mapper.Map<SalonModel>(entity); //Mappeamos de SalonDto a SalonModel

            if (_salonRepository.ExistsByDescripcion(entity.Descripcion)){ //Verifica Si existe por Descripcion
                message = "Registro ya existe"; //Registro ya existe
            }else{
                message = await _salonRepository.Save(entityModel);//
            }

            return message; //Retornamos un mensaje
        }

        public async Task<string> Update(SalonDto entity)
        {
            var entityModel = _mapper.Map<SalonModel>(entity); //Mappeamos de SalonDto a SalonModel

            if (!(_salonRepository.ExistsById(entity.Id))) { //Verificamos Si no existe registro
                message = "Registro no existe";

            //}else if(_salonRepository.ExistsByDescripcion(entity.Descripcion)) {
            //    message = "Registro ya existe";

            //}else if(!(_salonRepository.ExistsByDescripcion(entity.Descripcion) && !(_salonRepository.ExistsById(entity.Salon)))){
            //    message = "Registro ya existe"; //Registro ya existe

            }else{
                message = await _salonRepository.Update(entityModel);
            }

            return message;
        }

        public async Task<string> Delete(int id)
        {
            if (_salonRepository.ExistsById(id)){
                message = await _salonRepository.Delete(id);
            }else{
                message = "Registro no existe"; //Registro a eliminar no existe
            }

            return message;
        }
    }
}
