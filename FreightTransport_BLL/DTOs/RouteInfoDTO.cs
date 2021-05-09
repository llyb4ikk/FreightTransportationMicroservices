using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class RouteInfoDTO
    {
        public int Id { get; set; }
        public double Distance { get; set; }
        public int Cost { get; set; }

        public string DestinationCity { get; set; }
        public Region DestinationRegion { get; set; }

        public string StartCity { get; set; }
        public Region StartRegion { get; set; }

    }
}