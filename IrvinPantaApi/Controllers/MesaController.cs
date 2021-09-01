using Api.Core.Custom;
using Api.Core.Filters;
using Api.Core.Response;
using Api.Core.Services;
using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrvinPantaApi.Controllers
{
    //[Authorize] //Para consumir api debe estar autenticado
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        private ObjectResult status;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FiltersQuery filters)
        {
            var response = await _mesaService.GetAll(filters);

            var metadata = new Metadata  {
                TotalCount = response.TotalCount, //Cuanto registros tengo
                PageIndex = response.PageIndex, //En que pagina actual estamos
                PageSize = response.PageSize, //Cuantos registros por pagina
                TotalPages  = response.TotalPages, //total de paginas (TotalCount/PageSize)
                HasNextPage = response.HasNextPage, //True = Si existe una pagina Siguiente
                HasPreviousPage = response.HasPreviousPage //True = Si existe una pagina anterior 
            };

            //var apiResponse = new ApiResponseSuccess<IEnumerable<MesaDto>>(response)
            //{
            //    Pagination = metadata //Agreaganmos nuestra pagination en el JsonResultado
            //}; //Retornamos nuestro response

            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mesaService.GetById(id);
            var apiResponse = new ApiResponseSuccess<MesaDto>(response);
            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MesaDto entity)
        {
            //var mesaModel = new MesaModel
            //{
            //    Descripcion = entity.Descripcion,
            //    Cantidad = entity.Cantidad,
            //    Activo = entity.Activo,
            //    FecSistema = DateTime.Now,
            //    Salon = entity.Salon,
            //    MesaRapida = entity.MesaRapida
            //};

            var response = await _mesaService.Save(entity);

            if (response.Equals("MSG_0001")){
                var apiResponseS = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseS);
            }else{
                var apiResponseE = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseE);
            }

            return status;
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, MesaDto entity)
        {
            //var mesaModel = new MesaModel
            //{
            //    Mesa = id,
            //    Descripcion = entity.Descripcion,
            //    Cantidad = entity.Cantidad,
            //    Activo = entity.Activo,
            //    FecSistema = DateTime.Now,
            //    Salon = entity.Salon,
            //    MesaRapida = entity.MesaRapida
            //};
            entity.Id = id;
            var response = await _mesaService.Update(entity);
            if (response.Equals("MSG_0002")){
                var apiResponseS = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseS);
            }else{
                var apiResponseE = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseE);
            }

            return status;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mesaService.Delete(id);
            if (response.Equals("MSG_0003")){
                var apiResponseS = new ApiResponseSuccess<string>(response);
                status = Ok(apiResponseS);
            }else{
                var apiResponseE = new ApiResponseErrors<string>(response);
                status = BadRequest(apiResponseE);
            }

            return status;
        }


    }
}
