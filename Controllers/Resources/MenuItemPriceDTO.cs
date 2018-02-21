using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class MenuItemPriceDTO
    {
        public double CakePricePerPound { get; set; }
        public decimal CakePricePerKg
        {
            get
            {
                return Math.Round((decimal)(CakePricePerPound / 0.45359237), 2);
            }
        }

        public ICollection<ItemPricePerSetDTO> PricePerSet { get; set; }

        public MenuItemPriceDTO()
        {
            PricePerSet = new Collection<ItemPricePerSetDTO>();
        }
    }
}
