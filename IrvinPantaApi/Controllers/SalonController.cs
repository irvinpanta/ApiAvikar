using Api.Core.Filters;
using Api.Core.Response;
using Api.Core.Services;
using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrvinPantaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController: ControllerBase
    {
 
        private readonly IBaseService<SalonDto> _salonService;
        private ObjectResult status;
        public SalonController(IBaseService<SalonDto> salonService)
        {
            _salonService = salonService;
        }

        [HttpGet] //Mostrar todos los registros
        public async Task<IActionResult> GetAll([FromQuery]FiltersQuery filters)
        {
            var response = await _salonService.GetAll(filters);

            //var reponseDto = response.Select(x => new SalonDto
            //{
            //    Salon = x.Salon,
            //    Descripcion = x.Descripcion,
            //    Capacidad = x.Capacidad,
            //    Activo = x.Activo
            //});

            //var apiResponse = new ApiResponseSuccess<IEnumerable<SalonDto>>(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _salonService.GetById(id);
            //var responseDto = new SalonDto
            //{
            //    Salon = response.Salon,
            //    Descripcion = response.Descripcion,
            //    Capacidad = response.Capacidad,
            //    Activo = response.Activo
            //};
            
            var apiResponse = new ApiResponseSuccess<SalonDto>(response);

            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SalonDto entity)
        {

            //ApiResponseSuccess<string> oObject = ApiResponseSuccess<string>.getResponseSucces();
            var response = await _salonService.Save(entity);

            if (response.Equals("MSG_0001")){
                var apiResponseSuccess = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseSuccess);
            }else{
                var apiResponseError = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseError);
            }

            return status; //Retornamos un estado (200 y/o 400)
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] SalonDto entity)
        {
            
            entity.Id = id;
            var response = await _salonService.Update(entity);

            if (response.Equals("MSG_0002")){
                var apiResponseSuccess = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseSuccess);
            }else{
                var apiResponseError = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseError);
            }

            return status;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _salonService.Delete(id);

            if (response.Equals("MSG_0003")){
                var apiResponseSuccess = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseSuccess);
            }else{
                var apiResponseError = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseError);
            }

            return status;
        }
    }
}
