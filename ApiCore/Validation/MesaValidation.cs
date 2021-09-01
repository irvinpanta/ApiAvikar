using Api.Models;
using Api.Models.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Validation
{
    public class MesaValidation: AbstractValidator<MesaDto>
    {
        public MesaValidation()
        {
            RuleFor(mesa => mesa.Descripcion)
                .NotNull()
                .Length(1, 50);
            RuleFor(mesa => mesa.Cantidad)
                .NotNull();
            RuleFor(mesa => mesa.Salon)
               .NotNull();
            RuleFor(mesa => mesa.MesaRapida)
               .NotNull();
            RuleFor(mesa => mesa.Activo)
              .NotNull();
        }
    }
}
