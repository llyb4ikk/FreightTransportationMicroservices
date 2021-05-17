using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransport_DAL.Enums;

namespace FreightTransport_DAL.Entities
{
    public class Transportation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TransportationStatus Status { get; set; }
        public double Distance { get; set; }
        public int Cost { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int StartCityId { get; set; }
        public City StartCity { get; set; }

        public int DestinationCityId { get; set; }
        public City DestinationCity { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
        public ICollection<DriverSalary> DriverSalaries { get; set; }
    }
}
