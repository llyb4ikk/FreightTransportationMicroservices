namespace FreightTransport_Client.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { set; get; }
    }
}