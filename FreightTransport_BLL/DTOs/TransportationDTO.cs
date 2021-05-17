using System;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class TransportationDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TransportationStatus Status { get; set; }
        public double Distance { get; set; }
        public int Cost { get; set; }

        public int CarId { get; set; }

        public int StartCityId { get; set; }

        public int DestinationCityId { get; set; }
    }
}