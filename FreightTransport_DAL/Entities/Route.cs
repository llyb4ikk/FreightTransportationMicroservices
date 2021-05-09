using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class Route : BaseEntity
    {
        public double Distance { get; set; }
        public int Cost { get; set; }

        public int DestinationCityId { get; set; }
        public City DestinationCity { get; set; }

        public int StartCityId { get; set; }
        public City StartCity { get; set; }

        public ICollection<Transportation> Transportations { get; set; }
    }
}
