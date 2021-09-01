using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int TipoProducto1 { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
