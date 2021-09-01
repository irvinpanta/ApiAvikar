using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Caja
    {
        public Caja()
        {
            AperturaCajas = new HashSet<AperturaCaja>();
        }

        public int CodCaja { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<AperturaCaja> AperturaCajas { get; set; }
    }
}
