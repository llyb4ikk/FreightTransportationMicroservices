using Cargo_Domain.Interfaces;

namespace Cargo_Domain.Entities
{
    public class Cargo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }

        public string StartCityId { get; set; }
        public string DestinationCityId { get; set; }

        public int OwnerId { get; set; }

        public int? TransportationId { get; set; }
    }
}