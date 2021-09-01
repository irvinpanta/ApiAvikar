using Api.Models.Dto;
using Api.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SalonModel, SalonDto>();
            CreateMap<SalonDto, SalonModel>();

            CreateMap<MesaModel, MesaDto>();
            CreateMap<MesaDto, MesaModel>();

            CreateMap<RolModel, RolDto>();
            CreateMap<RolDto, RolModel>();

            CreateMap<EmpleadoModel, EmpleadoDto>();
            CreateMap<EmpleadoDto, EmpleadoModel>();
        }
    }
}
