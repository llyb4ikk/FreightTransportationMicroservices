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

        public string StartCityId { get; set; }
        public string DestinationCityId { get; set; }

        public ICollection<DriverSalary> DriverSalaries { get; set; }
    }
}
