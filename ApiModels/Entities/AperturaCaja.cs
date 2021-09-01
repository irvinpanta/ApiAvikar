using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class AperturaCaja
    {
        public AperturaCaja()
        {
            ControlCajas = new HashSet<ControlCaja>();
            Movimientos = new HashSet<Movimiento>();
            Venta = new HashSet<Venta>();
        }

        public int Apertura { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public decimal? Inicio { get; set; }
        public decimal? Cierre { get; set; }
        public int? CodCaja { get; set; }
        public byte? Activo { get; set; }
        public decimal? ImporteTotal { get; set; }
        public decimal? Efectivo { get; set; }
        public decimal? Tarjeta { get; set; }
        public decimal? Salida { get; set; }
        public byte? Existe { get; set; }
        public string Maquina { get; set; }
        public string Descri { get; set; }

        public virtual Caja CodCajaNavigation { get; set; }
        public virtual ICollection<ControlCaja> ControlCajas { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
