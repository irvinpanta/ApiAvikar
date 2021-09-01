using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class SalonModel: BaseEntity
    {
        public SalonModel()
        {
            Mesas = new HashSet<MesaModel>();
        }

        //public int Salon { get; set; }
        public string Descripcion { get; set; }
        public int? Capacidad { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<MesaModel> Mesas { get; set; }
    }
}
