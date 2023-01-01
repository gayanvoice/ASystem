using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class LoginViewModel
    {
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
    }
}