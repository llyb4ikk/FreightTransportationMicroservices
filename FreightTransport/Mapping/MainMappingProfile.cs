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

            CreateMap<City, CityDTO>().ReverseMap();
            
            CreateMap<Transportation, TransportationDTO>().ReverseMap();

            CreateMap<Transportation, TransportationDetailsDTO>()
                .ForMember(ri => ri.StartCity,
                    c => c.MapFrom(r => r.StartCity.Name))
                .ForMember(ri => ri.StartRegion,
                    c => c.MapFrom(r => r.StartCity.Region))
                .ForMember(ri => ri.DestinationCity,
                    c => c.MapFrom(r => r.DestinationCity.Name))
                .ForMember(ri => ri.DestinationRegion,
                    c => c.MapFrom(r => r.DestinationCity.Region)).ReverseMap();
 
            CreateMap<Transportation, TransportationTableDTO>()
                .ForMember(ri => ri.StartCity,
                    c => c.MapFrom(r => r.StartCity.Name))
                .ForMember(ri => ri.StartRegion,
                    c => c.MapFrom(r => r.StartCity.Region))
                .ForMember(ri => ri.DestinationCity,
                    c => c.MapFrom(r => r.DestinationCity.Name))
                .ForMember(ri => ri.DestinationRegion,
                    c => c.MapFrom(r => r.DestinationCity.Region)).ReverseMap();

            CreateMap<DriverSalary, DriverSalaryDTO>().ReverseMap();

            CreateMap<DriverSalary, DriverSalaryInformationDTO>()
                .ForMember(d => d.Name,
                    c => c.MapFrom(t => t.CarDriver.Name))
                .ForMember(d => d.Surname,
                    c => c.MapFrom(t => t.CarDriver.Surname))
                .ForMember(d => d.MiddleName,
                    c => c.MapFrom(t => t.CarDriver.MiddleName));

            CreateMap<Cargo, CargoDetailsDTO>()
                .ForMember(cd => cd.OwnerName,
                    c => c.MapFrom(c => c.Owner.Name))
                .ForMember(cd => cd.OwnerSurname,
                    c => c.MapFrom(c => c.Owner.Surname))
                .ForMember(cd => cd.OwnerMiddleName,
                    c => c.MapFrom(c => c.Owner.MiddleName));

            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}