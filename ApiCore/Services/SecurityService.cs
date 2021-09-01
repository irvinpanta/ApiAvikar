using Api.Core.Repositories.Interface;
using Api.Core.Services.Interface;
using Api.Models.Entities;
using Api.Models.Secutiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<EmpleadoModel> GetUserCredentials(UserLogin login)
        {
            var response = await _securityRepository.GetUserCredentials(login);
            return response;
        }
    }
}
