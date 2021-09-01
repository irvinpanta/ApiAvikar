using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Producto
    {
        public int Producto1 { get; set; }
        public string Descripcion { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public string Foto { get; set; }
        public byte? Activo { get; set; }
        public int? FamProducto { get; set; }
        public int? TipoProducto { get; set; }
        public DateTime? FecSistema { get; set; }

        public virtual FamiliaProducto FamProductoNavigation { get; set; }
        public virtual TipoProducto TipoProductoNavigation { get; set; }
        public virtual AreaDespacho AreaDespacho { get; set; }
    }
}
