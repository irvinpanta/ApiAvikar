using Api.Core.Filters;
using Api.Core.Response;
using Api.Core.Services;
using Api.Core.Services.Interface;
using Api.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrvinPantaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IBaseService<EmpleadoModel> _empleadoService;
        private readonly IPasswordService _passwordService;
        public EmpleadoController(IBaseService<EmpleadoModel> empleadoService, IPasswordService passwordService)
        {
            _empleadoService = empleadoService;
            _passwordService = passwordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FiltersQuery filters)
        {
            var response = await _empleadoService.GetAll(filters);
            var apiResponse = new ApiResponseSuccess<IEnumerable<EmpleadoModel>>(response);
            return Ok(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _empleadoService.GetById(id);
            var apiResponse = new ApiResponseSuccess<EmpleadoModel>(response);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Save(EmpleadoModel entity)
        {
            entity.Contrasenia = _passwordService.Hash(entity.Contrasenia);
            var response = await _empleadoService.Save(entity);

            return Ok(response);
        }
    }
}
