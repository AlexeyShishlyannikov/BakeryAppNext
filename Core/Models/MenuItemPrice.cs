
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextSugarCat.Core.Models
{
    [Table("MenuItemPrices")]
    public class MenuItemPrice
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public double? CakePricePerPound { get; set; }
        public decimal CakePricePerKg
        {
            get => Math.Round((decimal)(CakePricePerPound / 0.45359237), 2);
        }
        public ICollection<ItemPricePerSet> PricePerSet { get; set; }

        public MenuItemPrice()
        {
            PricePerSet = new Collection<ItemPricePerSet>();
        }
    }
}