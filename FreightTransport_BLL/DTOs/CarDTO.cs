using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.DTOs
{
    public class CarDTO
    {
        public string Model { get; set; }
        public float FuelConsumption { get; set; }
        public int CarryingCapacity { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }
        public CarType CarType { get; set; }
        public CarStatus Status { get; set; }
    }
}