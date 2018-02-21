using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class FAQDTO
    {
        public int? Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
