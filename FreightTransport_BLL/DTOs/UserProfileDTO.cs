using System;

namespace FreightTransport_BLL.DTOs
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CountOfOrders { get; set; }
    }
}