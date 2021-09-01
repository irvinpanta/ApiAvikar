using Api.Core.Filters;
using Api.Models;
using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll(FiltersQuery filters);
        Task<T> GetById(int id);
        Task<string> Save(T entity);
        Task<string> Update(T entity);
        Task<string> Delete(int id);
    }
}
