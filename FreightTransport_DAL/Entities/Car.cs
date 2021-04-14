using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public float FuelConsumption { get; set; }
        public int CarryingCapacity { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }
    }
}
