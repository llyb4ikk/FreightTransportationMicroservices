using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_DAL.Entities;

namespace FreightTransport.Mapping
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<CarDriver, CarDriverDTO>().ReverseMap();

            CreateMap<Car, CarDTO>().ReverseMap();

            CreateMap<Cargo, CargoDTO>().ReverseMap();

            CreateMap<Route, RouteDTO>().ReverseMap();

            CreateMap<Transportation, TransportationDTO>().ReverseMap();

            CreateMap<City, CityDTO>().ReverseMap();

            CreateMap<Route, RouteInfoDTO>()
                .ForMember(ri => ri.StartCity, c => c.MapFrom(r => r.StartCity.Name))
                .ForMember(ri => ri.StartRegion, c => c.MapFrom(r => r.StartCity.Region))
                .ForMember(ri => ri.DestinationCity, c => c.MapFrom(r => r.DestinationCity.Name))
                .ForMember(ri => ri.DestinationRegion, c => c.MapFrom(r => r.DestinationCity.Region)).ReverseMap();

        }
    }
}