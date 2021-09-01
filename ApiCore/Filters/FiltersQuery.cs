using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Filters
{
    public class FiltersQuery
    {
        public FiltersQuery()
        {}
        public string Descripcion { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
