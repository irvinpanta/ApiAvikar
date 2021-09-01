using Api.Models.Entities;
using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Dto
{
    public class MesaDto //: BaseEntity
    {
        //public int Mesa { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte Activo { get; set; }
        public DateTime FecSistema { get; set; }
        public int Salon { get; set; }
        public byte MesaRapida { get; set; }

        public virtual SalonModel Salones { get; set; }
    }
}
