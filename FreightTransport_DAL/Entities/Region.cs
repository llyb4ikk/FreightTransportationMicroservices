﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Entities
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
