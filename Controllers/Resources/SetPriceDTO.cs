using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class SetPriceDTO
    {
        public ICollection<ItemPricePerSetDTO> PricePerSet { get; set; }

        public SetPriceDTO()
        {
            PricePerSet = new Collection<ItemPricePerSetDTO>();
        }
    }
}
