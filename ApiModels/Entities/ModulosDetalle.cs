using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models.Entities
{
    public partial class ModulosDetalle
    {
        public int? Modulo { get; set; }
        public int? Rol { get; set; }

        public virtual Modulo ModuloNavigation { get; set; }
        public virtual RolModel RolNavigation { get; set; }
    }
}
