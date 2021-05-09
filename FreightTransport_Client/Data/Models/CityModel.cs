using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float NorthLatitude { get; set; }
        public float EastLongitude { get; set; }

        public Region Region { get; set; }
    }
}