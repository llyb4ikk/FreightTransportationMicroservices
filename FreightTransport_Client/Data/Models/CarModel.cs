
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Fuel consumption invalid (1 - 1000)")]
        public float FuelConsumption { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Carrying capacity invalid(1 - 1000)")]
        public int CarryingCapacity { get; set; }

        [Range(0, 10, ErrorMessage = "Heigh invalid (0 - 100)")]
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Length { get; set; }

        [Required]
        public CarType CarType { get; set; }
        public CarStatus Status { get; set; }


        [JsonIgnore]
        public string message { get; set; }

    }
}
