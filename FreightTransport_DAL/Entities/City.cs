using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransport_DAL.Enums;

namespace FreightTransport_DAL.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Region Region { get; set; }

        public ICollection<Transportation> StartRoutes { get; set; }
        public ICollection<Transportation> DestinationRoutes { get; set; }

    }
}
