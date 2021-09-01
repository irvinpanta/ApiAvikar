using Api.Core.Repositories.Interface;
using Api.Models.Entities;
using Api.Models.Secutiry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly SisAvikarDemoContext _context;
        public SecurityRepository(SisAvikarDemoContext context)
        {
            _context = context;
        }

        public async Task<EmpleadoModel> GetUserCredentials(UserLogin login)
        {
            var sql = from empleado in _context.Empleados
                      join roles in _context.Roles on empleado.Rol equals roles.Id
                      select new EmpleadoModel
                      {
                          Id = empleado.Id,
                          Documento = empleado.Documento,
                          Nombres = empleado.Nombres,
                          Apellidos = empleado.Apellidos,
                          Contrasenia = empleado.Contrasenia,
                          Roles = new RolModel
                          {
                              Descripcion = roles.Descripcion,
                          }
                      };

            var response = await sql.FirstOrDefaultAsync(x =>
                                    x.Documento == login.User);
            //var response = await _context.Empleados.FirstOrDefaultAsync(x =>
            //                        x.Documento == login.User && 
            //                        x.Contrasenia == login.Password);
            return response;
        }
    }
}
