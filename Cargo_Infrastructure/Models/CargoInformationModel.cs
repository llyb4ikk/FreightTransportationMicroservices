namespace Cargo_Infrastructure.Models
{
    public class CargoInformationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }

        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerMiddleName { get; set; }
    }
}