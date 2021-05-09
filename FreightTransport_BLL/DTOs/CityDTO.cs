using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float NorthLatitude { get; set; }
        public float EastLongitude { get; set; }

        public Region Region { get; set; }
    }
}