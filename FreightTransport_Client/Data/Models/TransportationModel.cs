using System;
using System.ComponentModel.DataAnnotations;
using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class TransportationModel
    {
        public int Id { get; set; }
        [Required]
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