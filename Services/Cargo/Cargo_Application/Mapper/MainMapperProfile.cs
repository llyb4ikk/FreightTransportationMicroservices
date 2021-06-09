using AutoMapper;
using Cargo_Application.DTOs;
using Cargo_Domain.Entities;
using Cargo_Infrastructure.Models;

namespace Cargo_Application.Mapper
{
    public class MainMapperProfile : Profile
    {
        public MainMapperProfile()
        {
            CreateMap<Cargo_Domain.Entities.Client, ClientDTO>().ReverseMap();

            CreateMap<Cargo_Domain.Entities.Cargo, CargoDTO>().ReverseMap();
            CreateMap<CargoInformationModel, CargoInformationDTO>().ReverseMap();
        }
    }
}