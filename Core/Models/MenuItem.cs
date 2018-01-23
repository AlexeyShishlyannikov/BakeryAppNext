using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Core.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        public int? MinimumWeight { get; set; }
        public MenuItemPrice Price { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<MenuItemIngredient> Ingredients { get; set; }
        public MenuItem()
        {
            Ingredients = new Collection<MenuItemIngredient>();
            Photos = new Collection<Photo>();
        }
    }
}
