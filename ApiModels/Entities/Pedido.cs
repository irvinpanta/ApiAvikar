using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            Venta = new HashSet<Venta>();
        }

        public int Pedido1 { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? Mesa { get; set; }
        public int? Empleado { get; set; }
        public byte? Estado { get; set; }
        public string Xml { get; set; }

        public virtual EmpleadoModel EmpleadoNavigation { get; set; }
        public virtual MesaModel MesaNavigation { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
