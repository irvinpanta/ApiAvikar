using Api.Models.Entities;
using Api.Models.Secutiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories.Interface
{
    public interface ISecurityRepository
    {
        Task<EmpleadoModel> GetUserCredentials(UserLogin login);
    }
}
