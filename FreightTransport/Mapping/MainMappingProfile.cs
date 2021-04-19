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

        }
    }
}