using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Controllers.Resources
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public ICollection<MenuItemDTO> MenuItems { get; set; }
        public bool Delivered { get; set; }

        public OrderDTO()
        {
            MenuItems = new Collection<MenuItemDTO>();
        }
    }
}
