using Api.Models.Entities;
using Api.Models.Secutiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services.Interface
{
    public interface ISecurityService
    {
        Task<EmpleadoModel> GetUserCredentials(UserLogin login);
    }
}
