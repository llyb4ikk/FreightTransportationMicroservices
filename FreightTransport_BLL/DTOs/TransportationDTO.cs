using System;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class TransportationDTO
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TransportationStatus Status { get; set; }
        public int RouteId { get; set; }
        public int CargoId { get; set; }
        public int CarId { get; set; }
        public int CarDriverId { get; set; }
        public int? CarDriverSecondId { get; set; }
    }
}