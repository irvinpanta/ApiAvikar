using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int TipoOperacion1 { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }
        public DateTime? FecSistema { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
