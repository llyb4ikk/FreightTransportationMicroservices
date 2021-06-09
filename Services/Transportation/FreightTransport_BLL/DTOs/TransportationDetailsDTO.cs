using System;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class TransportationDetailsDTO
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