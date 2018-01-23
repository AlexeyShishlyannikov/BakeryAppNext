using BakeryWebApi.Controllers.Resources;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Controllers.Resources
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? MinimumWeight { get; set; }
        public string Description { get; set; }
        public object Price { get; set; }
        public ICollection<ItemPhotoDTO> Photos { get; set; }
        public ICollection<IngredientDTO> Ingredients { get; set; }
        public MenuItemDTO()
        {
            Ingredients = new Collection<IngredientDTO>();
            Photos = new Collection<ItemPhotoDTO>();
        }
    }
}
