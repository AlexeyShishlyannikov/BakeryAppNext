using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public int? ZipCode { get; set; }
    }
}
