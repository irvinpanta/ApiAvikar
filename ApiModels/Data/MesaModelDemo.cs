using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public partial class MesaModelDemo
    {
        [Key]
        public int Mesa { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte Activo { get; set; }
        public DateTime? FecSistema { get; set; }
        public int Salon { get; set; }
        public byte MesaRapida { get; set; }
        public virtual SalonModelDemo Salones { get; set; }



    }
}
