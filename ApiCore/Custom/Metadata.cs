using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Custom
{
    public class Metadata
    {

        public int TotalCount { get; set; } //Total de registros
        public int PageIndex { get; set; } //Pagina Actual
        public int PageSize { get; set; } //Numero de registros por Pagina
        public int TotalPages { get; set; } //Total de paginas (TotalCount/PageSize)
        public bool HasPreviousPage { get; set; } //True = Si existe pagina anterior
        public bool HasNextPage { get; set; } //False = Si existe pagina siguiente


    }
}
