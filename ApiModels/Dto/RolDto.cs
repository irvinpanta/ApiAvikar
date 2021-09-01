using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Dto
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        public byte? Activo { get; set; }
    }
}
