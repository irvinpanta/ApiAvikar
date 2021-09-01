using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Validation
{
    public class SalonValidation: AbstractValidator<SalonDto>
    {
        public SalonValidation()
        {
            RuleFor(salon => salon.Descripcion)
                .NotNull()
                .Length(1, 50);
            RuleFor(salon => salon.Capacidad)
                .NotNull();
        }
    }
}
