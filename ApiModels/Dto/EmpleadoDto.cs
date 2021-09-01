using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Dto
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte? Activo { get; set; }
        public int? Rol { get; set; }

        public virtual RolModel Roles { get; set; }
    }
}
