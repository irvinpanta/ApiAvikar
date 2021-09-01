using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Persona { get; set; }
        public string Documento { get; set; }
        public string NombreCompelto { get; set; }
        public byte? Activo { get; set; }
        public DateTime? FecSistema { get; set; }
        public byte? Defecto { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
