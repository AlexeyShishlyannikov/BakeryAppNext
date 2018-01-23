using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
