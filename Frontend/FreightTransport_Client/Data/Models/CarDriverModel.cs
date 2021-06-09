using System;
using System.ComponentModel.DataAnnotations;
using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class CarDriverModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public CarDriverStatus Status { get; set; }
    }
}