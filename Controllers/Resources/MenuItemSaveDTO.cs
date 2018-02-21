using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Controllers.Resources
{
    public class MenuItemSaveDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double? MinimumWeight { get; set; }
        public MenuItemPriceDTO Price { get; set; }
        public ICollection<int> Ingredients { get; set; }
        public MenuItemSaveDTO()
        {
            Ingredients = new Collection<int>();
        }
    }
}
