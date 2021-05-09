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
        public float NorthLatitude { get; set; }
        public float EastLongitude { get; set; }

        public Region Region { get; set; }

        public ICollection<Route> StartRoutes { get; set; }
        public ICollection<Route> DestinationRoutes { get; set; }

    }
}
