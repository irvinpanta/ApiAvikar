using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class FamiliaProducto
    {
        public FamiliaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int FamProducto { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }
        public DateTime? FecSistema { get; set; }
        public string Foto { get; set; }
        public byte? ControlStock { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
