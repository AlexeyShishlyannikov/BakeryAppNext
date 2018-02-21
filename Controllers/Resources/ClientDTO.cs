using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ZipCode { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
