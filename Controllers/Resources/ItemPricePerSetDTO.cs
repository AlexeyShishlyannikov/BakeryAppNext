using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class ItemPricePerSetDTO
    {
        public int? Id { get; set; }
        public double SetPrice { get; set; }
        public int SetSize { get; set; }
    }
}
