using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class ControlCaja
    {
        public int ConCaja { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string Turno { get; set; }
        public string TipoApertura { get; set; }
        public decimal? Inicio { get; set; }
        public decimal? Cierre { get; set; }
        public int? Apertura { get; set; }
        public string Maquina { get; set; }
        public byte? Activo { get; set; }
        public decimal? ImporteTotal { get; set; }
        public decimal? Efectivo { get; set; }
        public decimal? Tarjeta { get; set; }
        public decimal? Salida { get; set; }

        public virtual AperturaCaja AperturaNavigation { get; set; }
    }
}
