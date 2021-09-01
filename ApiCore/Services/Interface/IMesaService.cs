using Api.Core.Custom;
using Api.Core.Filters;
using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public interface IMesaService
    {
        Task<PaginatedList<MesaDto>> GetAll(FiltersQuery filters);
        Task<MesaDto> GetById(int id);
        Task<string> Save(MesaDto entity);
        Task<string> Update(MesaDto entity);
        Task<string> Delete(int id);
    }
}
