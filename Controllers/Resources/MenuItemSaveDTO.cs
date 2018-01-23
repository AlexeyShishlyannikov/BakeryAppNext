using BakeryWebApi.Controllers.Resources;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Controllers.Resources
{
    public class MenuItemSaveDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? MinimumWeight { get; set; }
        public MenuItemPriceDTO Price { get; set; }
        public ICollection<ItemPhotoDTO> Photos { get; set; }
        public ICollection<int> Ingredients { get; set; }
        public MenuItemSaveDTO()
        {
            Ingredients = new Collection<int>();
            Photos = new Collection<ItemPhotoDTO>();
        }
    }
}
