using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Movimiento
    {
        public int CodMovimientos { get; set; }
        public int? Apertura { get; set; }
        public DateTime? FecHora { get; set; }
        public string Turno { get; set; }
        public int? TipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public decimal? Importe { get; set; }
        public byte? Activo { get; set; }
        public int? Pedido { get; set; }

        public virtual AperturaCaja AperturaNavigation { get; set; }
        public virtual TipoOperacion TipoOperacionNavigation { get; set; }
    }
}
