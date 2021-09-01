using Api.Models.Entities;
using Api.Models.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly SisAvikarDemoContext _context;
        private DbSet<T> _entity;
        private string message;
        public BaseRepository(SisAvikarDemoContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<string> Save(T entity)
        {
            await _entity.AddAsync(entity);
            int n = _context.SaveChanges();

            if (n != 0){
                message = "MSG_0001";
            }else{
                message = "MSG_ERROR";
            }

            return message;
        }

        public async Task<string> Update(T entity)
        {
            _entity.Update(entity);
            var n = await _context.SaveChangesAsync();
            if (n != 0){
                message = "MSG_0002";
            }else{
                message = "MSG_ERROR";
            }

            return message;
        }

        public async Task<string> Delete(int id)
        {
            var removeModel = await _entity.FindAsync(id);
            _entity.Remove(removeModel);
            int n = await _context.SaveChangesAsync();

            if (n != 0){
                message = "MSG_0003";
            }else{
                message = "MSG_ERROR";
            }

            return message;
        }

        public bool ExistsByDescripcion(string descripcion)
        {
            return _entity.Any(x => x.Equals(descripcion));
        }

        public bool ExistsById(int id)
        {
            return _context.Salones.Any(x => x.Id == id);
        }
    }
}
