using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Venta
    {
        public int CodVenta { get; set; }
        public int? Pedido { get; set; }
        public int? Persona { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? TipoP { get; set; }
        public decimal? ImporteTotal { get; set; }
        public int? Apertura { get; set; }
        public byte? Estado { get; set; }
        public string Turno { get; set; }

        public virtual AperturaCaja AperturaNavigation { get; set; }
        public virtual Pedido PedidoNavigation { get; set; }
        public virtual Cliente PersonaNavigation { get; set; }
        public virtual TipoPago TipoPNavigation { get; set; }
    }
}
