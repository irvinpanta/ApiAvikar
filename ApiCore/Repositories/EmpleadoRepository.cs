using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public class EmpleadoRepository : IBaseRepository<EmpleadoModel>
    {
        private readonly SisAvikarDemoContext _context;
        private string message;
        public EmpleadoRepository(SisAvikarDemoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmpleadoModel>> GetAll()
        {
            //var response = await _context.Empleados.ToListAsync();

            var sql = from empleado in _context.Empleados
                      join roles in _context.Roles on empleado.Rol equals roles.Id
                      select new EmpleadoModel
                      {
                          Id = empleado.Id,
                          Documento = empleado.Documento,
                          Nombres = empleado.Nombres,
                          Apellidos = empleado.Apellidos,
                          Direccion = empleado.Direccion,
                          Telefono = empleado.Telefono,
                          Activo = empleado.Activo,
                          Rol = empleado.Rol,
                          Roles = new RolModel
                          {
                              Id = roles.Id,
                              Descripcion = roles.Descripcion,
                          }
                      };

            return await sql.ToListAsync();
        }

        public async Task<EmpleadoModel> GetById(int id)
        {
            var sql = from empleado in _context.Empleados
                      join roles in _context.Roles on empleado.Rol equals roles.Id
                      select new EmpleadoModel
                      {
                          Id = empleado.Id,
                          Documento = empleado.Documento,
                          Nombres = empleado.Nombres,
                          Apellidos = empleado.Apellidos,
                          Direccion = empleado.Direccion,
                          Telefono = empleado.Telefono,
                          Activo = empleado.Activo,
                          Rol = empleado.Rol,
                          Roles = new RolModel
                          {
                              Id = roles.Id,
                              Descripcion = roles.Descripcion,
                          }
                      };

            var response = await sql.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<string> Save(EmpleadoModel entity)
        {
             _context.Empleados.Add(entity);
            int n = await _context.SaveChangesAsync();

            if(n != 0)
            {
                message = "Registro guarado con exito";
            }
            else{
                message = "Error al guardar";
            }

            return message;
        }

        public Task<string> Update(EmpleadoModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByDescripcion(string descripcion)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
