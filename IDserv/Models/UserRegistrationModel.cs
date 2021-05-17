namespace IDserv.Models
{
    public class UserRegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}