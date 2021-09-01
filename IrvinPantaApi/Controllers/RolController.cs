using Api.Core.Filters;
using Api.Core.Response;
using Api.Core.Services;
using Api.Models.Dto;
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
    public class RolController : ControllerBase
    {
        private readonly IBaseService<RolDto> _rolService;
        public RolController(IBaseService<RolDto> rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FiltersQuery filters)
        {
            var response = await _rolService.GetAll(filters);
            var apiResponse = new ApiResponseSuccess<IEnumerable<RolDto>>(response);
            return Ok(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _rolService.GetById(id);
            var apiResponse = new ApiResponseSuccess<RolDto>(response);

            return Ok(apiResponse);
        }
    }
}
