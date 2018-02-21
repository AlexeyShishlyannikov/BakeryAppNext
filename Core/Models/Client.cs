using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public IdentityUser Identity { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ZipCode { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
