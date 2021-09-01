using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class MesaModel: BaseEntity
    {
        public MesaModel()
        {
            Pedidos = new HashSet<Pedido>();
        }

        //public int Mesa { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte? Activo { get; set; }
        public DateTime? FecSistema { get; set; }
        public int? Salon { get; set; }
        public byte? MesaRapida { get; set; }

        public virtual SalonModel Salones { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
