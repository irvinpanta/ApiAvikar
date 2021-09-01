using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class AreaDespacho
    {
        public int Despacho { get; set; }
        public int? Producto { get; set; }
        public int? Id { get; set; }

        public virtual Area IdNavigation { get; set; }
        public virtual Producto ProductoNavigation { get; set; }
    }
}
