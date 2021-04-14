using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class CarType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
