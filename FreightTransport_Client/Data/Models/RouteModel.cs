namespace FreightTransport_Client.Data.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public double Distance { get; set; }
        public int Cost { get; set; }

        public int DestinationCityId { get; set; }
        public int StartCityId { get; set; }
    }
}