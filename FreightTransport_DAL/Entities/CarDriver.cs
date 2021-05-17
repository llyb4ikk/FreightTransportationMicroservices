using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransport_DAL.Enums;

namespace FreightTransport_DAL.Entities
{
    public class CarDriver : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public CarDriverStatus Status { get; set; }

        public ICollection<DriverSalary> Salaries { get; set; }
    }
}
