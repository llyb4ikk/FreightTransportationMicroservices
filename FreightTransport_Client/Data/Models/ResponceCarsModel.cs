using System.Collections.Generic;
using System.Net;

namespace FreightTransport_Client.Data.Models
{
    public class ResponceCarsModel
    {
        public ResponceCarsModel(IEnumerable<CarModel> cars = null)
        {
            Cars = cars;
        }
        public IEnumerable<CarModel> Cars { get; set; }

        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}