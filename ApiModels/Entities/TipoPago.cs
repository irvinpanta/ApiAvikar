using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Venta = new HashSet<Venta>();
        }

        public int TipoP { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }
        public byte? RequiereEfectivo { get; set; }
        public byte? RequiereNumOp { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
