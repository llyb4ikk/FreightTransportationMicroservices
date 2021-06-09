namespace Cargo_Application.DTOs
{
    public class CargoInformationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }

        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerMiddleName { get; set; }
    }
}