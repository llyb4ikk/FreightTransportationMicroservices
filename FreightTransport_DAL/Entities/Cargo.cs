using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class Cargo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public int? TransportationId { get; set; }
        public Transportation Transportation { get; set; }
    }
}