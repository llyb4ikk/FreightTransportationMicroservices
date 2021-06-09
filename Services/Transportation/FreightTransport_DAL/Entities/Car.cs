using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransport_DAL.Enums;

namespace FreightTransport_DAL.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public float FuelConsumption { get; set; }
        public int CarryingCapacity { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }
        public CarType CarType { get; set; }
        public CarStatus Status { get; set; }

        public ICollection<Transportation> Transportations { get; set; }
    }
}
