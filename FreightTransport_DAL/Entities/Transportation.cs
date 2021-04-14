using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class Transportation : BaseEntity
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CarDriverId { get; set; }
        public CarDriver CarDriver { get; set; }
        public int? CarDriverSecondId { get; set; }
        public CarDriver? CarDriverSecond { get; set; }
    }
}
