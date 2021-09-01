using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class PedidoDetalle
    {
        public int? Pedido { get; set; }
        public int? Producto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public byte? Estado { get; set; }
        public int IdAuto { get; set; }

        public virtual Pedido PedidoNavigation { get; set; }
        public virtual Producto ProductoNavigation { get; set; }
    }
}
