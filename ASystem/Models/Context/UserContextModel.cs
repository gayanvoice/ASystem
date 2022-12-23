namespace ASystem.Models.Context
{
    public class UserContextModel
    {
        public int UserId { get; set; } //11
        public string Username { get; set; } //20
        public string Password { get; set; } //1024
        public string Status { get; set; } //20
    }
}