﻿using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextSugarCat.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderMenuItem> MenuItems { get; set; }
        public bool Delivered { get; set; }
        public Order()
        {
            MenuItems = new Collection<OrderMenuItem>();
        }
    }
}
