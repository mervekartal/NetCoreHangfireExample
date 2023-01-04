using AutoMapper;
using Data.DataModel;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2_Bootcamp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Container, ContainerEntity>();
            CreateMap<ContainerEntity, Container>();
            CreateMap<VehicleEntity, Vehicle>();
            CreateMap<Vehicle, VehicleEntity>();

        }
    }
}
