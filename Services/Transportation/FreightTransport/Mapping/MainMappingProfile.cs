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

            CreateMap<Transportation, TransportationDTO>().ReverseMap();

            //CreateMap<Transportation, TransportationDetailsDTO>()
            //    .ForMember(ri => ri.StartCity,
            //        c => c.MapFrom(r => r.StartCity.Name))
            //    .ForMember(ri => ri.StartRegion,
            //        c => c.MapFrom(r => r.StartCity.Region))
            //    .ForMember(ri => ri.DestinationCity,
            //        c => c.MapFrom(r => r.DestinationCity.Name))
            //    .ForMember(ri => ri.DestinationRegion,
            //        c => c.MapFrom(r => r.DestinationCity.Region)).ReverseMap();
 
            //CreateMap<Transportation, TransportationTableDTO>()
            //    .ForMember(ri => ri.StartCity,
            //        c => c.MapFrom(r => r.StartCity.Name))
            //    .ForMember(ri => ri.StartRegion,
            //        c => c.MapFrom(r => r.StartCity.Region))
            //    .ForMember(ri => ri.DestinationCity,
            //        c => c.MapFrom(r => r.DestinationCity.Name))
            //    .ForMember(ri => ri.DestinationRegion,
            //        c => c.MapFrom(r => r.DestinationCity.Region)).ReverseMap();

            CreateMap<DriverSalary, DriverSalaryDTO>().ReverseMap();

            CreateMap<DriverSalary, DriverSalaryInformationDTO>()
                .ForMember(d => d.Name,
                    c => c.MapFrom(t => t.CarDriver.Name))
                .ForMember(d => d.Surname,
                    c => c.MapFrom(t => t.CarDriver.Surname))
                .ForMember(d => d.MiddleName,
                    c => c.MapFrom(t => t.CarDriver.MiddleName));

        }
    }
}