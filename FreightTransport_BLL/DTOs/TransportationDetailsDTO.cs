using System;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class TransportationDetailsDTO
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

        public string Model { get; set; }
        public int CarryingCapacity { get; set; }
        public CarType CarType { get; set; }

        public string NameCarDriver1 { get; set; }
        public string SurnameCarDriver1 { get; set; }
        public string MiddleNameCarDriver1 { get; set; }
        public int ExperienceCarDriver1 { get; set; }

        public string NameCarDriver2 { get; set; }
        public string SurnameCarDriver2 { get; set; }
        public string MiddleNameCarDriver2 { get; set; }
        public int ExperienceCarDriver2 { get; set; }
    }
}