using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<string> Save(T entity);
        Task<string> Update(T entity);
        Task<string> Delete(int id);

        bool ExistsById(int id);
        bool ExistsByDescripcion(string descripcion);

    }
}
