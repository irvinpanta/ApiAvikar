using Api.Models.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Dto
{
    public class SalonDto : BaseEntity
    {
        //public int Salon { get; set; }
        public string Descripcion { get; set; }
        public int? Capacidad { get; set; }
        public byte? Activo { get; set; }
    }
}
