using Api.Core.Services.Interface;
using Api.Models.Entities;
using Api.Models.Secutiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IrvinPantaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, 
                                ISecurityService securityService,
                                IPasswordService passwordService)
        {
            _configuration = configuration;
            _securityService = securityService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin userLogin)
        {
            var validation = await isValidaUser(userLogin);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return BadRequest();
        }

        //[HttpPost]
        //public async Task<IActionResult> Get(UserLogin userLogin)
        //{
        //    var response = await _securityService.GetUserCredentials(userLogin);
        //    return Ok(response);
        //}

        private async Task<(bool, EmpleadoModel)> isValidaUser(UserLogin userLogin)
        {
            var response = await _securityService.GetUserCredentials(userLogin);
            var isValid = _passwordService.Check(response.Contrasenia, userLogin.Password);

            return (isValid, response);
        }

        private string GenerateToken(EmpleadoModel security)
        {

            var symmetricSecurityKry = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Secretkey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKry, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, $"{security.Nombres} {security.Apellidos}"),
                new Claim("Email", "irvinpanta@gmail.com"),
                new Claim(ClaimTypes.Role, security.Roles.Descripcion),
            };

            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
