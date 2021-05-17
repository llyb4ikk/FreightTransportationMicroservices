using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CountOfOrders { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
    }
}
