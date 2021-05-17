namespace FreightTransport_BLL.DTOs
{
    public class CargoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }

        public int OwnerId { get; set; }
        public int? TransportationId { get; set; }
    }
}