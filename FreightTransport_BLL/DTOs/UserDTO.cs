using System;
using System.Collections.Generic;
using FreightTransport_DAL.Entities;

namespace FreightTransport_BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CountOfOrders { get; set; }
    }
}