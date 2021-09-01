using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class Modulo
    {
        public int Modulo1 { get; set; }
        public string Descripcion { get; set; }
        public byte? Activo { get; set; }
        public string Menu { get; set; }
    }
}
