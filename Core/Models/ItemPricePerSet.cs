using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Core.Models
{
    public class ItemPricePerSet
    {
        public int Id { get; set; }
        public int MenuItemPriceId { get; set; }
        public double SetPrice { get; set; }
        public int SetSize { get; set; }
    }
}
