using System;

namespace FreightTransport_Client.Data.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
    }
}