using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public class RolRepository : IBaseRepository<RolModel>
    {

        private readonly SisAvikarDemoContext _context;
        private string message;
        public RolRepository(SisAvikarDemoContext context)
        {
            _context = context;
        }

        //Metodo para mostrar todos los registros
        public async Task<IEnumerable<RolModel>> GetAll()
        {
            var response = await _context.Roles.ToListAsync();
            return response;
        }

        //Metodo para Mostrar registros por Id
        public async Task<RolModel> GetById(int id)
        {
            var response = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        //Grabar registros en la base de datos
        public async Task<string> Save(RolModel entity)
        {
            await _context.Roles.AddAsync(entity);
            int n = _context.SaveChanges();

            if (n != 0)
            {
                message = "MSG_0001";
            }
            else
            {
                message = "MSG_ERROR";
            }

            return message;
        }


        //Modificar registro de la base de datos
        public async Task<string> Update(RolModel entity)
        {
            int n;

            //if (!(_context.Roles.Any(x=>x.Descripcion.Equals(entity.Descripcion) && x.Salon != entity.Salon))){
            _context.Roles.Update(entity);
            n = await _context.SaveChangesAsync();
            //}else{
            //    message = "Registro ya existe";
            //}
            if (n != 0)
            {
                message = "MSG_0002";
            }
            else
            {
                message = "MSG_ERROR";
            }

            return message;
        }

        //Metodo para Eliminar registros
        public async Task<string> Delete(int id)
        {
            var removeModel = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(removeModel);
            int n = await _context.SaveChangesAsync();

            if (n != 0)
            {
                message = "MSG_0003";
            }
            else
            {
                message = "MSG_ERROR";
            }

            return message;
        }

        //Verifica Si EXiste por Descripcion
        public bool ExistsByDescripcion(string descripcion)
        {
            return _context.Roles.Any(x => x.Descripcion.Equals(descripcion));
        }

        //Verifica Si EXiste por Id
        public bool ExistsById(int id)
        {
            return _context.Roles.Any(x => x.Id == id);
        }
    }
}
