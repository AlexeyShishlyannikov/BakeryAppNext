using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Controllers.Resources
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
