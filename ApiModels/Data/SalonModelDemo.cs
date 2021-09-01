using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public partial class SalonModelDemo
    {
        [Key]
        public int Salon { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public byte Activo { get; set; }
    }
}
