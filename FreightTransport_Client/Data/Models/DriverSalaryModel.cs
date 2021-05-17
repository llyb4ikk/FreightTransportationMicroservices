namespace FreightTransport_Client.Data.Models
{
    public class DriverSalaryModel
    {
        public int Id { get; set; }
        public int CarDriverId { get; set; }

        public int TransportationId { get; set; }

        public double Salary { get; set; }
    }
}