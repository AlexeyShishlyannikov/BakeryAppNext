using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers.Resources
{
    public class OrderSaveDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public ICollection<int> MenuItems { get; set; }
        public bool Delivered { get; set; }
        public OrderSaveDTO()
        {
            MenuItems = new Collection<int>();
        }
    }
}
