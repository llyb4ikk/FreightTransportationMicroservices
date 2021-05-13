using FreightTransport_Client.Data.Enums;
using System;

namespace FreightTransport_Client.Data.Models
{
    public class TransportationInfoModel
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TransportationStatus Status { get; set; }

        public int Distance { get; set; }
        public int Cost { get; set; }

        public string DestinationRegion { get; set; }
        public string DestinationCity { get; set; }
        public string StartRegion { get; set; }
        public string StartCity { get; set; }

        public string CargoName { get; set; }
        public string CargoDescription { get; set; }
        public float Weight { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }
    }
}