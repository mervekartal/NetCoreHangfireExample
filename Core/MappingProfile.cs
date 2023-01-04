using AutoMapper;
using Data.DataModel;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Container, ContainerEntity>();
            CreateMap<ContainerEntity, Container>();

            CreateMap<Vehicle, VehicleEntity>();
            CreateMap<VehicleEntity, Vehicle>();


        }
    }
}
