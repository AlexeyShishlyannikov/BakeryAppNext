using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class CakePriceDTO
    {
        public double CakePricePerPound { get; set; }
        public decimal CakePricePerKg
        {
            get => Math.Round((decimal)(CakePricePerPound / 0.45359237), 2);
            
        }
    }
}
