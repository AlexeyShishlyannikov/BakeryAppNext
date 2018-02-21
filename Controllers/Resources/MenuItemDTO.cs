using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Controllers.Resources
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double? MinimumWeight { get; set; }
        public string Description { get; set; }
        public object Price { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; }
        public ICollection<IngredientDTO> Ingredients { get; set; }
        public MenuItemDTO()
        {
            Ingredients = new Collection<IngredientDTO>();
            Photos = new Collection<PhotoDTO>();
        }
    }
}
