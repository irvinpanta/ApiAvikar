using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class RolModel : BaseEntity
    {
        public RolModel()
        {
            Empleados = new HashSet<EmpleadoModel>();
        }

        //public int Rol { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<EmpleadoModel> Empleados { get; set; }
    }
}
