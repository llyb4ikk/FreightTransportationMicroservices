using System;
using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class TransportationTableModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DestinationRegion { get; set; }
        public string DestinationCity { get; set; }
        public string StartRegion { get; set; }
        public string StartCity { get; set; }
        public TransportationStatus Status { get; set; }
    }
}