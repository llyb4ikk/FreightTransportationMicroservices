namespace FreightTransport_DAL.Entities
{
    public class DriverSalary : BaseEntity
    {
        public int CarDriverId { get; set; }
        public CarDriver CarDriver { get; set; }

        public int TransportationId { get; set; }
        public Transportation Transportation { get; set; }

        public double Salary { get; set; }
    }
}