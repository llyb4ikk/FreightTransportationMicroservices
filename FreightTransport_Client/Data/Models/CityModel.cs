using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Region Region { get; set; }
    }
}