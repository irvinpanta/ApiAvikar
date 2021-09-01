using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Area
    {
        public Area()
        {
            AreaDespachos = new HashSet<AreaDespacho>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<AreaDespacho> AreaDespachos { get; set; }
    }
}
