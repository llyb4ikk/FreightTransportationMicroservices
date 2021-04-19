using System;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class CarDriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set;  }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public CarDriverStatus Status { get; set; }
    }
}