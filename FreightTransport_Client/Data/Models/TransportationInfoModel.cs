using FreightTransport_Client.Data.Enums;
using System;

namespace FreightTransport_Client.Data.Models
{
    public class TransportationInfoModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DestinationRegion { get; set; }
        public string DestinationCity { get; set; }
        public string StartRegion { get; set; }
        public string StartCity { get; set; }
        public int Distance { get; set; }
        public int Cost { get; set; }
        public TransportationStatus Status { get; set; }
    }
}