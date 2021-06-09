namespace FreightTransport_BLL.DTOs
{
    public class DriverSalaryDTO
    {
        public int Id { get; set; }
        public int CarDriverId { get; set; }

        public int TransportationId { get; set; }

        public double Salary { get; set; }
    }
}